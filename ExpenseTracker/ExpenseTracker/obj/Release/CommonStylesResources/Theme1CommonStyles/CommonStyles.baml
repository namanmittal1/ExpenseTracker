   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType   WindowBackgroundStyle �� Property  NavBarGradient �� Value  MainHeaderStyle  
FontFamily  	TextColor  Header1Style  
LabelStyle �� 
TargetType �� CornerRadius �� Padding  BorderColor  LightGrayBrush ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName 	 HighlightColor 
 comboTextBox  ButtonIndentGradient ��Name ��Name ��Name  ButtonOverGradient ' #LightBlueBorderColorSolidColorBrush  ButtonDisabledGradient �� 
Background �� Bullet A�Name  NormalBorderBrush  
GlyphBrush  ComboBoxToggleButton � ColumnDefinitions F�Name  	GreyBrush �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly  �� IsDropDownOpen! � AllowsTransparency" J� SnapsToDevicePixels# � ActualWidth$ �� MaxDropDownHeight% K� IsItemsHost-   'System.Windows.Input.KeyboardNavigation&    DirectionalNavigation' P� 
SourceName( N� EnterActions) �� 
TargetName* �� TargetProperty+ g� Duration, W� From	- W� To. �Name/ ]� 
Conditions0 �� 
SourceName1 �� Property2 �� Value  ColumnHeaderStyle1=  7System.Windows.Controls.Primitives.DataGridColumnHeader3 �� Triggers&   System.Windows.Controls.DataGrid  
BlackBrush  HighlightGreenColor�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml        �� $/ )/CommonStylesResources/CommonBrushes.xaml?�%  &	        7  &	      7  7  &	 �     7  7  &	 �     7  7  '�� T    7  7  7  7  7 	 &	
 �    7  7  7  7  7 	 'G� �    7  7  7  7  7 	 '�� �    7  7 	 7  7  7  7  7  7  7  7  '	� �    7  7 	 7  7  &	 �    7  7  7  '�� �
    7  7 	 7  7  7 
 7  7  '�� �    7  '�� �    7  7  7  7  '�� W    7  7  '�� �    7 	 7  7  7  7  7  7  7  &	 ;    7  7  7  7  7  '      7  7  7  '�� �    7  7  7  7 	 7  7  7 	 7  �� " �.���  � ��8   �� " ��.���  � ��$ 50(���  � ��8   ��  � ��$
 Bold"���  � ��$
 0,12q���  � ��8  �� " ��.���  � ��$ 40(���  � ��8   ��  � ��$
 Bold"���  � ��8  �� " ��.���  � ��$ 16(���  � ��8   ��  � ��$
 Bold"���  � ��8  �� " ��.���  � ��$ 16(���  � ��8   ��  � ��$
 Bold"���  � ��$	 0,3q���  � ��8  ��  � �� �� " ��.R��� $��Border��$ 2��$	 0,4q�8�� 8�� $��3q�._��� $ PART_ContentHost��$��0q�	 P� 
 �@J�	IsFocused . . ��� $ Border��8   � ���� " ��.���  � ��$ 14(���  � ��8   ��  � ��$
 Bold"���  � ��$	 0,3q���  � ��8  ��  � �� �� " ��.R��� $��Border��$ 1��8�� 8�� $ 0,1,0,0q�$��2q�._��� $ PART_ContentHost��$��0q�	 P� 
 �@J�	IsFocused . . ��� $ Border��8   � ���� " G�.���  � ��$ 16(���  � ��8   ��  � ��$
 Bold"���  � ��$	 0,4q���  � ��8  ��  � �� �� " G�.R��� $��Border��$ 2��$ 2q�8�� 8�� $��3q�._��� $ PART_ContentHost��$��0q�	 P� 
 �@J�	IsFocused . . ��� $ Border��8   � ���� " ��.���  �@J�	AllowDrop . ��  � ��8   ��  � ��8  ��  � ��$ 16(���  � ��8  ��  � ��$
 Bold"���  � ��8  ��  � ��$ 2q���  � �� �� " ��.R�� .+��� $ 
Background��$ 3��8�� #��z��#��z��._�� #��z��$��1q�.+��� $ BackgroundGradient��#��z���� $ contentPresenter��#��z��#��z��#��z��#��z��#��z��	 P� 
 �@J�IsMouseOver . . ��� $ BackgroundGradient��8   � ���� $ contentPresenter��8   � ��P� 
 � �� . . ��� $ BackgroundGradient��8   � ���� $ contentPresenter��8   � ��P� 
 � {� .  . ��� $ BackgroundGradient��8 	  � ���� " 	�.���  � ��8   ��  � �� �� " 	�.R��� 
 ����  � $��18��$��18��.+�A� $ Border��8�� $��1��8�� A� $ 	CheckMark��$��4q�8�� ._��� $��4,0,0,0q�$��Center=�$
��Left=���. 	 P� 
 �@d�	IsChecked$ falseY�. ��� $ 	CheckMark�� � y�$ 	Collapsed=��� " d�.���  � �� �� " d�.R��  �� �� $��32 �.+��� $ Border��$��2��$ 0��#��z��#��z��$��2q��� $��0��$ 0��
������ 
������ $��10q�F� $ Arrow��$��1��#��z��#��z��$��Center=�$��Center=�"����        � z  � � $�     		 P� 
 � {� .  . ��� $ Border��8    � ���� $ Border�� � ��
 ������� 8   � ���� $ Arrow��8   � ���� " ��.���  � ��8   ��  � ��8  ��  � ��8  ��  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$ 14(���  � ��$ SemiBold"���  � ��$ 50����  � ��$ 32����  � �� �� " ��.R�� .+�d� $��ToggleButton��#��z��#��z��#��z��8�� $��2��|�.  $ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite�� .  #��z #��z #��z��$��3,0,28,0q�$��Center=�$��Stretch=��� $ PART_EditableTextBox��$��Stretch=�$��Stretch=�$��2,1,26,1q�|�. $y�Hidden=�8�� # z � $��Popup��$��Bottom=�#��z  ! . |�.  $��Slide=�.��� $��DropDown��" . #��z# #��z$ z�V� .~��� .+��� $ DropDownBorder��8�� $��2q�8�� �� $��4,6,4,6q�" . .���� % . $& 	Contained=�	 P� 
 �@��HasItems .  . ��� $ DropDownBorder�� � ��$ 95��P� 
 �@��
IsGrouping . . ���  � �� .  P� $' Popup��
 �@�AllowsTransparency . . ��� $ DropDownBorder�� �@��CornerRadius$ 0���� $ DropDownBorder�� � ��$ 0,2,0,0q�P� 
 �@��
IsEditable . . ���  � �� .  �� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=�P� 
 �@��IsDropDownOpen . ( �� .���� .��W� $) DropDown��$(* "RenderTransform.Children[0].ScaleX�$+ 0:0:0.5D�$, 1X�$- 1X�W� $) DropDown��$(* "RenderTransform.Children[0].ScaleY�$+ 0:0:0.5D�$, 0X�$- 1X��� " ��.���  � ��8   �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��8   ��  � ��8  ��  � ��$ 14(���  � �� �� " ��.R��� $��Border��$ 2q�" . ._��� $��contentPresenter��	 P� 
 �@��
IsSelected . . ��� $ Border��8   � ��P� 
 � {� .  . ��� 8   � ���� " ��.���  � ��8   ��  � ��8  ��  � ��$ 4q��� " ��.���  � ��$ 2q���  � ��8   ��  � ��8  ��  � ��$ Stretch=���  � ��$ Stretch=���  � ��$ 16(���  � ��8  ��  � ��$
 Bold"���  � ��8  ��  � �� �� " ��.R�� .+��� $ headerBorder��$ 2,2,0,0��#��z��#��z��#��z��._�� $. gridMouseOver��.+��� $ contentPresenter��$��Header��#��z��#��z��	 P� 
 �@��
IsSelected . . ��� $ headerBorder��8   � ���� $ headerBorder��8   � ��]� / �� $0 gridMouseOver��1 �@J�IsMouseOver2 . �� 1 �@��
IsSelected2 .  ./��� $ headerBorder��8   � ���� $ headerBorder��8   � ���� "  .���  � ��$ 25����  � ��8   ��  � ��8  ��  � ��$ 14(���  � ��$ Stretch=���  � ��$ Stretch=���  �@ SeparatorBrush8  ��  �@ SeparatorVisibility$ Visible=���  � ��$	 5,0q���  � �� �� "  .R��� $ headerBorder��$ 4,4,4,4��#��z��#��z��#��z��._�� $. gridMouseOver��.+��� #��z��#��z��3 P� 
 �@J�IsMouseOver . . ���  � ��8  ��  � ��8  �� "  .���  �@ RowBackground8   ��   �@ AlternatingRowBackground
 �������  � ��8  ��  �@ HeadersVisibility$	 All=��� % �@ HorizontalScrollBarVisibility$
 Auto=��� # �@ VerticalScrollBarVisibility$
 Auto=���  �@ SelectionMode$ Extended=���  �@ CanUserSortColumns . ��  �@ ColumnHeaderStyle8  �� " ��.���  � ��8   ��  � ��8  ��  � ��$ 18(���  � �� �� " ��.R��� 
 ����  �� $ Border��$��15��$��15��$ 2��8�� $��1q�8�� ._�F� $ 	CheckMark��$��7��$��7��" .  8�� $��2��+����        ���j ��j �    ��j ���j     	._��� $��20,0,0,0q�$��Center=�$
��Left=���. 	 P� 
 �@d�	IsChecked$ falseY�. ��� $ 	CheckMark�� � y�$ 	Collapsed=�P�  Z� 
 �@d�	IsChecked. ��� $ 	CheckMark�� � �� ��    ��j ���j     	P� 
 �@J�IsMouseOver . . ��� $ Border��8   � ��P� 
 � �� . . ��� $ Border��8   � ���� $ Border��8   � ��