   M S B A M L   `   `   `  ����   TollTicketManagement    TollTicketManagement.App   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       �� 	Resources   �� 
TargetType   WindowButtonStyle �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� ContentStringFormat �� ContentStringFormat	 �� Triggers
 P� Property P� Value  CustomWindow � RowDefinitions � ColumnDefinitions �� Orientation � Title ��Name  CustomTabControl �� 	Resources � 	Resources �� Triggers-  'System.Windows.Input.KeyboardNavigation   TabNavigation K� ZIndex K� IsItemsHost   TabIndex  CustomDialog  GroupboxTitle  GroupboxPanel  ActionButtonStyle ��Name ��Name �� TextAlignment  ListViewTitleStyle&   System.Windows.Controls.DataGrid  CustomDataGridStyle #	 Body_Content_DataGrid_Centering*  $System.Windows.Controls.DataGridCell=  7System.Windows.Controls.Primitives.DataGridColumnHeader:  4System.Windows.Controls.Primitives.DataGridRowHeader 
 RowDetailsTemplateBorder  NormalTextBlock  NormalTextBlockAlignRight �� BasedOn  NormalButton  NormalTextBox  NormalTextBoxCapital ! NormalTextBoxContentAlignLeft # NormalTextBoxContentAlignRigtht  ReadOnlyTextBox # ReadOnlyTextBoxContentAlignLeft $  ReadOnlyTextBoxContentAlignRight  NormalComboBox  WaterMarkGrid  WaterMarkTextBlock  WaterMarkTextBox  NormalCheckBox��%�  &	        &	 �    7   7   7   &	 �    &	 �    7   &	 o
    &	 �
    &	 4    &	 \    &	 �    &		 �    '  \    '      &	
 �    &	     &	 �    7  &	      &	 �    &	 �    &	 �    7  &	 �    7  &	 �    7  &	 -    7  &	 W    7  &	 �    &	 �    &	 @    &	 �    &	 3    �� " ��.���  � �� �� " ��.R��� $ Chrome��#��z��$��0q�#��z�� . ._��� #��z��#��z��# z #��z��#��z����. # z #��z����  � ��
 ���� ��  � ��$ Webdings)���  � ��$ 14(���  � �� �#1c1c1c��  � ��$ 0,0,4,0q���  � ��$ 4,2,4,2q�	 P� 
 �@J�IsMouseOver . . ���  � �� �#808080��  � ��
 ������� " �.���  �@�WindowStyle$
 None=���  �@�
ResizeMode$ NoResize=���  � �� �#2D2D30��  � ��$ 0q���  � ��
 �������  � �� �#D0D0D0��  �@�Icon$ /Resources/Images/itd.ico����  � �� �� " �.R��� #��z��#��z��._�� ���#707070 �� $
��Auto ���  �� �� $
��Auto �.+��� $��0��$��0��$ 
Horizontal=�$��Center=�$��3,3,0,0q�.+�o� ���#707070���#707070$��1q�$��32��$��Segoe UI)�$��13(�.@�m� $�� �����#707070$��0q�$��0q��� $��16(�$��Segoe UI)�
�������#��z $��20,0,0,0q�$��Center=��� $��0��$��1��$ 
Horizontal=�$��Center=�.+��� $ minimizeButton��8��  $��0���� $ restoreButton��8�� $��1��{�.  �� $ closeButton��8�� $��r��� #��z��$��1��$��2��$��3,3,3,3q�.+��� .u��� �� " �� ���� '��       " ��.���  � �� �� " ��.R�� #��z�� . $��23��.+��� $��Header��$��	10,0,10,0q�$��Center=�$��Center=� ���� '��       " ��.���  � �� �#E0E0E0��  � ��$ 14(� P� 
 �@��
IsSelected .  . ���  � ��
 ���� P� 
 �@J�IsMouseOver . . ���  � �� �#1C97EAP� 
 �@��
IsSelected . . ���  � �� �#007ACC��  � �� �#FFFFFF.���  � �� �� " ��.R�� $ Local=� �� $
��Auto ��� $��* �.+��� 
������ $��0,0,0,3q����#007ACC._��� $��HeaderPanel��$ 1��$��0,0,4,-1q� . $ 1���� $��1�����#1c1c1c�� $��PART_SelectedContentHost��$��1��$��SelectedContent���� " �.���  �@�WindowStyle$
 None=���  �@�
ResizeMode$ NoResize=���  � �� �#3D3D48��  � ��$ 0q���  � ��
 �������  � �� �#D0D0D0��  � �� �� " �.R��� #��z��#��z��._�� ���#707070 �� $
��Auto ���  �� �� $
��Auto �.+��� $��0��$��0��$ 
Horizontal=�$��Center=�$��3,3,0,0q�.+��� $��32��$��24��$��/Resources/Images/itd.ico���� $��16(�$��Segoe UI)�
�������#��z $��20,0,0,0q�$��Center=��� $��0��$��1��$ 
Horizontal=�$��Center=�.+��� $ closeButton��8��  $��r��� #��z��$��1��$��2��$��5,5,5,5q�.+��� .u��� �� " ��.���  � ��$ 16(���  � �� �#D0D0D0�� " ��.���  � ��$ 0,0,0,40q���  �@��Orientation$ 
Horizontal=���  � ��$ Stretch=���  � ��
 ���� �� " ��.���  � ��$	 100����  � ��$	 100����  � ��$ 12(���  � ��$ 0q���  � �� �#E0E0E0��  � ��
 ��  ���  � ��$ 40,10,60,10q���  � ��$ 0q���  � �� �� " ��.R�� #��z��#��z��.+��� $ innerRectangle��$��Stretch=�$��Stretch=�#��z��]� $!��myContentPresenterDockPanel��.+��� $ myContentPresenter��$��Center=�#��z��
�������$ Center=� P� 
 �@J�IsMouseOver . . ���  � ��
 ��  �P� 
 � {� .  . ���  �@J�Opacity$	 0.4Q��� " ��.���  � ��$ 28(���  � ��
 �������  � ��$ 0,12,0,0q���  � ��$ Center=��� "  .���  � ��$ 20(���  � ��$ 5q���  � �� �� ��  �@ AutoGenerateColumns .  ��   �@ AlternatingRowBackground �#D0D0FF��  �@ CanUserAddRows .  ��   �@ HorizontalGridLinesBrush �#D0D0D0��  �@ VerticalGridLinesBrush �#D0D0D0��  �@ 
IsReadOnly . ��  �@ SelectionMode$ Single=���  �@ SelectionUnit$ FullRow=���  � ��$ Center=���  � ��$ Center=���  �@ CanUserSortColumns .  ��  �@ 
IsReadOnly . �� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=�$��Center=���  � ��$ 18(��� "  .���  � �� �#007ACC��  � ��
 �������  � ��$ Sitka Display)���  � ��$ 23����  � ��$
 Bold"���  � ��$	 0,0q���  � ��$ Center=��� "  .���  � ��$ 2q���  � �� �#808080��  � ��
 �������  � ��$	 2,2q���  � ��$ Right=��� " ��.���  � ��$ 1,0,1,1q���  � �� �#408888��  � ��
 �������  � ��$ 10,5,5,5q��� " ��.���  � �� �#E0E0E0��  � ��$ 14(���  � ��$ Center=���  � ��$ Center=��� " ��8   .���  � �� �#E0E0E0��  � ��$ 14(���  � ��$ Center=���  � ��$ Right=���  � ��$ 0,0,8,0q��� " ��.���  � �� �#007ACC��  � ��$ 24����  � ��$ 14(���  �@J�Opacity$	 1.0Q���  � �� �� " ��.R�� #��z��#��z��.+��� $ innerRectangle��$��Stretch=�$��Stretch=�#��z��]� $!��myContentPresenterDockPanel��.+��� $ myContentPresenter��$��Center=�#��z��
�������$ Center=� P� 
 �@J�IsMouseOver . . ���  � �� �#1C97EAP� 
 � {� .  . ���  �@J�Opacity$	 0.5Q��� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ 24����  � ��$ 14(���  � ��$ Center=���  � ��$
 Left=���  �@��
IsReadOnly .  �� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ 24����  � ��$ 14(���  � ��$ Center=���  � ��$
 Left=���  �@��
IsReadOnly .  ��  �@��CharacterCasing$ Upper=��� " ��8   .���  � ��$
 Left=��� " ��8   .���  � ��$ Right=��� " ��8   .���  � ��
 �������  �@��
IsReadOnly . �� " ��8   .���  � ��$
 Left=��� " ��8   .���  � ��$ Right=��� " ��.���  � ��$ 24����  � ��$ 14(���  � ��$ Center=���  � ��$
 Left=��� " �.���  � ��
 �������  � ��$ 23����  � ��$
 Left=��� " ��.���  � ��
 �������  � ��
 �������  � ��$ 5,0,0,0q���  � ��$ 13(���  � ��$ Center=���  � ��$
 Left=��� " ��.���  � ��
 ���� ��  � ��
 �   ���  � ��$ 13(��� " ��.���  � �� �#E0E0E0��  � ��$ 14(���  � ��$ Center=���  � ��$
 Left=�