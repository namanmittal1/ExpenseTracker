   M S B A M L   `   `   `  ���� Y  UWPFVisifire.Charts, Version=5.1.7.0, Culture=neutral, PublicKeyToken=0cd785983078370bM9clr-namespace:Visifire.Charts;assembly=WPFVisifire.ChartsVisifire.Charts  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity I EExpenseTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ExpenseTracker.ConvertersExpenseTracker.Converters C   =ExpenseTracker.MainRegionModule.Views.StatisticsAnalyticsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Hvc9clr-namespace:Visifire.Charts;assembly=WPFVisifire.Charts     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     =	converter'clr-namespace:ExpenseTracker.Converters     J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com    � 	Resources     
ChartStyle �� 
TargetType   Visifire.Charts.Chart �� Property �� Value �� EndPoint �� 
StartPoint � Color � Offset  
TitleStyle   Visifire.Charts.Title<  6ExpenseTracker.Converters.BooleanToVisibilityConverter   BooleanToVisibilityConverter �� MergedDictionaries	 �� Source��  �� $A	 ;/CommonStylesResources/Theme1CommonStyles/CommonStyles.xaml?�%.  &	        &	 �     &	     �� "  .���  �@ 
Background �� $ 0.5,1&�$ 0.5,0&�.��� $
 Gray��$ 0Q�� $ White��$ .5Q�� $ 	#FFB2ADAD��$ 1Q���  �@ BorderThickness$ 5q��� "  .���  �@ FontSize$ 18Q���  �@ 	FontColor
 �����  .��� -   $��grdAnalyticsView��.  (System.Windows.Interactivity.Interaction
   Triggers
 /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadedCommand+   CommandParameter ��  �� ElementName$ grdAnalyticsView��.+��� 
   $ SelectionChanged��.    �� *TabControlSelectionChanged+ �� $ tbItemStatistics��.@��� -   $��tbItemAnalytics��$��	Analytics��$	��285�� �� 
IsSelected . .���  � RowDefinitions �� $
��Auto ��� $��* �.+�� $��0�� �� $��33 ��� $��33 ��� $��33 ��� $��33 ��� $��33 � � ColumnDefinitions �� $��* ��� $��* �.+��� $��Search criteria:��$��2��  
LabelStyle#��[ �� $��1��$��2�� �� Orientation$ 
Horizontal=�.+��� -   $��
cbCategory��$��25��$��
Categories��$��Times New Roman)�$��18(�$��20,0,0,0q� d� 	IsChecked �� *IsCbCategoriesChecked+�� -   $��cbItems��$��25��$��Items��$��40,0,0,0q� �� *IsCbItemsChecked+�� -   $��cbPeriod��$��25��$��Period��$��40,0,0,0q� �� *IsCbPeriodChecked+�� -   $��cbSource��$��25��$��Source��$��40,0,0,0q� �� *IsCbSourceChecked+�� $��2��$��0��$ 
Horizontal=�{��� *IsStkCategoriesEnabled+.+��� $��Categories: ��#��[ �� -   $��cmbCategories�� �� 
IsEditable . $	��150��$��10,0,0,0q�$��25�� �� DisplayMemberPath$ CategoryName������  �� Path$ 
Categories� �� Mode$ TwoWay=� �� SelectedValue �� $ SelectedCategory�$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=��� $��2��$��1��$ 
Horizontal=�{��� *IsStkItemsEnabled+.+��� $��Items: ��#��[ �� -   $��cmbItems�� . $	��150��$��10,0,0,0q�$��25��$ ItemName������ $ Items�$ TwoWay=� �� Text �� *ItemTextChanged+$ TwoWay=�$ PropertyChanged=� �� $ SelectedItem�$ OneWayToSource=�$ PropertyChanged=��� $��3��$��0��$��2��$ 
Horizontal=�{��� *IsStkPeriodEnabled+.+��� $��Period:         From: ��#��[ (  "System.Windows.Controls.DatePicker  -	   $��	dtpkrFrom��$	��140��$��18(�   SelectedDateFormat$ Short=�   SelectedDate �� *
DateFrom+�� $
��To: ��#��[ $��20,0,0,0q�  -
   $��dtpkrTo��$	��140��$��18(�$ Short=� �� *DateTo+�� $��4��$��0��$ 
Horizontal=�{��� *IsStkSourceEnabled+.+��� $��Source: ��#��[ �� -   $��	cmbSource��$	��150��$��10,0,0,0q�$��25�� �� $ SelectedSource�$ OneWayToSource=�$ PropertyChanged=�.@��� .��Home�� .��Office�� .��None�� $��4��$��1��$ 
Horizontal=�.+��� -   $��	btnSearch��$��Search��$��Times New Roman)�$��18(�$	��150��$��70,0,0,0q�$��25������ *SearchCommand+&	   System.Windows.Controls.DataGrid	  $��1��$	��560�� 	  CanUserReorderColumns .   	  CanUserResizeColumns .    	  CanUserResizeRows  .  ! 	  CanUserSortColumns! . " 	  AutoGenerateColumns" .  ���� *Data+# 	  Columns# 0
  *System.Windows.Controls.DataGridTextColumn
  ,  &System.Windows.Controls.DataGridColumn$   Header$$ Category��1  +System.Windows.Controls.DataGridBoundColumn%   Binding% �� *CategoryName+
  $$ 	Item name��% �� *
ItemName+
  $$ Quantity��% �� *
Quantity+
  $$ Amount��% �� *Amount+
  $$ Remarks��% �� *	Remarks+
  $$ Source��% �� *Source+
  $$ Date of expense��% �� *Date+� 
�������$��2��& J� Opacity$& .8Q�y��� $ AdornerVisibility�$ TwoWay=�$ PropertyChanged=�' �� 	Converter#' [ .+��� $	��300��"  WpfAnimatedGif.ImageBehavior(   	AutoStart( . )   AnimatedSource$G) AE:\ExpenseTracker\ExpenseTracker\ExpenseTracker\Images\images.gif��$��Center=�$��Center=��� -   $��tbItemStatistics��$��
Statistics��$	��285��.��� .+�  *   Theme$* Theme1��#��[  +   Titles+   ,   Text$", Major expenses of last month��#��[ -   Series-     Visifire.Charts.DataSeries  .   RenderAs$. Column=�/   
DataPoints/    Visifire.Charts.DataPoint  0   YValue0 �� *FirstColumnValue+1   
AxisXLabel1 �� *FirstColumnName+  0 �� *SecondColumnValue+1 �� *SecondColumnName+  0 �� *ThirdColumnValue+1 �� *ThirdColumnName+  0 �� *FourthColumnValue+1 �� *FourthColumnName+  0 �� *FifthColumnValue+1 �� *FifthColumnName+