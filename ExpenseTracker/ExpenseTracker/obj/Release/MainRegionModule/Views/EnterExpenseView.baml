   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  I EExpenseTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ExpenseTracker.ConvertersExpenseTracker.Converters U/clr-namespace:ExpenseTracker.AttachedBehaviours!ExpenseTracker.AttachedBehaviours <   6ExpenseTracker.MainRegionModule.Views.EnterExpenseView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     9local'clr-namespace:ExpenseTracker.Converters     Dbahivour/clr-namespace:ExpenseTracker.AttachedBehaviours       � 	Resources   �� MergedDictionaries �� Source3  -ExpenseTracker.Converters.IntToFloatConverter   IntToFloatConverter��  �� $A ;/CommonStylesResources/Theme1CommonStyles/CommonStyles.xaml?�%   &	          .���  � RowDefinitions �� $��55 ��� $��40 ��� $��40 ��� $��40 ��� $��60 ��� $��40 ��� $��40 � � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� $��Enter Expense��$��4��  Header1Style#��[ $��Center=��� $��Select Category: ��$��1��$��0��  
LabelStyle#��[ $��Center=�$��Right=��� $��Select/Enter Item: ��$��2��$��0��#��[ $��Center=�$��Right=��� $��
Quantity: ��$��3��$��0��#��[ $��Center=�$��Right=��� $��Amount per peice: ��$��3��$��2��#��[ $��Center=�$��Right=��� $��Source: ��$��5��$��0��#��[ $��Center=�$��Right=��� $��	Remarks: ��$��4��$��0��#��[ $��Center=�$��Right=��� $��5��$��1��$��3�� �� Orientation$ 
Horizontal=�.+�	� -   $��cbHome��$�� Home��$��20��$��6��$��Center=�$��1,1,1,1q�$��Times New Roman)�$��15(�$
��Bold"� d� 	IsChecked �� *RadioHomeSelected+ �� UpdateSourceTrigger$ PropertyChanged=�	� -   $��cbOffice��$�� Office��$��20��$��7��$��Center=�$��1,1,1,1q�$��20,0,0,0q�$��Times New Roman)�$��15(�$
��Bold"� �� *RadioOfficeSelected+$ PropertyChanged=�	� -   $��cbNone��$�� None��$��8��$��20��$��Center=�$��1,1,1,1q�$��20,0,0,0q�$��Times New Roman)�$��15(�$
��Bold"� �� *RadioNoneSelected+$ PropertyChanged=��� -   $��btnSave��$
��Save��$��6��$��1��$��60��$��30��$��Times New Roman)�$��15(�$
��Bold"�$��Center=�$
��Left=�$��9������  �� Path$ SaveCommand��� -   $��btnClearAll��$��	Clear All��$��6��$��2��$��65��$��30��$��Times New Roman)�$��15(�$
��Bold"�$��Center=�$
��Left=�$��10������ $ ClearAllCommand��� -   $��cmbCategories��	 �� 
IsEditable	 .  $��1��$��1��$
��Left=�$	��135��$��25��$��1��
 �� DisplayMemberPath$
 CategoryName��$ �� IsSynchronizedWithCurrentItem$
 TrueY����� $ 
Categories� �� Mode$ TwoWay=� �� SelectedValue �� $ SelectedCategory�$ OneWayToSource=�$ PropertyChanged=��� -   $��cmbItems��	 . $��2��$��1��$
��Left=�$	��135��$��25��$��2��$
 ItemName������ $ Items�$ TwoWay=� �� Text �� *ItemTextChanged+$ TwoWay=�$ PropertyChanged=� �� $ SelectedItem�$ OneWayToSource=�$ PropertyChanged=� �� SelectedIndex �� $ SelectedIndex�$ TwoWay=�$ PropertyChanged=�.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ 	LostFocus��.   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction     Command �� *LostFocusCommand+   CommandParameter ��  �� ElementName$ cmbItems��$
 Text��� -   $��tbQty��$��3��$��1��$	��125��$��35��$
��Left=�8  2ExpenseTracker.AttachedBehaviours.TextBoxBehaviour   SelectedText$
 True��$��3������ *
Quantity+$ PropertyChanged=�$ TwoWay=��� -	   $��tbAmount��$��3��$��3��$	��125��$��35��$
 True��$��4������ *Amount+$ PropertyChanged=�$ TwoWay=� �� 	Converter# [  �� -
   $��	tbRemarks��$
��Left=�$��4��$��1��$��4��$	��424��$��50��$��5�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . ���� *	Remarks+$ PropertyChanged=�$ TwoWay=�