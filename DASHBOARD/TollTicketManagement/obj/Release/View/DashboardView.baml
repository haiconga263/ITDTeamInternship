   M S B A M L   `   `   `  ���� O  KTollTicketManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TollTicketManagementTollTicketManagement  -    'TollTicketManagement.View.DashboardView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:TollTicketManagement     -      CustomDialog#��[    � Title$  DashboardView��$	��768��$
��1366�� � 
ResizeMode$ CanMinimize=� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=� � 	Resources .   (TollTicketManagement.IntToImageConverter  ConvertBoolToImage  StatusImage �� 	Converter/   )TollTicketManagement.IntToImageConverter2  ConvertBoolToImage2  StatusImage2/   )TollTicketManagement.IntToImageConverter3  ConvertBoolToImage3  StatusImage3��%1  &	       &	      7  &	 M     &	 R     7  &	 �     &	 �     7    �� mStatusImage��.R��� $��16��$��16��$	��3,0q����� 8     �� mStatusImage2��.R��� $��16��$��16��$	��3,0q����� 8     �� mStatusImage3��.R��� $��16��$��16��$	��3,0q����� 8   .��� -   $��
mainSpanel��$	��Top=� � RowDefinitions �� $��32 ��� $��2 ��� $��* �.+��� ���#808080$��0q����#404040$��0q�$��0��$��Bottom=�._�� $��Stretch=�$��Stretch=� � ColumnDefinitions �� $	��197 ��� $��9 ��� $	��54* ��� $	��244 ��� $��60 ��� $
��152* ��� $��70 ��� $	��117 ��� $	��62* ��� $	��154 ��� $
��237* � �� $��32 �.+��� $'��!Tổng làn đang hoạt động:��$��3��$��0��
�������$��DemiBold)�  NormalTextBlock#��[ $��24��$��18(�$	��230��$��14,8,0,3q�$
��Bold"��� -    ��Name$ txtTotalLane_IsClose��$��0,6,9,5q�$��18(�
�������$��Center=�$��45��{�.  $
��Bold"�$��Center=�$��24��$��2���� $��Tổng làn đang đóng:��$��0��$��0��
�������$
��Bold"�$��DemiBold)�#��[ $��24��$��18(�$	��187��$��10,8,0,3q��� -   $ txtTotalLane_IsOpen��$��4��$��18(�$��Center=�$��44��{�.  $
��Bold"�
�������$��Center=�$��24��$��10,6,6,5q��� $��Thời gian cập nhật:��$��9��$��0��$��14(�
�������$y�Hidden=�#��[ $��Center=�$��24��$	��148��$��3,8,3,3q�$
��Bold"��� -   $��txtLastUpdate��$��10��$��0��$��16(�
�������$y�Hidden=�#��[ $��24��$	��220��$��11,8,6,3q�$
��Bold"�� $��2�� �� $��33.33* ��� $��33.33* ��� $��33.33* � �� $	��72* ��� $	��40* ��� $	��25* �.+�&   System.Windows.Controls.DataGrid  -   $��dgvListSearchResult��$��0��$��0��$	��Top=�  CustomDataGridStyle#��[  #	 Body_Content_DataGrid_Centering	   	CellStyle#	 [	 $��DemiBold"�$��0q�
   SelectionMode$
 Extended=�   CanUserResizeRows .  $��15(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ TRẠM��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 33*    
FontWeight$
 Bold"�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *StationName+   	CellStyle ��  �� 
TargetType*	  $System.Windows.Controls.DataGridCell" 	 .���  �� Property � �� �� Value$
 Left=���  � ��$ Center=�  $
 LÀN��$	 10*  �� *
LaneCode+ �� StringFormat$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�4
  .System.Windows.Controls.DataGridTemplateColumn
  $ ĐÓNG/MỞ��$	 33*  
  CellTemplate �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+���  ��Name$	 IMG��$��Center=�$��Center=�$��20��$��20������  �� Path$ 
LaneStatus�# [   $ LƯỢNG XE��$	 31*  �� *Vol+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ MẬT ĐỘ��$	 20*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ IsAlarm�# [ 
  $ THIẾT BỊ��$	 25*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 	IsProblem�# [   -   $��dgvListSearchResult_39��$��0��$��1��$	��Top=�#��[ #	 [	 $��DemiBold"�$��0q�$
 Extended=� .  $��15(�   $ TRẠM��$	 33* $
 Bold"� �� *StationName+ �� " 	 .���  � ��$
 Left=���  � ��$ Center=�  $
 LÀN��$	 10*  �� *
LaneCode+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ ĐÓNG/MỞ��$	 33*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 
LaneStatus�# [   $ LƯỢNG XE��$	 31*  �� *Vol+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ MẬT ĐỘ��$	 20*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ IsAlarm�# [ 
  $ THIẾT BỊ��$	 25*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 	IsProblem�# [   -   $��dgvListSearchResult_38��$��1��$��2��$��2��$	��Top=�#��[ #	 [	 $��DemiBold"�$��0q�$
 Extended=� .  $��15(�   $ TRẠM��$	 33* $
 Bold"� �� *StationName+ �� " 	 .���  � ��$
 Left=���  � ��$ Center=�  $
 LÀN��$	 10*  �� *
LaneCode+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ ĐÓNG/MỞ��$	 33*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 
LaneStatus�# [   $ LƯỢNG XE��$	 31*  �� *Vol+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ MẬT ĐỘ��$	 20*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ IsAlarm�# [ 
  $ THIẾT BỊ��$	 25*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 	IsProblem�# [   -	   $��dgvListSearchResult_10��$��0��$��2��$	��Top=�#��[ #	 [	 $��DemiBold"�$��0q�$
 Extended=� .  $��15(�   $ TRẠM��$	 33* $
 Bold"� �� *StationName+ �� " 	 .���  � ��$
 Left=���  � ��$ Center=�  $
 LÀN��$	 10*  �� *
LaneCode+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ ĐÓNG/MỞ��$	 33*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 
LaneStatus�# [   $ LƯỢNG XE��$	 31*  �� *Vol+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ MẬT ĐỘ��$	 20*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ IsAlarm�# [ 
  $ THIẾT BỊ��$	 25*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 	IsProblem�# [   -
   $��dgvListSearchResult_CT��$��1��$��0��$	��Top=�#��[ #	 [	 $��DemiBold"�$��0q�$
 Extended=� .  $��15(�   $ TRẠM��$	 33* $
 Bold"� �� *StationName+ �� " 	 .���  � ��$
 Left=���  � ��$ Center=�  $
 LÀN��$	 10*  �� *
LaneCode+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ ĐÓNG/MỞ��$	 33*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 
LaneStatus�# [   $ LƯỢNG XE��$	 31*  �� *Vol+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ MẬT ĐỘ��$	 20*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ IsAlarm�# [ 
  $ THIẾT BỊ��$	 25*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 	IsProblem�# [   -   $��dgvListSearchResult_353��$��2��$��0��$	��Top=�#��[ #	 [	 $��DemiBold"�$��0q�$
 Extended=� .  $��15(�   $ TRẠM��$	 33* $
 Bold"� �� *StationName+ �� " 	 .���  � ��$
 Left=���  � ��$ Center=�  $
 LÀN��$	 10*  �� *
LaneCode+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ ĐÓNG/MỞ��$	 33*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 
LaneStatus�# [   $ LƯỢNG XE��$	 31*  �� *Vol+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ MẬT ĐỘ��$	 20*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ IsAlarm�# [ 
  $ THIẾT BỊ��$	 25*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 	IsProblem�# [   -   $��dgvListSearchResult_DV��$��1��$��1��$��2��$	��Top=�#��[ #	 [	 $��DemiBold"�$��0q�$
 Extended=� .  $��15(�   $ TRẠM��$	 33* $
 Bold"� �� *StationName+ �� " 	 .���  � ��$
 Left=���  � ��$ Center=�  $
 LÀN��$	 10*  �� *
LaneCode+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ ĐÓNG/MỞ��$	 33*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 
LaneStatus�# [   $ LƯỢNG XE��$	 31*  �� *Vol+$ {0:N0}�� �� " 	 .���  � ��$ Center=���  � ��$ Center=�
  $ MẬT ĐỘ��$	 20*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ IsAlarm�# [ 
  $ THIẾT BỊ��$	 25*  �� .R��� $ 
Horizontal=�$��Center=�.+��� $	 IMG��$��Center=�$��Center=�$��20��$��20������ $ 	IsProblem�# [ 