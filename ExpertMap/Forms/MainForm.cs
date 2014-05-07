﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpertMap.DbTools;
using System.IO;
using System.Resources;
using System.Collections;
using ExpertMap.Properties;
using ExpertMap.Models;
using ExpertMap.Tools;

namespace ExpertMap.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private Size DefaultMapSize = new Size(550, 440);
        private const float _opacity = 0.7f;

        private ContextMenu _menu = new ContextMenu();
        private Point _clickedLocation;
        private object _clickedObject;

        public Drawer CurrentDrawer { get; set; }

        private PointF CurrentDelta
        {
            get { return Functions.GetDelta(pbMap.Size, DefaultMapSize); }
        }

        private void Init()
        {
            DbHelper.GetInstance(Properties.Settings.Default.ExpertMapDbConnectionString);
            CurrentDrawer = new Drawer();
        }

        private void LoadMarkers()
        {

        }

        private void LoadDrawableItems()
        {
            var allMarkers = DbHelper.GetInstance().ExpertMapDataSet.Marker;
            var delta = CurrentDelta;

            foreach (var item in allMarkers)
            {
                var imagePath = Path.Combine(Application.StartupPath,"Pictures", item.ImageName);
                Image image = null;

                if (File.Exists(imagePath))
                {
                    image = Image.FromFile(imagePath);
                }
                else
                {
                    image = Properties.Resources.star;
                }

                CreateMarker(image, item.X, item.Y);
            }

            CurrentDrawer.DrawItems(pbMap.CreateGraphics());
        }

        private MarkerContainer CreateMarker(Image image, int X, int Y)
        {
            var markerContainer = new MarkerContainer(image, new Point(X, Y), pbMap);
            markerContainer.Opacity = _opacity;
            CurrentDrawer.DrawableItems.Add(markerContainer);
            markerContainer.Panel.MouseUp += Panel_MouseUp;
            return markerContainer;
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _clickedLocation = e.Location;
                ShowContextMenu(ClickTarget.Marker);
            }
        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {

            try
            {
                CurrentDrawer.DrawItems(e.Graphics);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void ShowContextMenu(ClickTarget target)
        {
            _menu = new ContextMenu();

            var addMenuItem = new MenuItem("Добавить маркер", AddMarkerItem_Click);
            var editMenuItem = new MenuItem("Редактировать маркер", EditMarkerItem_Click);
            var replaceMenuItem = new MenuItem("Переместить маркер", ReplaceMarkerItem_Click);
            var removeMenuItem = new MenuItem("Переместить маркер", RemoveMarkerItem_Click);

            var menuItems = new MenuItem[1];

            switch (target)
            {
                case ClickTarget.Map:
                    menuItems = new MenuItem[] { addMenuItem };
                    break;
                case ClickTarget.Marker:
                    menuItems = new MenuItem[] { editMenuItem, replaceMenuItem, removeMenuItem };
                    break;
                case ClickTarget.Region:
                    menuItems = new MenuItem[] { addMenuItem };
                    break;
                default:
                    break;
            }

            _menu.MenuItems.AddRange(menuItems);
            _menu.Show(this, _clickedLocation);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDrawableItems();
        }

        private void SaveMarker(Point location, string filename, int? region)
        {
            var point = Functions.ModifyToFormPoint(location, CurrentDelta);

            ExpertMap.DataModels.ExpertMapDataSet.MarkerRow markerRow =
                DbHelper.GetInstance().ExpertMapDataSet.Marker.AddMarkerRow(point.X, point.Y, string.Empty, filename);

            if (region.HasValue)
            {
                if (DbHelper.GetInstance().ExpertMapDataSet.Region.Any(x => x.Id == region.Value))
                {
                    var regionRow = 
                        DbHelper.GetInstance().ExpertMapDataSet.Region.Where(x => x.Id == region.Value).FirstOrDefault();
                    DbHelper.GetInstance().ExpertMapDataSet.MarkerInRegion.AddMarkerInRegionRow(markerRow, regionRow);
                }
            }

            DbHelper.GetInstance().ExpertMapDataSet.AcceptChanges();
        }

        private void AddMarkerItem_Click(object sender, EventArgs e)
        {
            var marker = CreateMarker(Properties.Resources.star, _clickedLocation.X, _clickedLocation.Y);
            CurrentDrawer.DrawItem(pbMap.CreateGraphics(), marker);
        }

        private void EditMarkerItem_Click(object sender, EventArgs e)
        {

        }

        private void ReplaceMarkerItem_Click(object sender, EventArgs e)
        {
 
        }

        private void RemoveMarkerItem_Click(object sender, EventArgs e)
        {

        }

        private void pbMap_Resize(object sender, EventArgs e)
        {
            CurrentDrawer.RecalcCoordinates(CurrentDelta);
        }

        private void pbMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _clickedLocation = pbMap.Location;
                ShowContextMenu(ClickTarget.Map);
            }
        }
    }
}
