   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      I EExpenseTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ExpenseTracker.ConvertersExpenseTracker.Converters 5      U/clr-namespace:ExpenseTracker.AttachedBehaviours!ExpenseTracker.AttachedBehaviours 5	      <   6ExpenseTracker.MainRegionModule.Views.EnterExpenseView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      9local'clr-namespace:ExpenseTracker.Converters     5      Dbahivour/clr-namespace:ExpenseTracker.AttachedBehaviours     5	        � 	Resources  5       �� MergedDictionaries �� Source3  -ExpenseTracker.Converters.IntToFloatConverter   IntToFloatConverter�� 5   
    5      �� 5      $A ;/CommonStylesResources/Theme1CommonStyles/CommonStyles.xaml?�6%   %   &	          5      6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��60 �6   �� 5      $��40 �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       $��* �6   �� 5!      $
��Auto �6   �� 5"      $��* �6   .+�5%   
   �� $��Enter Expense��6   $��4��6(     Header1Style#��[ 6=   $��Center=�6c   �� 5&   
   $��Select Category: ��6   $��1��6,   $��0��69     
LabelStyle#��[ 6I   $��Center=�6m   $��Right=�6�   �� 5'   
   $��Select/Enter Item: ��6   $��2��6.   $��0��6;   #��[ 6K   $��Center=�6o   $��Right=�6�   �� 5(   
   $��
Quantity: ��6   $��3��6%   $��0��62   #��[ 6B   $��Center=�6f   $��Right=�6�   �� 5)   
   $��Amount per peice: ��6   $��3��6-   $��2��6:   #��[ 6J   $��Center=�6n   $��Right=�6�   �� 5*   
   $��Source: ��6   $��5��6#   $��0��60   #��[ 6@   $��Center=�6d   $��Right=�6   �� 5+   
   $��	Remarks: ��6   $��4��6$   $��0��61   #��[ 6A   $��Center=�6e   $��Right=�6�   �� 5-   
   $��5��6   $��1��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   .+�5.      	� -   5        $��cbHome��5.      $�� Home��6(   $��20��68   $��6��6D   $��Center=�50      $��1,1,1,1q�65   $��Times New Roman)�6H   $��15(�6e   $
��Bold"�6s    d� 	IsChecked 5/      �� *RadioHomeSelected+ �� UpdateSourceTrigger$ PropertyChanged=�50   s   	� 51      -   5        $��cbOffice��51      $�� Office��6*   $��20��6<   $��7��6H   $��Center=�53      $��1,1,1,1q�65   $��20,0,0,0q�6G   $��Times New Roman)�6Z   $��15(�6w   $
��Bold"�6�    52      �� *RadioOfficeSelected+$ PropertyChanged=�53   �   	� 54      -   5        $��cbNone��54      $�� None��6(   $��8��68   $��20��55   g   $��Center=�56      $��1,1,1,1q�65   $��20,0,0,0q�6G   $��Times New Roman)�6Z   $��15(�6w   $
��Bold"�6�    55      �� *RadioNoneSelected+$ PropertyChanged=�56   �   57      �� 59   
   -   5        $��btnSave��59      $
��Save��6    $��6��6/   $��1��6<   $��60��6L   $��30��6W   $��Times New Roman)�5:      $��15(�6.   $
��Bold"�6<   $��Center=�6N   $
��Left=�5;      $��9��6Q   ��6,   ��  �� Path$ SaveCommand�6Q   �� 5<   
   -   5        $��btnClearAll��5<      $��	Clear All��6$   $��6��68   $��2��6E   $��65��6U   $��30��6`   $��Times New Roman)�5=      $��15(�6.   $
��Bold"�6<   $��Center=�6N   $
��Left=�5>      $��10��6U   ��6,   �� $ ClearAllCommand�6U   �� 5@   
   -   5        $��cmbCategories��5@      	 �� 
IsEditable	 .  $��1��6;   $��1��6H   $
��Left=�6X   $	��135��6s   $��25��6   $��1��6�   
 �� DisplayMemberPath$
 CategoryName��5A   H   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6i   ��6   �� $ 
Categories� �� Mode$ TwoWay=� �� SelectedValue 5B      �� $ SelectedCategory�$ OneWayToSource=�$ PropertyChanged=��� 5D   
   -   5        $��cmbItems��5D      	 . $��2��65   $��1��6B   $
��Left=�6R   $	��135��6m   $��25��6y   $��2��6�   $
 ItemName��5E   C   ��6   �� $ Items�$ TwoWay=� �� Text 6`   �� *ItemTextChanged+$ TwoWay=�$ PropertyChanged=� 5F      �� $ SelectedItem�$ OneWayToSource=�$ PropertyChanged=� �� SelectedIndex 5G      �� $ SelectedIndex�$ TwoWay=�$ PropertyChanged=�.   (System.Windows.Interactivity.Interaction   Triggers 5H      /   )System.Windows.Interactivity.EventTrigger  5I         	EventName$ 	LostFocus��5J      .   (System.Windows.Interactivity.TriggerBase   Actions. 5K      6   0System.Windows.Interactivity.InvokeCommandAction     Command 5L      �� *LostFocusCommand+   CommandParameter 6:   ��  �� ElementName$ cmbItems��$
 Text�5M      5O      �� 5Q   
   -   5        $��tbQty��5Q      $��3��6   $��1��6,   $	��125��6<   $��35��6H   $
��Left=�5R      8  2ExpenseTracker.AttachedBehaviours.TextBoxBehaviour   SelectedText$
 True��6-   $��3��5S   ^   ��6   �� *
Quantity+$ PropertyChanged=�$ TwoWay=�6^   �� 5T   
   -	   5        $��tbAmount��5T      $��3��6"   $��3��6/   $	��125��6?   $��35��6K   $
 True��5U      $��4��5W   >   ��5V      �� *Amount+$ PropertyChanged=�$ TwoWay=� �� 	Converter# [  5W   >   �� 5X   
   -
   5        $��	tbRemarks��5X      $
��Left=�6#   $��4��6>   $��1��6K   $��4��6[   $	��424��6o   $��50��6{   $��5��6�    �� TextWrapping$
 Wrap=�5Y       �� AcceptsReturn . ��6;   �� *	Remarks+$ PropertyChanged=�$ TwoWay=�5Z      5[      