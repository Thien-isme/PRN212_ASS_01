   M S B A M L   `   `   `  ����G  CNhatThienWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ThienWPFThienWPF  5   	       ThienWPF.CustomerScreen   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ThienWPF     5   	     � Title$  Customer Dashboard��5   	   $	��600��6$   $	��900��61    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ lblWelcomeMessage��5      $��0��5      $��20q�5      $��24(�5      $
��Bold"�5      $��Center=�5      $��Welcome!��5      �� 5   
   -   5        $��1��5      $��10q�6"   .@�5      �� -   5         ��Name$ TimOrderHistory��5      $��Order History��6/   .��5      � $��10q�6    � ColumnDefinitions 5      �� 5       5      �� 5      $��* �6(   �� 5       $
��Auto �6(   .+�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ dgOrderHistory��5#      $��0��5$         AutoGenerateColumns$ False��5%         
IsReadOnly$
 True��5&      	   CanUserAddRows$	 False��5'      $��0,10,0,0q�5(      
   Columns
 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ OrderID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *	OrderID+6^     5+      $ 
CustomerID��61   $	 150 6d    6E   �� *
CustomerID+6d     5,      $ 
EmployeeID��61   $	 150 6d    6E   �� *
EmployeeID+6d     5.      $ 	OrderDate��61   $ * 6�    6D   �� *	OrderDate+ �� StringFormat$ {0:dd/MM/yyyy}��6�   51      �� 53      $��1��6!    �� Orientation$ 
Horizontal=�6.   $��Right=�6G   $��0,10,0,0q�6c   $��99��6u   .+�54      �� -   5        $��Refresh��54   !   $��5q�63   $
��10,5q�6>   6M   55      56      57      �� 59      -   5        $ 
timProfile��59      $��
My Profile��6*   .��5:      � $��20q�6    5;      �� 5<      $
��Auto �6+   �� 5=      $��* �6+    5?      �� 5@      $
��Auto �6(   �� 5A      $
��Auto �6(   �� 5B      $
��Auto �6(   �� 5C      $
��Auto �6(   �� 5D      $
��Auto �6(   �� 5E      $��* �6(   .+�5H      �� -   5        $ lblCompanyName��5H       $��CompanyName��68   $��0��6K   $��0��6X   $��5q�6h   $��Center=�6s   �� 5I      -   5         ��Name$ txtCompanyName��5I      $��0��66   $��1��6C   $��5q�6S   $��5q�6^   �� 5K      $��ContactName��6    $��1��63   $��0��6@   $��5q�6P   $��Center=�6[   �� 5L      -	   5        $ txtContactName��5L      $��1��66   $��1��6C   $��5q�6S   $��5q�6^   �� 5N      $��Contact Title��6    $��2��65   $��0��6B   $��5q�6R   $��Center=�6]   �� 5O      -
   5        $ txtContactTitle��5O      $��2��67   $��1��6D   $��5q�6T   $��5q�6_   �� 5Q      $��Address��6    $��3��6/   $��0��6<   $��5q�6L   $��Center=�6W   �� 5R      -   5        $ 
txtAddress��5R      $��3��62   $��1��6?   $��5q�6O   $��5q�6Z   �� 5T      $��Phone��6    $��4��6-   $��0��6:   $��5q�6J   $��Center=�6U   �� 5U      -   5        $ txtPhone��5U      $��4��60   $��1��6=   $��5q�6M   $��5q�6X    �� 
IsReadOnly$
 True��6d   ���#EEEEEE6v   �� 5W      $��5��6!   $��2��6.   $ 
Horizontal=�6B   $��Right=�6[   $��0,20,0,0q�6w   �� 5X      -   5        $
��Save��5X      $
��15,8q�6,   $��1��6U   $��6,5,557,160q�6e   $��5��6z   5Y      5Z      5[      5\      5]      