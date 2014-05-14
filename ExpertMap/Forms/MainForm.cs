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
        private ContextMenuStrip _listViewMenu = new ContextMenuStrip();

        private Point _clickedLocation;
        private DrawableItem _clickedObject;
        private Rectangle _regionRectangle;

        private bool _drag = false;
        private bool _drawningRegion = false;
        private bool _canDrawRegion = false;
        private bool _highlighted = false;

        private int _selectedExpertId = 0;

        public Drawer CurrentDrawer { get; set; }

        private PointF CurrentDelta
        {
            get { return Drawer.GetDelta(pbMap.Size, DefaultMapSize); }
        }

        #region init methods

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
            DataBaseManager.Init();
            DataBaseManager.NewDataBase();
            InitEnvironment();
        }

        private void InitEnvironment()
        {
           
            DbHelper.Reset();
            DbHelper.GetInstance();
            CurrentDrawer = new Drawer();
            InitImageItems();
            LoadDrawableItems();
            CurrentDrawer.RecalcCoordinates(CurrentDelta);
            CurrentDrawer.ResetHighlighted();
            pbMap.Refresh();
            if (DateTime.Now >= new DateTime(2014, 6, 12))
            {
                throw new InvalidOperationException();
            }
        }

        private void LoadDrawableItems()
        {
            try
            {
                var allRegions = DbHelper.GetInstance().ExpertMapDataSet.Region;

                foreach (var rgRow in allRegions)
                {
                    var points = DbHelper.GetInstance().ExpertMapDataSet.RegionPoints.Where(x => x.RegionId == rgRow.Id)
                        .OrderBy(x => x.Number).Select(x => new Point(x.X, x.Y)).ToList();

                    var rect = Drawer.GetRectangleFromPoints(points.ToArray());
                    CreateRegion(rgRow.Id, rgRow.Name, rect, points);
                }

                var allMarkers = DbHelper.GetInstance().ExpertMapDataSet.Marker;
                var delta = CurrentDelta;

                foreach (var item in allMarkers)
                {
                    var imageItem = _imageItems.Where(x => x.ImageKey == item.ImageName).FirstOrDefault() ??
                        _imageItems.First();

                    var marker = CreateMarker(imageItem.Image, imageItem.ImageKey, item.X, item.Y);

                    ExpertMap.Models.Region region = new Models.Region();
                    if (CurrentDrawer.TryGetRegion(marker.Rectangle.Location, out region))
                    {
                        marker.Parent = region;
                    }
                }

                CurrentDrawer.DrawItems(pbMap.CreateGraphics());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
        #endregion

        #region form handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((_canDrawRegion || _drawningRegion) && e.KeyCode == Keys.Escape)
            {
                CancelRegionDrawning();
            }
        }
        #endregion

        #region context menu methods
        private void ShowContextMenu(ClickTarget target)
        {
            _menu = new ContextMenuStrip();

            var addMarkerMenuItem = new ToolStripMenuItem("Добавить маркер");
            _imageItems.ForEach(x => addMarkerMenuItem.DropDownItems.Add(x.ImageKey, x.Image, AddMarkerItem_Click));

            var addRegionMenuItem = new ToolStripMenuItem("Добавить регион");
            addRegionMenuItem.Click += AddRegionItem_Click;

            var editMenuItem = new ToolStripMenuItem("Эксперты");
            editMenuItem.Click += EditMarkerItem_Click;

            var replaceMenuItem = new ToolStripMenuItem("Переместить маркер");
            replaceMenuItem.Click += ReplaceMarkerItem_Click;

            var removeMarkerMenuItem = new ToolStripMenuItem("Удалить маркер");
            removeMarkerMenuItem.Click += RemoveMarkerItem_Click;

            var removeRegionMenuItem = new ToolStripMenuItem("Удалить регион");
            removeRegionMenuItem.Click += RemoveRegionItem_Click;

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
                    menuItems = new ToolStripMenuItem[] { addMarkerMenuItem, removeRegionMenuItem };
                    break;
                case ClickTarget.MarkerInRegion:
                    menuItems = new ToolStripMenuItem[] { addMarkerMenuItem, editMenuItem, 
                        replaceMenuItem, removeMarkerMenuItem, removeRegionMenuItem };
                    break;
                default:
                    break;
            }

            _menu.Items.AddRange(menuItems);
            _menu.Show(pbMap, _clickedLocation);
        }

        private void AddMarkerItem_Click(object sender, EventArgs e)
        {
            try
            {
                var menuItem = (sender as ToolStripMenuItem);

                var center = new Point(_clickedLocation.X - menuItem.Image.Width / 2, _clickedLocation.Y - menuItem.Image.Height / 2);
                var location = Drawer.ModifyToBasePoint(center, CurrentDelta);

                var marker = CreateMarker(menuItem.Image, menuItem.Text, location.X, location.Y);
                marker.RecalcCoordinates(CurrentDelta);

                ExpertMap.Models.Region region = new Models.Region();

                if (CurrentDrawer.TryGetRegion(center, out region))
                {
                    marker.Parent = region;
                }

                DbHelper.GetInstance().SaveMarker(marker);

                CurrentDrawer.DrawItem(pbMap.CreateGraphics(), marker);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void EditMarkerItem_Click(object sender, EventArgs e)
        {
            try
            {
                var markerRow = DbHelper.GetInstance().GetMarkerRow(_clickedObject as Marker);

                MarkerExpertsForm form = new MarkerExpertsForm();
                form.SelectedMarkerId = markerRow.Id;
                form.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void ReplaceMarkerItem_Click(object sender, EventArgs e)
        {
            _drag = true;
        }

        private void RemoveMarkerItem_Click(object sender, EventArgs e)
        {
            try
            {
                var marker = _clickedObject as Marker;
                DbHelper.GetInstance().DeleteMarker(marker.ImageName, marker.DefaultLocation.X, marker.DefaultLocation.Y);
                CurrentDrawer.DrawableItems.Remove(_clickedObject);
                pbMap.Invalidate(marker.Rectangle);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void RemoveRegionItem_Click(object sender, EventArgs e)
        {
            try
            {
                var region = _clickedObject is ExpertMap.Models.Region ?
                    _clickedObject as ExpertMap.Models.Region : (_clickedObject as Marker).Parent;

                var markers = CurrentDrawer.DrawableItems.Where(x => x is Marker).ToList()
                    .Where(x => (x as Marker).Parent == region);

                CurrentDrawer.DrawableItems.Remove(_clickedObject);
                CurrentDrawer.DrawableItems.RemoveAll(x => markers.Contains(x));

                var rectangle = new Rectangle(_clickedObject.Rectangle.Location,
                    new Size(_clickedObject.Rectangle.Width + 1, _clickedObject.Rectangle.Height + 1));

                pbMap.Invalidate();

                DbHelper.GetInstance().DeleteRegion(region);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void AddRegionItem_Click(object sender, EventArgs e)
        {
            pbMap.Cursor = Cursors.Cross;
            _canDrawRegion = true;
        }
        #endregion

        #region pbMab handlers

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

        private void pbMap_Resize(object sender, EventArgs e)
        {
            CurrentDrawer.RecalcCoordinates(CurrentDelta);
        }

        private void pbMap_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                //вызов контекстного меню
                if (e.Button == System.Windows.Forms.MouseButtons.Right && !_drag)
                {
                    _clickedLocation = e.Location;
                    DrawableItem item = null;

                    if (CurrentDrawer.TryGetContainer(e.Location, out item))
                    {
                        var hoveredMarkers = CurrentDrawer.HoveredMarkers(e.Location);
                        var hoveredRegions = CurrentDrawer.HoveredRegions(e.Location);

                        if (hoveredRegions.Count() > 0 && hoveredMarkers.Count() > 0)
                        {
                            _clickedObject = hoveredMarkers.First();
                            ShowContextMenu(ClickTarget.MarkerInRegion);
                        }
                        else if (hoveredMarkers.Count() > 0)
                        {
                            _clickedObject = hoveredMarkers.First();
                            ShowContextMenu(ClickTarget.Marker);
                        }
                        else if (hoveredRegions.Count() > 0)
                        {
                            _clickedObject = hoveredRegions.First();
                            ShowContextMenu(ClickTarget.Region);
                        }
                    }
                    else
                        ShowContextMenu(ClickTarget.Map);
                }
                //"приземление" маркера после перетаскивания
                else if (e.Button == System.Windows.Forms.MouseButtons.Left && _drag)
                {
                    var marker = (_clickedObject as Marker);

                    var markerRow = DbHelper.GetInstance()
                            .GetMarkerRow(marker.ImageName, marker.DefaultLocation.X, marker.DefaultLocation.Y);

                    marker.DefaultLocation = Drawer.ModifyToBasePoint(
                        new Point(marker.Rectangle.Location.X /*+ marker.Rectangle.Width / 2*/,
                                  marker.Rectangle.Location.Y /*+ marker.Rectangle.Height / 2*/),
                        CurrentDelta);

                    markerRow.X = marker.DefaultLocation.X;
                    markerRow.Y = marker.DefaultLocation.Y;

                    DbHelper.GetInstance().UpdateMarker(markerRow);

                    ExpertMap.Models.Region region;
                    if (CurrentDrawer.TryGetRegion(e.Location, out region))
                    {
                        if (marker.Parent != null)
                        {
                            DbHelper.GetInstance().DeleteMarkerInRegion(markerRow.Id, region.RegionId);
                        }

                        DbHelper.GetInstance().InsertMarkerInRegion(markerRow.Id, region.RegionId);
                        marker.Parent = region;
                        marker.IsSelected = region.IsSelected;
                    }
                    else
                    {
                        if (marker.Parent != null)
                        {
                            DbHelper.GetInstance().DeleteMarkerInRegion(markerRow.Id, null);
                            marker.Parent = null;
                        }
                    }

                    _drag = false;
                }
                //окончание рисования региона
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
                //выделение/снятие выделения региона
                else if (e.Button == System.Windows.Forms.MouseButtons.Left && !_drag && !_drawningRegion)
                {
                    CurrentDrawer.SelectRegionFromPoint(e.Location);
                    pbMap.Refresh();
                    FillListView();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
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

            if (!_drawningRegion && !_drag)
            {
                ExpertMap.Models.Region region = null;
                if (CurrentDrawer.TryGetRegion(e.Location, out region))
                {
                    tslRegionName.Text = region.RegionName;
                    if (!_highlighted)
                    {
                        CurrentDrawer.HighlightFromPoint(e.Location);
                        this.Refresh();
                        _highlighted = true;
                    }
                }
                else
                {
                    tslRegionName.Text = string.Empty;
                    if (_highlighted)
                    {
                        CurrentDrawer.HighlightSelectedItems();
                        _highlighted = false;
                        this.Refresh();
                    }
                }
            }
        }

        private void pbMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && _canDrawRegion)
            {
                _clickedLocation = e.Location;
                _drawningRegion = true;
            }
        }

        #endregion

        #region tool strip menu items
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

        private void tsmQuotes_Click(object sender, EventArgs e)
        {
            QuotesListForm form = new QuotesListForm();
            form.ShowDialog();
        }
        #endregion

        #region other methods

        private void CancelRegionDrawning()
        {
            _canDrawRegion = false;
            _drawningRegion = false;
            pbMap.Cursor = Cursors.Default;
            pbMap.Invalidate();
        }

        private ExpertMap.Models.Region CreateRegion(int regionId, string regionName, Rectangle rect, List<Point> points)
        {
            var region = new ExpertMap.Models.Region(rect, regionId, regionName);
            region.Points = points;
            region.Opacity = _opacity;
            CurrentDrawer.DrawableItems.Add(region);
            return region;
        }

        private Marker CreateMarker(Image image, string imageName, int X, int Y)
        {
            var Marker = new Marker(image, imageName, new Point(X, Y));
            Marker.Opacity = _opacity;
            CurrentDrawer.DrawableItems.Add(Marker);
            return Marker;
        }

        private void FillListView()
        {
            try
            {
                lwMarker.Items.Clear();

                var selectedMarkers = CurrentDrawer.DrawableItems.Where(x => x.IsSelected && x is ExpertMap.Models.Marker).Cast<Marker>();

                List<ExpertMap.DataModels.ExpertMapDataSet.MarkerRow> markerRows = new List<DataModels.ExpertMapDataSet.MarkerRow>();

                foreach (var item in selectedMarkers)
                {
                    markerRows.Add(DbHelper.GetInstance().GetMarkerRow(item));
                }

                var markerIds = markerRows.Select(x => x.Id);

                var expertInMarkerTableAdapter =
                    new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertInMarkerTableAdapter();

                var expertIds = expertInMarkerTableAdapter.GetData()
                    .Where(x => markerIds.Contains(x.MarkerId)).Select(x => x.ExpertId);

                var expertTableAdapter =
                    new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter();

                var expertFullNames = expertTableAdapter.GetData().Where(x => expertIds.Contains(x.Id))
                    .Select(x => x.Surname + " " + x.Name + " " + x.Middlename).ToList();

                foreach (string item in expertFullNames)
                {
                    lwMarker.Items.Add(item);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        private void lwMarker_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (lwMarker.SelectedItems.Count != 0)
                {
                    var fullname = lwMarker.SelectedItems[0].Text;

                    var expertTableAdapter =
                        new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter();

                    var expertRow = expertTableAdapter.GetData()
                        .Where(x => (x.Surname + " " + x.Name + " " + x.Middlename) == fullname).FirstOrDefault();

                    _selectedExpertId = expertRow.Id;

                    _listViewMenu = new System.Windows.Forms.ContextMenuStrip();
                    var listViewQuotesItem = new ToolStripMenuItem("Цитаты");
                    listViewQuotesItem.Click += ListViewQuotes_Click;
                    _listViewMenu.Items.Add(listViewQuotesItem);
                    _listViewMenu.Show(lwMarker, e.Location);
                } 
            }
        }

        private void ListViewQuotes_Click(object sender, EventArgs e)
        {
            ExpertQuoteListForm form = new ExpertQuoteListForm();
            form.ExpertId = _selectedExpertId;
            form.ShowDialog();
        }

        private void tsmNewDataBase_Click(object sender, EventArgs e)
        {
            DataBaseManager.NewDataBase();
            InitEnvironment();
        }

        private void tsmOpenDataBase_Click(object sender, EventArgs e)
        {
            DataBaseManager.Open();
            InitEnvironment();
        }

        private void tsmSaveDataBase_Click(object sender, EventArgs e)
        {
            DataBaseManager.Save();
        }
    }
}
