   M S B A M L   `   `   `  ����   NhatThienWPF!    ThienWPF.CustomerFormDialog   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  CreateCustomerScreen��$
��Auto��$	��400�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Height=� � 
ResizeMode$ NoResize=�.���� 
�������$��1q� �� CornerRadius$ 5�� �� Padding$ 15q�$��10q�._��� .+��� -    ��Name$ lblDialogTitle��$��Create new Customer��$
��Bold"�$��18(�$��0,0,0,15q�$��Center=��  � ColumnDefinitions �� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��CustomerID:��$��0��$��0��$��5q�$��Center=��� -   	 ��Name$	 txtCustomerID��$��0��$��1��$��5q�$��5q�
 �� 
IsReadOnly$

 True�����#F0F0F0�� $��CompanyName:��$��1��$��0��$��5q�$��Center=��� -   $	 txtCustomerCompanyName��$��1��$��1��$��5q�$��5q��� $��ContactName:��$��2��$��0��$��5q�$��Center=��� -   $	 txtCustomerContactName��$��2��$��1��$��5q�$��5q��� $��ContactTitle:��$��3��$��0��$��5q�$��Center=��� -   $	 txtCustomerContactTitle��$��3��$��1��$��5q�$��5q��� $��Address:��$��4��$��0��$��5q�$��Center=��� -   $	 txtCustomerAddress��$��4��$��1��$��5q�$��5q��� $��Phone:��$��5��$��0��$��5q�$��Center=��� -   $	 txtCustomerPhone��$��5��$��1��$��5q�$��5q���  �� Orientation$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -   $
��Save��$��5q�$
��15,8q��� -	   $��Cancel��$��5q�$
��15,8q�