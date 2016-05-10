using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TollManagement.Common;
using TollManagement.Data;
using TollTicketManagement.Common;
using TollTicketManagement.Controller;
using TollTicketManagement.Model;

namespace TollTicketManagement.View
{
    /// <summary>
    ///     Interaction logic for EquipmentStatusView.xaml
    /// </summary>
    public partial class EquipmentStatusView : Window
    {
        private EquipmentStatus_Ctrl CtrlEnquipmentStatus = new EquipmentStatus_Ctrl();
        private Station_Ctrl CtrlStation = new Station_Ctrl();
        private Config_Ctrl _ConfigController;
        private ColumnDefinition _col;
        private string _idStation;
        private RowDefinition _row;
        private string _sImgSize;
        private int nHeighFirstRow = 60;
        private int nRow = 8;
        private int nWidthFirstCol = 100;
        private DispatcherTimer timer = new DispatcherTimer();

        public EquipmentStatusView()
        {
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var closeButton = GetTemplateChild("closeButton") as Button;
                if (closeButton != null)
                    closeButton.Click += CloseClick;

                cbStation.ItemsSource = CtrlStation.GetAllStation();
                cbStation.DisplayMemberPath = "Name";
                cbStation.SelectedValuePath = "StationID";
                cbStation.SelectedIndex = 0;

                _ConfigController = new Config_Ctrl();
                SupervisionConfigModel model = _ConfigController.GetSupervisionConfig();
                cbStation.SelectedValue = model.StationCode;
                LoadUI();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            if (timer.Dispatcher.Thread.IsAlive)
                timer.Stop();
            Close();
        }

        private void LoadUI()
        {
            try
            {
                _idStation = Utility.GetComBoxSelectedValue(cbStation);
                List<sp_LS_Lane_Station_GetInformation_Result> listItemLaneStation =
                    CtrlEnquipmentStatus.getInformation_Lane_Station(_idStation);
                if (listItemLaneStation == null)
                {
                    MessageBox.Show("Không lấy được thông tin trạm", "Thông báo !");
                    return;
                }
                DrawLane(listItemLaneStation);
                AddHeaderAndValueRow(listItemLaneStation);
                LoadStatusDeviceLane(listItemLaneStation);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." +
                        MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." +
                        MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }

        private void cbStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadUI();
        }

        private void LoadStatusDeviceLane(List<sp_LS_Lane_Station_GetInformation_Result> ListItemLane_Station)
        {
            //declare available          

            int nLane = ListItemLane_Station.Count; // dgv.Items.Count;
            var arrCodeLane = new string[nLane];

            //for get each codelane
            for (int i = 0; i < nLane; i++)
            {
                arrCodeLane[i] = ListItemLane_Station[i].codeLane;
            }
            // Insert Imformation
            for (int j = 0; j < nLane; j++)
            {
                List<sp_LS_Lane_Devices_GetInformation_Result> list =
                    CtrlEnquipmentStatus.getInformation_Lane_Devices(arrCodeLane[j]);
                //for (int i = 0; i < nRow - 1 && i < list.Count; i++)
                for (int i = 0; i < nRow - 1; i++)
                {
                    TextBlock txtBlock = CreateTextBlock("", 0, 0);
                    if (j%2 == 0)
                    {
                        Rectangle recBG = CreateRectangleBackGround(Colors.LightCyan, i + 1, j + 1);
                        grdDynamicGrid.Children.Add(recBG);
                    }
                    //Insert Status
                    try
                    {
                        if (ListItemLane_Station[j].isUseLane == true && list.Count > 0 && i < list.Count)
                        {
                            int stt = 6;
                            if (list[i].DeviceIDDVlane.ToString().Substring(0, 2).Equals("PC")) //Computer
                            {
                                stt = 0;
                            }
                            if (list[i].DeviceIDDVlane.ToString().Substring(0, 2).Equals("SV")) //Server
                            {
                                stt = 1;
                            }
                            if (list[i].DeviceIDDVlane.ToString().Substring(0, 2).Equals("RE")) //Recoder
                            {
                                stt = 2;
                            }
                            if (list[i].DeviceIDDVlane.ToString().Substring(0, 2).Equals("PR")) //Printer
                            {
                                stt = 3;
                            }
                            if (list[i].DeviceIDDVlane.ToString().Substring(0, 2).Equals("PL"))//PLC
                            {
                                stt = 4;
                            }
                            if (list[i].DeviceIDDVlane.ToString().Substring(0, 2).Equals("C1"))//Card Issuer 1
                            {
                                stt = 5;
                            }
                            if (list[i].DeviceIDDVlane.ToString().Substring(0, 2).Equals("C2"))//Card Issuer 2
                            {
                                stt = 6;
                            }

                            for (int c = 0; c < nRow - 1; c++)
                            {
                                if (c == stt)
                                {
                                    if (list[i].StatusDVs == 1)
                                    {
                                        Image Image = CreateImage("Resources/Images/green_light" + _sImgSize + ".png",
                                            int.Parse(_sImgSize), int.Parse(_sImgSize), c + 1, j + 1);
                                        Image.ToolTip = "ID: " + "\n" + list[i].DeviceIDDVlane.ToString();
                                        Image.HorizontalAlignment = HorizontalAlignment.Center;
                                        Image.VerticalAlignment = VerticalAlignment.Center;
                                        grdDynamicGrid.Children.Add(Image);
                                        break;
                                    }
                                    else if (list[i].StatusDVs == 0)
                                    {
                                        Image Image = CreateImage("Resources/Images/red_light" + _sImgSize + ".png",
                                            int.Parse(_sImgSize), int.Parse(_sImgSize), c + 1, j + 1);
                                        Image.ToolTip = "ID: " + "\n" + list[i].DeviceIDDVlane.ToString();
                                        Image.HorizontalAlignment = HorizontalAlignment.Center;
                                        Image.VerticalAlignment = VerticalAlignment.Center;
                                        grdDynamicGrid.Children.Add(Image);
                                        break;
                                    }
                                    else
                                    {
                                        Image Image = CreateImage("Resources/Images/yellow_light" + _sImgSize + ".png",
                                            int.Parse(_sImgSize), int.Parse(_sImgSize), c + 1, j + 1);
                                        Image.ToolTip = "ID: " + "\n" + list[i].DeviceIDDVlane.ToString();
                                        Image.HorizontalAlignment = HorizontalAlignment.Center;
                                        Image.VerticalAlignment = VerticalAlignment.Center;
                                        grdDynamicGrid.Children.Add(Image);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // fill red for Lane Close
                            for (int k = 0; k < nRow; k++)
                            {
                                Rectangle recBG = CreateRectangleBackGround(Colors.Tomato, k, j + 1);
                                grdDynamicGrid.Children.Add(recBG);
                            }
                            if (ListItemLane_Station[j].typeLane == 0)
                            {
                                TextBlock txtBlockStyteLane =
                                    CreateTextBlock(("LANE " + (j + 1) + Environment.NewLine + " (MTC)"), 0, j + 1);
                                grdDynamicGrid.Children.Add(txtBlockStyteLane);
                            }
                            else
                            {
                                TextBlock txtBlockStyteLane =
                                    CreateTextBlock(("LANE " + (j + 1) + Environment.NewLine + " (ETC)"), 0, j + 1);
                                grdDynamicGrid.Children.Add(txtBlockStyteLane);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                        {
                            LogUtility.WriteLogFile(
                                MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                                ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                        }
                        else
                        {
                            LogUtility.WriteLogFile(
                                MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                                ex.Message);
                        }
                    }
                }
            }
        }

        private void AddHeaderAndValueRow(List<sp_LS_Lane_Station_GetInformation_Result> listItemLaneStation)
        {
            try
            {
                int nLane = listItemLaneStation.Count;
                for (int i = 0; i < nLane; i++)
                {
                    if (i%2 == 0)
                    {
                        Rectangle recBG = CreateRectangleBackGround(Colors.LightCyan, 0, i + 1);
                        grdDynamicGrid.Children.Add(recBG);
                    }
                    if (listItemLaneStation[i].typeLane == 0)
                    {
                        TextBlock txtBlockStyteLane =
                            CreateTextBlock(("LÀN " + (i + 1) + Environment.NewLine + " (MTC)"), 0, i + 1);
                        grdDynamicGrid.Children.Add(txtBlockStyteLane);
                    }
                    else
                    {
                        TextBlock txtBlockStyteLane =
                            CreateTextBlock(("LÀN " + (i + 1) + Environment.NewLine + " (ETC)"), 0, i + 1);
                        grdDynamicGrid.Children.Add(txtBlockStyteLane);
                    }
                }
                // Create value Row
                for (int i = 0; i < nRow; i++)
                {
                    TextBlock txtBlock;

                    //truong hop binh thuong
                    if (i == 1)
                    {
                        Image Image = CreateImage("Resources/Images/computer.ico", 32, 32, i, 0);
                        Image.HorizontalAlignment = HorizontalAlignment.Center;
                        Image.VerticalAlignment = VerticalAlignment.Center;
                        Rectangle recBG = CreateRectangleBackGround(Colors.White, i, 0);
                        grdDynamicGrid.Children.Add(recBG);
                        txtBlock = CreateTextBlock("MÁY TÍNH LÀN", i, 0);
                        txtBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        grdDynamicGrid.Children.Add(txtBlock);
                        grdDynamicGrid.Children.Add(Image);
                    }

                    //truong hop thong thuong
                    if (i == 2)
                    {
                        Image Image = CreateImage("Resources/Images/server32.png", 32, 32, i, 0);
                        Image.HorizontalAlignment = HorizontalAlignment.Center;
                        Image.VerticalAlignment = VerticalAlignment.Center;
                        Rectangle recBG = CreateRectangleBackGround(Colors.White, i, 0);
                        grdDynamicGrid.Children.Add(recBG);
                        txtBlock = CreateTextBlock("MÁY CHỦ", i, 0);
                        txtBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        grdDynamicGrid.Children.Add(txtBlock);
                        grdDynamicGrid.Children.Add(Image);
                    }

                    //truong hop binh thuong
                    if (i == 3)
                    {
                        Image Image = CreateImage("Resources/Images/hdd.ico", 32, 32, i, 0);
                        Image.HorizontalAlignment = HorizontalAlignment.Center;
                        Image.VerticalAlignment = VerticalAlignment.Center;
                        Rectangle recBG = CreateRectangleBackGround(Colors.White, i, 0);
                        grdDynamicGrid.Children.Add(recBG);
                        txtBlock = CreateTextBlock("ĐẦU GHI", i, 0);
                        txtBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        grdDynamicGrid.Children.Add(txtBlock);
                        grdDynamicGrid.Children.Add(Image);
                    }

                    //trường hợp bình thường
                    if (i == 4)
                    {
                        Image Image = CreateImage("Resources/Images/Printer-icon.png", 32, 32, i, 0);

                        Rectangle recBG = CreateRectangleBackGround(Colors.White, i, 0);
                        //Grid.SetRow(recBG, i);
                        //Grid.SetColumn(recBG, 0);
                        grdDynamicGrid.Children.Add(recBG);
                        txtBlock = CreateTextBlock("MÁY IN", i, 0);
                        txtBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        grdDynamicGrid.Children.Add(txtBlock);
                        grdDynamicGrid.Children.Add(Image);
                    }

                    //trường hợp bình thường
                    if (i == 5)
                    {
                        Image Image = CreateImage("Resources/Images/lane-icon.png", 32, 32, i, 0);

                        Rectangle recBG = CreateRectangleBackGround(Colors.White, i, 0);
                        //Grid.SetRow(recBG, i);
                        //Grid.SetColumn(recBG, 0);
                        grdDynamicGrid.Children.Add(recBG);
                        txtBlock = CreateTextBlock("LÀN XE", i, 0);
                        txtBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        grdDynamicGrid.Children.Add(txtBlock);
                        grdDynamicGrid.Children.Add(Image);
                    }

                    //trường hợp bình thường
                    if (i == 6)
                    {
                        Image Image = CreateImage("Resources/Images/card_reader.ico", 32, 32, i, 0);

                        Rectangle recBG = CreateRectangleBackGround(Colors.White, i, 0);
                        //Grid.SetRow(recBG, i);
                        //Grid.SetColumn(recBG, 0);
                        grdDynamicGrid.Children.Add(recBG);
                        txtBlock = CreateTextBlock("MÁY PHÁT THẺ 1", i, 0);
                        txtBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        grdDynamicGrid.Children.Add(txtBlock);
                        grdDynamicGrid.Children.Add(Image);
                    }
                    //trường hợp bình thường
                    if (i == 7)
                    {
                        Image Image = CreateImage("Resources/Images/card_reader.ico", 32, 32, i, 0);

                        Rectangle recBG = CreateRectangleBackGround(Colors.White, i, 0);
                        //Grid.SetRow(recBG, i);
                        //Grid.SetColumn(recBG, 0);
                        grdDynamicGrid.Children.Add(recBG);
                        txtBlock = CreateTextBlock("MÁY PHÁT THẺ 2", i, 0);
                        txtBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        grdDynamicGrid.Children.Add(txtBlock);
                        grdDynamicGrid.Children.Add(Image);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." +
                        MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." +
                        MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }

        private void DrawLane(List<sp_LS_Lane_Station_GetInformation_Result> listItemLaneStation)
        {
            try
            {
                int countMTC = 0;
                int countETC = 0;
                int countActiveLane = 0;
                double nWidth = GridMain.ActualWidth;
                double nHeigh = GridMain.ActualHeight;
                double nHeighRowLoadData = nHeigh - LastRow.ActualHeight - 50;
                
                int nLane = listItemLaneStation.Count;

                //Set defaut of grid    
                grdDynamicGrid.Children.Clear();
                grdDynamicGrid.RowDefinitions.Clear();
                grdDynamicGrid.ColumnDefinitions.Clear();
                grdDynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
                grdDynamicGrid.VerticalAlignment = VerticalAlignment.Top;
                grdDynamicGrid.ShowGridLines = true;
                grdDynamicGrid.Background = new SolidColorBrush(Colors.LavenderBlush);

                //Set total lane
                txtQuantityTotal.Text = nLane.ToString();

                //count Active Lane
                for (int i = 0; i <= nLane - 1; i++)
                {
                    if (listItemLaneStation[i].isUseLane == true)
                    {
                        countActiveLane++;
                    }
                }
                txtQuantityActive.Text = countActiveLane.ToString();
                //Set size image
                if (10 <= countActiveLane)
                {
                    _sImgSize = "64";
                }
                else
                {
                    _sImgSize = "48";
                }
                // count MTC and ETC
                for (int i = 0; i <= nLane - 1; i++)
                {
                    if (listItemLaneStation[i].typeLane == 0)
                        countMTC++;
                    else
                        countETC++;
                }

                txtQuantityMTC.Text = countMTC.ToString();
                txtQuantityETC.Text = countETC.ToString();
                // Create Columns         
                for (int i = 0; i < nLane + 1; i++)
                {
                    _col = new ColumnDefinition();
                    _col.Name = "Col" + i;
                    if (i == 0)
                    {
                        _col.Width = new GridLength(nWidthFirstCol);
                    }
                    else
                    {
                        _col.Width = new GridLength((nWidth - nWidthFirstCol)/(nLane));
                    }
                    grdDynamicGrid.ColumnDefinitions.Add(_col);
                }
                // Create Rows
                for (int i = 0; i < nRow; i++)
                {
                    _row = new RowDefinition();
                    _row.Name = "Row" + i;
                    if (i == 0)
                    {
                        _row.Height = new GridLength(nHeighFirstRow);
                    }
                    else
                    {
                        _row.Height = new GridLength((nHeighRowLoadData - nHeighFirstRow)/7);
                    }
                    grdDynamicGrid.RowDefinitions.Add(_row);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." +
                        MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." +
                        MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }

        private TextBlock CreateTextBlock(string textContent, int row, int column)
        {
            var txtBlock = new TextBlock();
            try
            {
                txtBlock.Text = textContent;
                txtBlock.FontSize = 12;
                txtBlock.FontWeight = FontWeights.Bold;
                txtBlock.Foreground = new SolidColorBrush(Colors.Black);
                txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
                txtBlock.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(txtBlock, row);
                Grid.SetColumn(txtBlock, column);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
            return txtBlock;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //Remove status Image
                //grdDynamicGrid.Children.RemoveRange(35, 103);
                grdDynamicGrid.Children.Clear();
                List<sp_LS_Lane_Station_GetInformation_Result> listItemLaneStation =
                    CtrlEnquipmentStatus.getInformation_Lane_Station(_idStation);
                if (listItemLaneStation == null)
                {
                    MessageBox.Show("Không lấy được thông tin trạm", "Thông báo !");
                    return;
                }
                DrawLane(listItemLaneStation);
                AddHeaderAndValueRow(listItemLaneStation);
                LoadStatusDeviceLane(listItemLaneStation);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private void autoTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                string sPid = autoTime.Text;
                if (int.Parse(sPid) > 0)
                {
                    timer.Tick += timer_Tick;
                    timer.Interval = new TimeSpan(0, 0, int.Parse(sPid));
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private Image CreateImage(string path, int width, int height, int row, int column)
        {
            try
            {
                var ImgGreen = new Image();
                ImgGreen.Width = width;
                ImgGreen.Height = height;
                Grid.SetRow(ImgGreen, row);
                Grid.SetColumn(ImgGreen, column);
                var bi = new BitmapImage();
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                bi.BeginInit();
                bi.UriSource = new Uri(@"/TollTicketManagement;component/" + path, UriKind.RelativeOrAbsolute);
                bi.EndInit();
                // Set the image source.
                ImgGreen.Source = bi;
                return ImgGreen;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
                return null;
            }
        }

        private Rectangle CreateRectangleBackGround(Color color, int row, int column)
        {
            var rec = new Rectangle();
            try
            {
                rec.Fill = new SolidColorBrush(color);
                Grid.SetRow(rec, row);
                Grid.SetColumn(rec, column);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
            return rec;
        }

        private void EquipmentStatusView_OnClosed(object sender, EventArgs e)
        {
            Close();
        }
    }
}