   M S B A M L   `   `   `  ���� I  EExpenseTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ExpenseTrackerExpenseTracker      ExpenseTracker.Shell   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     l hMicrosoft.Practices.Prism.Composition, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e350prism$http://www.codeplex.com/CompositeWPF  (localclr-namespace:ExpenseTracker    � Title$  
MainWindow��$	��600��$	��800�� � 
ResizeMode$ NoResize=� � 	Resources  �� Source�� $A ;/CommonStylesResources/Theme1CommonStyles/CommonStyles.xaml?�%    .���    WindowBackgroundStyle#��[   � RowDefinitions �� $��80 ��� $	��440 ��� $��80 � � ColumnDefinitions �� $��* ��� $	��200 �.+��� $��0��$��2��  MainHeaderStyle#��[ .��Welcome to Expense Manager�� $��4q� �� CornerRadius$ 4��$��1��$��0��
�������._���     ExpenseTracker.RegionNames   
MainRegion5  /Microsoft.Practices.Prism.Regions.RegionManager   
RegionName# Z �� $��4q�$ 4��$��1��$��1��
�������._��� 	   NavigationRegion# Z	 �� $��2q�$ 4��$��2��$��2��
�������._��� 
   StatusBarRegion# Z
 