   M S B A M L   `   `   `  ����  NhatThienWPF!    ThienWPF.OrderDetailsDialog   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Order ��5   	   $	��450��6   $	��600��6%    � WindowStartupLocation$ CenterScreen=�5   	   .��5	      �� $��15q�6   .+�5
   
   �� $��Order Details��6   $
��Bold"�6)   $��18(�6;   $��0,0,0,10q�6I   $��Center=�6[   � 5   
   $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��OrderID:��6   $��0��6(   $��0��65   $��5q�6E   $��SemiBold"�6P   �� 5      -   5         ��Name$ 
txtOrderId��5      $��0��6,   $��1��69   $��5q�6I   �� 5      $��
OrderDate:��6   $��1��6*   $��0��67   $��5q�6G   $��SemiBold"�6R   �� 5      -   5        $ txtOrderDate��5      $��1��6.   $��1��6;   $��5q�6K   �� 5      $��CompanyName:��6   $��2��6,   $��0��69   $��5q�6I   $��SemiBold"�6T   �� 5      -   5        $ txtCustomerName��5      $��2��61   $��1��6>   $��5q�6N   5      �� 5!   
   $��Products in Order:��6   $��SemiBold"�6.   $��0,0,0,5q�6D   &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ dgOrderItems��5"         AutoGenerateColumns$ False��6)      
IsReadOnly$
 True��6E   $	��200��6W      CanUserAddRows$ False��6d   	   CanUserDeleteRows$	 False��6{   
   Columns
 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ProductID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	ProductId+6V     5%      $ ProductName��6%   $ * 6Z    6:   �� *ProductName+6Z     5&      $ Quantity��6%   $
 Auto 6T    67   �� *
Quantity+6T     5'      $ 	UnitPrice��6%   $
 Auto 6�    68   �� *	UnitPrice+ �� StringFormat$ C�� �� ConverterCulture$ en-US��6�     5(      $ Discount (%)��6%   $
 Auto 6k    6;   �� *
Discount+$ P0��6k     5)      $ TotalForItem��6%   $
 Auto 6�    6;   �� *TotalForItem+$ C��$ en-US��6�   5+      �� 5-   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��0,15,0,0q�6J   .+�5.      �� $��Tổng Cộng:��6   $
��Bold"�6*   $��16(�6<   $��Center=�6J   $��0,0,10,0q�6e   �� 5/      -   5        $ txtGrandTotal��5/      $
��Bold"�6/   $��16(�6A   $��Center=�6O   50      �� 52   
   -   5        $��Đóng��52      $��0,20,0,0q�6    $
��15,8q�62   $��Center=�6A   6^   53      54      