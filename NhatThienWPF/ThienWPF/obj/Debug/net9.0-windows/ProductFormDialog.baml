   M S B A M L   `   `   `  ����  NhatThienWPF     ThienWPF.ProductFormDialog   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Product Information��5   	   $
��Auto��6%   $	��400��63    � WindowStartupLocation$ CenterScreen=�5   	    � SizeToContent$ Height=�5	   	    � 
ResizeMode$ NoResize=�6    .��5
      �� 
�������$��1q�6%    �� CornerRadius$ 5��69    �� Padding$ 15q�6J   $��10q�6W   ._�5   
   �� .+�5      �� -   5         ��Name$ lblDialogTitle��5      $��Thêm Sản phẩm mới��60   $
��Bold"�6I   $��18(�6[   $��0,0,0,15q�6i   $��Center=�6{   � 5       � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��
ProductID:��6   $��0��6.   $��0��6;   $��5q�6K   $��Center=�6V   �� 5      -   5        	 ��Name$	 txtProductID��5      $��0��60   $��1��6=   $��5q�6M   $��5q�6X   
 �� 
IsReadOnly$

 True��6d   ���#F0F0F06v   �� 5      $��ProductName:��6   $��1��60   $��0��6=   $��5q�6M   $��Center=�6X   �� 5       -   5        $	 txtProductName��5       $��1��62   $��1��6?   $��5q�6O   $��5q�6Z   �� 5"      $��	Category:��6   $��2��6-   $��0��6:   $��5q�6J   $��Center=�6U   �� 5#      -   5         ��Name$ cbxCategory��5#      $��2��60   $��1��6=   $��5q�6M   $��5q�6X    �� DisplayMemberPath$ CategoryName��6d    �� SelectedValuePath$ 
CategoryID��6�   �� 5%      $��
UnitPrice:��6   $��3��6.   $��0��6;   $��5q�6K   $��Center=�6V   �� 5&      -   5        $	 txtUnitPrice��5&      $��3��60   $��1��6=   $��5q�6M   $��5q�6X   �� 5(      $��UnitsInStock:��6   $��4��61   $��0��6>   $��5q�6N   $��Center=�6Y   �� 5)      -   5        $	 txtUnitsInStock��5)      $��4��63   $��1��6@   $��5q�6P   $��5q�6[   �� 5+      $��QuantityPerUnit:��6   $��5��64   $��0��6A   $��5q�6Q   $��Center=�6\   �� 5,      -   5        $	 txtQuantityPerUnit��5,      $��5��66   $��1��6C   $��5q�6S   $��5q�6^   5-      �� 5.       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��0,20,0,0q�6N   .+�5/      �� -   5        $
��Save��5/      $��5q�6(   $
��15,8q�63   6B   �� 50      -	   5        $��Cancel��50      $��5q�6*   $
��15,8q�65   6D   51      52      53      54      