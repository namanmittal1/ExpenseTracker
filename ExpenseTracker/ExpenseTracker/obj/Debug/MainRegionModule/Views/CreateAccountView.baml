   M S B A M L   `   `   `  ����  ExpenseTracker=    7ExpenseTracker.MainRegionModule.Views.CreateAccountView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5       �� Source�� 5	   
   $A ;/CommonStylesResources/Theme1CommonStyles/CommonStyles.xaml?�6   %    .��5      � $��Center=�6   $��Center=�6(    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��200 �6   .+�5   
   �� $��Create new account��6      Header1Style#��[  6-   $��2��6S   $��Center=�6g   �� 5   
   $��1��6   $��0��6   $��Center=�6-   $��Account Name��6H     
LabelStyle#��[ 6_   �� 5   
   -   5        $��AccountName��5      $��1��6%   $��1��62   $��40��6B   ��6N   �� *AccountName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��2��6   $��0��6   $��Center=�6-   $��Password��6H   #��[ 6[   G� 5   
   -   5        $��pwdBox��5      $��2��6$   $��1��61   $��40��6A   $��Times New Roman)�6M   $��16(�6j   $
��Bold"�6x   �� 5   
   -   5         ��Name$ btnCreateAccount��5      $��3��6+   $��1��68   $��Create��6H   $��40��6Y   $	��100��6e   $��Right=�6q   $��Times New Roman)�6�   $��16(�6�   $
��Bold"�6�   ��6�   ��  �� Path$ CreateAccountCommand���6�   ��  �� ElementName$ pwdBox��5      5      