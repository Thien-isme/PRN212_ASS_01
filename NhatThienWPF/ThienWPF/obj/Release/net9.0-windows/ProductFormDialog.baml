   M S B A M L   `   `   `  ����   NhatThienWPF     ThienWPF.ProductFormDialog   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Product Information��$
��Auto��$	��400�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Height=� � 
ResizeMode$ NoResize=�.���� 
�������$��1q� �� CornerRadius$ 5�� �� Padding$ 15q�$��10q�._��� .+��� -    ��Name$ lblDialogTitle��$��Thêm Sản phẩm mới��$
��Bold"�$��18(�$��0,0,0,15q�$��Center=��  � ColumnDefinitions �� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��
ProductID:��$��0��$��0��$��5q�$��Center=��� -   	 ��Name$	 txtProductID��$��0��$��1��$��5q�$��5q�
 �� 
IsReadOnly$

 True�����#F0F0F0�� $��ProductName:��$��1��$��0��$��5q�$��Center=��� -   $	 txtProductName��$��1��$��1��$��5q�$��5q��� $��	Category:��$��2��$��0��$��5q�$��Center=��� -    ��Name$ cbxCategory��$��2��$��1��$��5q�$��5q� �� DisplayMemberPath$ CategoryName�� �� SelectedValuePath$ 
CategoryID���� $��
UnitPrice:��$��3��$��0��$��5q�$��Center=��� -   $	 txtUnitPrice��$��3��$��1��$��5q�$��5q��� $��UnitsInStock:��$��4��$��0��$��5q�$��Center=��� -   $	 txtUnitsInStock��$��4��$��1��$��5q�$��5q��� $��QuantityPerUnit:��$��5��$��0��$��5q�$��Center=��� -   $	 txtQuantityPerUnit��$��5��$��1��$��5q�$��5q���  �� Orientation$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -   $
��Save��$��5q�$
��15,8q��� -	   $��Cancel��$��5q�$
��15,8q�