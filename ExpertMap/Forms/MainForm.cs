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

        private List<ImageItem> _imageItems;
        private const string _picturesFolder = "Pictures";
        private const string _markerPrefix = "Marker";

        private Size DefaultMapSize = new Size(550, 398);
        private const float _opacity = 1f;

        private ContextMenuStrip _menu = new ContextMenuStrip();
        
        private Point _clickedLocation;
        private DrawableItem _clickedObject;
        private Rectangle _regionRectangle;

        private bool _drag = false;
        private bool _drawningRegion = false;
        private bool _canDrawRegion = false;

        public Drawer CurrentDrawer { get; set; }

        private PointF CurrentDelta
        {
            get { return Drawer.GetDelta(pbMap.Size, DefaultMapSize); }
        }

        private void InitImageItems()
        {
            _imageItems = new List<ImageItem>();
            ResourceSet resources = Resources.ResourceManager.GetResourceSet(
                new System.Globalization.CultureInfo("en"), false, true);

            IDictionaryEnumerator resourceList = resources.GetEnumerator();

            while (resourceList.MoveNext())
            {
                string key = (string)resourceList.Key;
                if (resourceList.Value is Image && key.StartsWith(_markerPrefix))
                {
                    var image = (Image)resourceList.Value;

                    _imageItems.Add(
                        new ImageItem()
                        {
                            Image = image,
                            ImageKey = key.Substring(_markerPrefix.Length, key.Length - _markerPrefix.Length)
                        });
                }
            }
        }

        private void Init()
        {
            DbHelper.GetInstance();
            CurrentDrawer = new Drawer();
            InitImageItems();
        }

        private void SaveMarker(Point location, string filename, int? region)
        {
            var point = Drawer.ModifyToFormPoint(location, CurrentDelta);

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
            _menu = new ContextMenuStrip();

            var addMarkerMenuItem = new ToolStripMenuItem("Добавить маркер");
            _imageItems.ForEach(x => addMarkerMenuItem.DropDownItems.Add(x.ImageKey, x.Image, AddMarkerItem_Click));

            var addRegionMenuItem = new ToolStripMenuItem("Добавить регион");
            addRegionMenuItem.Click += AddRegionItem_Click;

            var editMenuItem = new ToolStripMenuItem("Редактировать маркер");
            editMenuItem.Click += EditMarkerItem_Click;

            var replaceMenuItem = new ToolStripMenuItem("Переместить маркер");
            replaceMenuItem.Click += ReplaceMarkerItem_Click;

            var removeMarkerMenuItem = new ToolStripMenuItem("Удалить маркер");
            removeMarkerMenuItem.Click += RemoveMarkerItem_Click;

            var removeRegionMenuItem = new ToolStripMenuItem("Удалить маркер");
            removeRegionMenuItem.Click += RemoveMarkerItem_Click;

            var menuItems = new ToolStripMenuItem[1];

            switch (target)
            {
                case ClickTarget.Map:
                    menuItems = new ToolStripMenuItem[] { addMarkerMenuItem, addRegionMenuItem };
                    break;
                case ClickTarget.Marker:
                    menuItems = new ToolStripMenuItem[] { editMenuItem, replaceMenuItem, removeMarkerMenuItem };
                    break;
                case ClickTarget.Region:
                    menuItems = new ToolStripMenuItem[] { addMarkerMenuItem };
                    break;
                default:
                    break;
            }

            _menu.Items.AddRange(menuItems);
            _menu.Show(pbMap, _clickedLocation);
        }

        private void LoadDrawableItems()
        {
            try
            {
                var allMarkers = DbHelper.GetInstance().ExpertMapDataSet.Marker;
                var delta = CurrentDelta;

                foreach (var item in allMarkers)
                {
                    var imageItem = _imageItems.Where(x => x.ImageKey == item.ImageName).FirstOrDefault() ??
                        _imageItems.First();

                    CreateMarker(imageItem.Image, imageItem.ImageKey, item.X, item.Y);
                }

                var allRegions = DbHelper.GetInstance().ExpertMapDataSet.Region;

                foreach (var rgRow in allRegions)
                {
                    var points = DbHelper.GetInstance().ExpertMapDataSet.RegionPoints.OrderBy(x => x.Number).Select(x => new Point(x.X, x.Y)).ToList();

                    var rect = Drawer.GetRectangleFromPoints(points.ToArray());
                    CreateRegion(rgRow.Id, rgRow.Name, rect, points);
                }

                CurrentDrawer.DrawItems(pbMap.CreateGraphics());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private Marker CreateMarker(Image image, string imageName, int X, int Y)
        {
            var Marker = new Marker(image, imageName, new Point(X, Y));
            Marker.Opacity = _opacity;
            CurrentDrawer.DrawableItems.Add(Marker);
            return Marker;
        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                CurrentDrawer.DrawItems(e.Graphics);
                if (_drawningRegion)
                {
                    e.Graphics.DrawRectangle(Pens.Black, _regionRectangle);
                }
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
            var menuItem = (sender as ToolStripMenuItem);

            var center = new Point(_clickedLocation.X - menuItem.Image.Width / 2, _clickedLocation.Y - menuItem.Image.Height / 2);
            var location = Drawer.ModifyToBasePoint(center, CurrentDelta);
            
            var marker = CreateMarker(menuItem.Image, menuItem.Text, location.X, location.Y);
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

        private void RemoveRegionItem_Click(object sender, EventArgs e)
        {

        }

        private void AddRegionItem_Click(object sender, EventArgs e)
        {
            pbMap.Cursor = Cursors.Cross;
            _canDrawRegion = true;
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
                    else if (item is ExpertMap.Models.Region)
                    {
                        ShowContextMenu(ClickTarget.Region);
                    }
                }
                else
                    ShowContextMenu(ClickTarget.Map);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && _drag)
            {
                var marker = (_clickedObject as Marker);

                marker.DefaultLocation = Drawer.ModifyToBasePoint(
                    new Point(marker.Rectangle.Location.X /*+ marker.Rectangle.Width / 2*/,
                              marker.Rectangle.Location.Y /*+ marker.Rectangle.Height / 2*/),
                    CurrentDelta);

                _drag = false;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && _drawningRegion)
            {
                RegionListForm form = new RegionListForm(true);

                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var points = Drawer.GetRectanglePoints(_regionRectangle);
                    List<Point> dbPoints = new List<Point>();

                    for (int i = 0; i < points.Length; i++)
                    {
                        dbPoints.Add(Drawer.ModifyToBasePoint(points[i], CurrentDelta));
                    }

                    var reg = form.SelectedRegion;

                    try
                    {
                        DbHelper.GetInstance().SaveRegionPoints(CreateRegion(reg.RegionId, reg.RegionName, _regionRectangle, dbPoints));
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }

                }
                
                CancelRegionDrawning();
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
            if (_drawningRegion)
            {
                _regionRectangle = CurrentDrawer.GetDrawableRectangle(_clickedLocation, e.Location);
                pbMap.Invalidate();//_regionRectangle
            }

            ExpertMap.Models.Region region = null;

            if (CurrentDrawer.TryGetRegion(e.Location, out region))
                tslRegionName.Text = region.RegionName;
            else
                tslRegionName.Text = string.Empty;
            
        }

        private void tsmExpert_Click(object sender, EventArgs e)
        {
            ExpertTableForm form = new ExpertTableForm();
            form.ShowDialog();
        }

        private void tsmCountry_Click(object sender, EventArgs e)
        {
            CountryListForm form = new CountryListForm();
            form.ShowDialog();
        }

        private void tsmSpecialization_Click(object sender, EventArgs e)
        {
            SpecializationListForm form = new SpecializationListForm();
            form.ShowDialog();
        }

        private void tsmRegion_Click(object sender, EventArgs e)
        {
            RegionListForm form = new RegionListForm();
            form.ShowDialog();
        }

        private void pbMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && _canDrawRegion)
            {
                _clickedLocation = e.Location;
                _drawningRegion = true;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((_canDrawRegion || _drawningRegion) && e.KeyCode == Keys.Escape)
            {
                CancelRegionDrawning();
            }
        }

        private void CancelRegionDrawning()
        {
            _canDrawRegion = false;
            _drawningRegion = false;
            pbMap.Cursor = Cursors.Default;
            pbMap.Invalidate();
        }

        private ExpertMap.Models.Region CreateRegion(int regionId,string regionName, Rectangle rect, List<Point> points)
        {
            var region = new ExpertMap.Models.Region(rect, regionId, regionName);
            region.Points = points;
            region.Opacity = _opacity;
            CurrentDrawer.DrawableItems.Add(region);
            return region;
        }
    }
}
