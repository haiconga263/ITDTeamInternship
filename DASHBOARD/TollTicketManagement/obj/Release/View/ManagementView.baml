   M S B A M L   `   `   `  ����   TollTicketManagement)    #TollTicketManagement.ManagementView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -      CustomDialog#��[    � Title$  SUPERVISION CENTER��$
��1280��$
��auto�� � Icon$ /Resources/Images/itd.ico�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=�.���� -   $��
mainSpanel��.+��  � RowDefinitions �� $��55 ��� $��35 ��� $��5 ��� $
��auto �$��32��.+��� -    ��Name$ txtTitle��$��QUẢN LÝ THẺ��$��0��$��41(� �� TextAlignment$ Center=�$��Center=�  ListViewTitleStyle#��[ $��0q�$��55��$
��1270��� $��1�� �� $
��auto �$��32�� � ColumnDefinitions �� $	��150 ��� $��90 ��� $	��150 ��� $��40 ��� $	��150 ��� $��10 ��� $	��100 ��� $	��150 ��� $	��150 �.+��� $��Từ ngày: ��$��18(�$��1��$��Center=�(  "System.Windows.Controls.DatePicker  -     Name$ dtpFromDate��$��18(�$��2��$��0��	 � IsSharedSizeScope	 . ��. $��Stretch=�
   FirstDayOfWeek$
 Monday=��� $
��Ca: ��$��18(�$��3��$��Center=�$��Center=��� -    ��Name$ cbShift��$��4��$��0��$��14(�$��2q�$��Stretch=��� -    ��Name$ chkRealTime��$��Trực tuyến�����#E0E0E0$��18(�$��Center=�$��Center=��� -    ��Name$ 	btnSearch��$��90��  NormalButton#��[ $��Thống kê��$
��Left=�$��18(�$
��Auto��$��6���� $��Tồn toàn tuyến: ��$��18(�$��7��$��Center=�$��Center=��� -   $��txtSumInStock��$��18(�$��8��$��Center=�� -	   $��mainGrid��$��3��.+�&   System.Windows.Controls.DataGrid  -
     Name$ dgvListSearchResult��$��Center=�  CustomDataGridStyle#��[  # Body_Content_DataGrid_Centering   	CellStyle# [    GridLinesVisibility$ Vertical=�$��0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Trạm��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 85    
FontWeight$
 Bold"�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *StationName+   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value$
 Left=���  � ��$ Center=�  $ Làn 01��$	 50*  �� *Lane01+ �� StringFormat$ {0:N0}��  $ Làn 02��$	 50*  �� *Lane02+$ {0:N0}��  $ Làn 03��$	 50*  �� *Lane03+$ {0:N0}��  $ Làn 04��$	 50*  �� *Lane04+$ {0:N0}��  $ Làn 05��$	 50*  �� *Lane05+$ {0:N0}��  $ Làn 06��$	 50*  �� *Lane06+$ {0:N0}��  $ Làn 07��$	 50*  �� *Lane07+$ {0:N0}��  $ Làn 08��$	 50*  �� *Lane08+$ {0:N0}��  $ Làn 09��$	 50*  �� *Lane09+$ {0:N0}��  $ Làn 10��$	 50*  �� *Lane10+$ {0:N0}��  $ Làn 11��$	 50*  �� *Lane11+$ {0:N0}��  $ Làn 12��$	 50*  �� *Lane12+$ {0:N0}��  $ Làn 13��$	 50*  �� *Lane13+$ {0:N0}��  $ Làn 14��$	 50*  �� *Lane14+$ {0:N0}��  $ Làn 15��$	 50*  �� *Lane15+$ {0:N0}��  $ Làn 16��$	 50*  �� *Lane16+$ {0:N0}��  $ Tổng vào��$	 55* $
 Bold"� �� *SumIn+$ {0:N0}��  $ Tồn vào��$	 55* $
 Bold"� �� *	InInstock+$ {0:N0}��  $ 
Tổng ra��$	 55* $
 Bold"� �� *SumOut+$ {0:N0}��  $ Tổng xuất��$	 55* $
 Bold"� �� *
InExport+$ {0:N0}��  $ Tồn trạm��$	 55* $
 Bold"� �� *	InStock+$ {0:N0}��