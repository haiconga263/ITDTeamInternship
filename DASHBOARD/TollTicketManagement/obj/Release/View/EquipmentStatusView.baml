   M S B A M L   `   `   `  ���� X  TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  O KTollTicketManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:TollTicketManagement.Resources.Message&TollTicketManagement.Resources.Message 3   -TollTicketManagement.View.EquipmentStatusView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     Gscreen4clr-namespace:TollTicketManagement.Resources.Message     -      CustomDialog#��[    � WindowStartupLocation$  CenterScreen=� � Icon$ /Resources/Images/itd.ico�� � Title$. (QUẢN LÝ TRẠNG THÁI THIẾT BỊ��$
��1280��$
��auto�� � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=�.��]� ��. .+�� -   $��GridMain��$
��auto��$��Stretch=�$��Stretch=� � RowDefinitions �� $��50 ��� -    �Name$ rowLoadedData��$��* ��� -   $ LastRow��$
��auto �.+��� $��0��$+��%QUẢN LÝ TÌNH TRẠNG THIẾT BỊ��  ListViewTitleStyle#��[ $��438,8,438,8q��� $��2�����#808080$��2q����#404040$��Stretch=�$��Stretch=�._��� -   $��expInformation��$��Stretch=�$��Stretch=�$��Bottom=�$
��Auto��.+��� ���#808080$��2q����#404040$��0q�._�� $��Stretch=�$��Stretch=� � ColumnDefinitions �� $	��130 ��� $	��164 ��� $	��30* ��� $	��150 ��� $	��115 ��� $	��30* ��� $��70 ��� $	��117 ��� $	��30* ��� $��65 ��� $
��141* � �� $��36 ��� $��36 ��� $��36 �.+��� $��Trạm��$��0��$��0��  NormalTextBlock#��[ $��Center=�$��20��$��45��$��16,8,0,8q��� -    ��Name$ 	cbStation��$��1��$��0��$��14(�$��4,4,0,4q�	 �� 
IsEditable	 .  $	��150��$
��Left=��� $��Tổng làn��$��0��$��1��#��[ $��Center=�$��20��$	��100��$��16,8,0,8q��� -   
 ��Name$
 txtQuantityTotal��$��1��$��1��$��4,4,0,4q�$��14(�$
��Left=�$	��150��{�.  �� $��Số làn hoạt động��$��0��$��2��#��[ $��Center=�$��20��$��16,8,0,8q��� -   $
 txtQuantityActive��$��1��$��2��$��4,4,0,4q�$��14(�$
��Left=�$	��150��{�.  �� $��
 Làn vào��$��6��#��[ $��Center=�$
��Left=�$��20��$��58��$	��0,8q�$y�Hidden=��� $�� Làn ra��$��6��$��1��#��[ $��Center=�$
��Left=�$��20��$��53��$	��0,8q�$y�Hidden=��� $�� Làn đóng��$��6��$��2��#��[ $��Center=�$
��Left=�$��20��$��70��$	��0,8q�$��2��$y�Hidden=��� $ ��Số làn tự động ETC��$��3��$��1��#��[ $��Center=�$
��Left=�$��20��$	��0,8q��� -	   $
 txtQuantityETC��$��4��$��1��$��4q�$��14(�$��Stretch=�$��Stretch=�{�.  �� $��Số làn thủ công MTC��$��3��$��2��#��[ $��Center=�$
��Left=�$��20��$	��0,8q��� -
   $
 txtQuantityMTC��$��4��$��2��$��4q�$��14(�$��Stretch=�$��Stretch=�{�.  �� $"��Thời gian cập nhật (s)��$��3��$��0��#��[ $
��Left=�$��20��$	��0,8q��� 
�������$��7��$��4q�$��32��$	��Top=�$y�Hidden=��� 
�������$��7��$��1��$��4q�$��32��$	��Top=�$y�Hidden=��� 
���Gc��$��7��$��2��$��4q�$��32��$	��Top=�$y�Hidden=��� -    ��Name$ GreenImg��$��32��$��32��$��9��$��0��$��Center=�$��Center=�$��	15,2,16,2q�$H��B/TollTicketManagement;component/Resources/Images/green_light32.png���� $��Đang hoạt động��$��10��$��0��#��[ $	��0,8q��� -   $ RedImg��$��32��$��32��$��9��$��1��$��Center=�$��Center=�$��	15,2,16,2q�$F��@/TollTicketManagement;component/Resources/Images/red_light32.png���� $!��Đang ngưng hoạt động��$��10��$��1��#��[ $	��0,8q��� -   $ 	YellowImg��$��32��$��9��$��2��$��Center=�$��Center=�$��32��$��	15,2,16,2q�$I��C/TollTicketManagement;component/Resources/Images/yellow_light32.png���� $��Đang bảo trì��$��10��$��2��#��[ $	��0,8q�%   Xceed.Wpf.Toolkit.DecimalUpDown  -   $��autoTime��,   &Xceed.Wpf.Toolkit.Primitives.InputBase   Text$ 5��$��4q�$��4��$��Stretch=��   �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 5X�   MouseWheelActiveOnFocus .     AllowTextInput .  � -    �Name$ grdDynamicGrid��$��1��$��Stretch=�$��Stretch=�