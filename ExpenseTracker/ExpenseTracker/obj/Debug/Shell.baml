   M S B A M L   `   `   `  ����I  EExpenseTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ExpenseTrackerExpenseTracker  5   	       ExpenseTracker.Shell   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hMicrosoft.Practices.Prism.Composition, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e350prism$http://www.codeplex.com/CompositeWPF  5      (localclr-namespace:ExpenseTracker  5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)    � 
ResizeMode$ NoResize=�5   5    � 	Resources 5       �� Source�� 5   
   $A ;/CommonStylesResources/Theme1CommonStyles/CommonStyles.xaml?�6   %    .��5
      �    WindowBackgroundStyle#��[  6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��440 �6   �� 5      $��80 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��200 �6   .+�5   
   �� $��0��6   $��2��6     MainHeaderStyle#��[ 61   .��6Z   Welcome to Expense Manager6v   �� 5   
   $��4q�6    �� CornerRadius$ 4��6%   $��1��66   $��0��6C   
�������._�5   
   ��     ExpenseTracker.RegionNames   
MainRegion5  /Microsoft.Practices.Prism.Regions.RegionManager   
RegionName# Z 6   6e   5      �� 5   
   $��4q�6   $ 4��6%   $��1��66   $��1��6C   
�������._�5   
   �� 	   NavigationRegion# Z	 6   6k   5      �� 5    
   $��2q�6   $ 4��6%   $��2��66   $��2��6C   
�������._�5!   
   �� 
   StatusBarRegion# Z
 6   6j   5"      5#      5$      