   M S B A M L   `   `   `  ����   TollTicketManagement%    TollTicketManagement.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -      CustomWindow#��[    � Title$!  ITD - TRUNG TÂM QUẢN LÝ��$
��1280��$
��auto�� � Icon$ /Resources/Images/itd.ico�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � 
ResizeMode$ CanMinimize=�.��]� .+��� $��Bottom=�$��32�����	#FF007ACC.@��� .���� -   $��lblFunctionActiving��
�������$*��$PHÂN HỆ QUẢN LÝ THIẾT BỊ��$	��300���� �� .���� -   $��lblStatusConnect��
�������$��Server��$	��370���� �� .���� -   $��lblDateTime��
�������$��DateTime��$	��200��$
��Left=��� �� .���� -   $��
lblVersion��
�������$��Release Date:��$	��200��$
��Left=��� $
��Left=�$��ITD Software��$��Center=�$��5q�$��14(� � LayoutTransform ��  �� Angle$	 -90Q��  � RowDefinitions �� $	��17* ��� $
��688* �.+��� -   $��TabControl1��$��0,0,22,0q�  CustomTabControl#��[ $��1��.@��� -   $��TabDashBoard��$��	Dashboard��.��A� $��80,60,60,40q�$
��Left=�$	��Top=�$
��1000�� A� Rows$ 2��	 A� Columns$	 5��$	��400��.+�� $	��200��$	��150��.+��� $��QUẢN LÝ TRUNG TÂM��  GroupboxTitle#��[ $��Center=��� -   $��btnDashBoard��  ActionButtonStyle#��[ $
��Left=�.���� .+��� $/��)Resources/Images/computer-search-icon.png��$��65��$��65���� $��Center=�
Màn hình�� giám sát trung tâm� $	��200��$	��150��.+��� $��QUẢN LÝ GIAO DỊCH��#��[ $��Center=��� -	   $��	btnLookup��#��[ $
��Left=�.���� .+��� $!��Resources\Images\Lookup.png��$��65��$��65���� $��Center=�
Màn hình�� 	Tra cứu� $	��200��$	��150��.+��� $��THỐNG KÊ��#��[ $��Center=��� -
   $��btnStatistics��#��[ $
��Left=�.���� .+��� $%��Resources\Images\Statistics.png��$��65��$��65��$��Center=��� $��Center=�
Màn hình�� thống kê�� -   $��	TabConfig��$��Cấu hình��.���� $��80,60,60,40q�$��Stretch=�.+��� $��CẤU HÌNH��#��[ ��   GroupboxPanel#��[ .+��� -   $��btnConfigSystem��#��[ .���� .+��� $��64��$��64��$&�� Resources/Images/System-icon.png���� $��Center=�Hệ thống�� -   $��TabSupervision��$��
Giám sát��$y�Hidden=�.���� $��80,60,60,40q�$��Stretch=�.+��� $+��%QUẢN LÝ TRẠNG THÁI THIẾT BỊ��#��[ �� #��[ .+��� -   $��btnMonitorEquipment��#��[ {�.  .���� .+��� $/��)Resources/Images/computer-search-icon.png��$��64��$��64���� $��Center=�Trạng thái�� thiết bị�� $��QUẢN LÝ THẺ��#��[ �� #��[ .+��� -   $��btnCardManagement��#��[ {�. .���� .+��� $$��Resources/Images/Card-icon.png��$��64��$��64���� $��Center=�Quản lý thẻ�� �� -   $��TabSupervisionUtility��$��Chức năng hổ trợ��$y�Hidden=�.���� $��80,60,60,40q�$��Stretch=�.+��� $'��!CẬP NHẬT THÔNG TIN TRẠM RA��#��[ �� #��[ .+��� -   $��btnUpdateOutCheckInfo��#��[ {�. .���� .+��� $/��)Resources/Images/computer-search-icon.png��$��64��$��64���� $��Center=�Cập nhật�� 	đầu ra�� -   $��btnTrafficVolume��#��[ .���� .+��� $/��)Resources/Images/computer-search-icon.png��$��64��$��64���� $��Center=�Thống kê�� lưu lượng�� $��HẬU KIỂM THÔNG MINH��#��[ �� #��[ .+��� -   $��btnSmartSupervion��#��[ {�. .���� .+��� $$��Resources/Images/Card-icon.png��$��64��$��64���� $��Center=�HT hậu kiểm�� 