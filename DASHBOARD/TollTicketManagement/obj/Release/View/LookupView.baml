   M S B A M L   `   `   `  ���� X  TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  O KTollTicketManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TollTicketManagement.ModelTollTicketManagement.Model *   $TollTicketManagement.View.LookupView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     :Local(clr-namespace:TollTicketManagement.Model       � Title$  	Tra cứu��$
��1280��$	��768�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � 
ResizeMode$ CanMinimize=�   CustomWindow#��[  .���  � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+��� $��0��  ListViewTitleStyle#��[ $&�� TRA CỨU THÔNG TIN GIAO DỊCH��$��Center=�$��Center=��� $��1��  CustomTabControl#��[ $��10q�.@��� $��Thông tin tìm kiếm��.���� .+��� $��Center=�$��9�� �� Orientation$ 
Horizontal=�.+��� $��
Thông tin��$��1q�$��5q����� .R���   GroupboxTitle#��[ ���� .���  � ColumnDefinitions �� $��* ��� $��3* � �� $��* ��� $��* �.+���   NormalTextBlockAlignRight#��[ $��	Mã thẻ��$��0��$��5q�$��0����   NormalTextBox#��[ $	��150��$��1��$��0������ *
KeyMaThe+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� #��[ $��Biển số��$��0��$��5q�$��1���� #��[ $	��150��$��1��$��1������ *	KeyBienSo+$ TwoWay=�$ PropertyChanged=��� $��Thông tin loại��$��1q�$��5q����� .R��� #��[ ���� .���  �� $��* ��� $��* � �� $��* ��� $��* �	 � 	Resources	 
 �� 
TargetType �� Property �� Value��%-   '��       �� "
 ��.���  � ��$ 10q�.+���   NormalTextBlock#��[ $��Loại thẻ��$��0��$��0��$��5q���   NormalComboBox#��[ $	��100��$��1��$��0��$��5q� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ ID������ *lstCardType+ �� SelectedItem �� *SelectedItemCardType+$ TwoWay=�$ PropertyChanged=��� #��[ $��	Loại xe��$��0��$��5q�$��1���� #��[ $	��100��$��1��$��1��$��5q�$ 	ShortName��$ VehicleTypeID������ *lstVeh+ �� *SelectedItemVehicleType+$ TwoWay=�$ PropertyChanged=��� $��Thông tin trạm��$��1q�$��5q����� .R��� #��[ ���� .���  �� $��* ��� $��* ��� $
��0.5* ��� $��* ��� $��* � �� $��* ��� $��* �	 ��%-   '��       �� "
 ��.���  � ��$ 10q�.+��� $��Trạm vào��$��0��$��0���� -   $��cdStationIn��#��[ $��1��$��0��$	��150��$
 Name��$ LS_Lanes������ *
lstStation+ �� *SelectedItemStationIn+$ TwoWay=�$ PropertyChanged=��� $��	Làn vào��$��3��$��0���� #��[ $��4��$��0��$��50��$
 Name��$ LaneID������  �� ElementName$ cdStationIn�� �� Path$ SelectedValue� �� *SelectedItemLaneIn+$ TwoWay=�$ PropertyChanged=��� $��	Trạm ra��$��0��$��1���� -   $��cdStationOut��#��[ $��1��$��1��$	��150��$
 Name��$ LS_Lanes������ *
lstStation+ �� *SelectedItemStationOut+$ TwoWay=�$ PropertyChanged=��� $��Làn ra��$��3��$��1���� #��[ $��4��$��1��$��50��$
 Name��$ LaneID������ $ cdStationOut��$ SelectedValue� �� *SelectedItemLaneOut+$ TwoWay=�$ PropertyChanged=��� $��Thời gian��$��1q�$��5q����� .R��� #��[ ���� .���  �� $��* ��� $��* ��� $��* � �� $��* ��� $��* �	 ��%-   '��       �� "
 ��.���  � ��$ 10q�.+��� $��
Từ ngày��$��0��$��0��(  "System.Windows.Controls.DatePicker  $��1��$��1��$	��150��$��14(�$��Center=�   Text �� *	KeyDateIn+$ TwoWay=�$ PropertyChanged=�&    Xceed.Wpf.Toolkit.DateTimeUpDown  $��2��$��1��$	��150��$��25��   Format$ 	ShortTime=�,   &Xceed.Wpf.Toolkit.Primitives.InputBase   Text �� *	KeyTimeIn+$ TwoWay=�$ PropertyChanged=��� $��Đến ngày��$��0��$��1��  $��1��$��0��$	��150��$��14(�$��Center=� �� *
KeyDateOut+$ TwoWay=�$ PropertyChanged=�  $��2��$��0��$	��150��$��25��$ 	ShortTime=� �� *
KeyTimeOut+$ TwoWay=�$ PropertyChanged=���   NormalButton#��[ $��Tìm kiếm��$	��100��$��Right=�$��10, 10, 30, 10q����� *SearchCommand+�� $��2��#��[ $��10q�.@��� $��Thông tin giao dịch��.��&   System.Windows.Controls.DataGrid  $��10q� 	 CustomDataGridStyle#��[	 }�. ���� *DataResults+$ TwoWay=�$ PropertyChanged=� �� SelectedIndex �� *SelectedIndexDataGrid+$ TwoWay=�$ PropertyChanged=�	  
 HeaderTemplate��%U   &	
       7  �� .R��� .+��� 8��  $	��170��$��Center=�$��Center=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Loại thẻ��   HeaderTemplate# [
 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
CardType+  $ Biển số vào��# [
  �� *VehiclePlateIn+  $ Biển số ra��# [
  �� *VehiclePlateOut+  $ 	Loại xe��# [
  �� *VehicleType.ShortName+ �� StringFormat$ 
Loại {0}��  $ 	Làn vào��# [
  �� *LaneIn.Name+  $ Làn ra��# [
  �� *LaneOut.Name+  $$ Giao dịch đầu vào cuối��# [
  �� *LastCheckDateIn+  $" Giao dịch đầu ra cuối��# [
  �� *LastCheckDateOut+  $ Lộ trình��# [
  �� *
Route.Name+