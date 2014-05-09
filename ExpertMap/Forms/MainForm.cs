using System;
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
        private const float _opacity = 1f;

        private ContextMenu _menu = new ContextMenu();
        
        private Point _clickedLocation;
        private DrawableItem _clickedObject;

        private bool _drag = false;

        public Drawer CurrentDrawer { get; set; }

        private PointF CurrentDelta
        {
            get { return Functions.GetDelta(pbMap.Size, DefaultMapSize); }
        }

        private void Init()
        {
            DbHelper.GetInstance();
            CurrentDrawer = new Drawer();
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

        private void ShowContextMenu(ClickTarget target)
        {
            _menu = new ContextMenu();

            var addMenuItem = new MenuItem("Добавить маркер", AddMarkerItem_Click);
            var editMenuItem = new MenuItem("Редактировать маркер", EditMarkerItem_Click);
            var replaceMenuItem = new MenuItem("Переместить маркер", ReplaceMarkerItem_Click);
            var removeMenuItem = new MenuItem("Удалить маркер", RemoveMarkerItem_Click);

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
            _menu.Show(pbMap, _clickedLocation);
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

        private Marker CreateMarker(Image image, int X, int Y)
        {
            var Marker = new Marker(image, new Point(X, Y));
            Marker.Opacity = _opacity;
            CurrentDrawer.DrawableItems.Add(Marker);
            return Marker;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDrawableItems();
        }

        private void AddMarkerItem_Click(object sender, EventArgs e)
        {
            var location = Functions.ModifyToBasePoint(_clickedLocation, CurrentDelta);
            var marker = CreateMarker(Properties.Resources.star, location.X, location.Y);
            marker.RecalcCoordinates(CurrentDelta);
            CurrentDrawer.DrawItem(pbMap.CreateGraphics(), marker);
        }

        private void EditMarkerItem_Click(object sender, EventArgs e)
        {

        }

        private void ReplaceMarkerItem_Click(object sender, EventArgs e)
        {
            _drag = true;
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
            if (e.Button == System.Windows.Forms.MouseButtons.Right && !_drag)
            {
                _clickedLocation = e.Location;
                DrawableItem item = null;

                if (CurrentDrawer.TryGetContainer(e.Location, out item))
                {
                    _clickedObject = item;

                    if (item is Marker)
                    {
                        ShowContextMenu(ClickTarget.Marker);
                    }
                    else
                    {
                        //todo: region
                    }
                }
                else
                    ShowContextMenu(ClickTarget.Map);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && _drag)
            {
                var marker = (_clickedObject as Marker);

                marker.DefaultLocation = Functions.ModifyToBasePoint(
                    new Point(marker.Rectangle.Location.X + marker.Rectangle.Width / 2,
                              marker.Rectangle.Location.Y + marker.Rectangle.Height / 2),
                    CurrentDelta);

                _drag = false;
            }
        }

        private void pbMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (_drag)
            {
                var marker = (_clickedObject as Marker);

                pbMap.Invalidate(marker.Rectangle);

                marker.Rectangle = new Rectangle(new Point(e.Location.X - marker.Rectangle.Width, 
                    e.Location.Y - marker.Rectangle.Height), marker.Rectangle.Size);
            }
        }
    }
}
