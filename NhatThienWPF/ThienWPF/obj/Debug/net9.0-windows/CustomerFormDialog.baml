   M S B A M L   `   `   `  ����  NhatThienWPF!    ThienWPF.CustomerFormDialog   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  CreateCustomerScreen��5   	   $
��Auto��6&   $	��400��64    � WindowStartupLocation$ CenterScreen=�5   	    � SizeToContent$ Height=�5	   	    � 
ResizeMode$ NoResize=�6    .��5
      �� 
�������$��1q�6%    �� CornerRadius$ 5��69    �� Padding$ 15q�6J   $��10q�6W   ._�5   
   �� .+�5      �� -   5         ��Name$ lblDialogTitle��5      $��Create new Customer��60   $
��Bold"�6K   $��18(�6]   $��0,0,0,15q�6k   $��Center=�6}   � 5       � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��CustomerID:��6   $��0��6/   $��0��6<   $��5q�6L   $��Center=�6W   �� 5      -   5        	 ��Name$	 txtCustomerID��5      $��0��61   $��1��6>   $��5q�6N   $��5q�6Y   
 �� 
IsReadOnly$

 True��6e   ���#F0F0F06w   �� 5      $��CompanyName:��6   $��1��60   $��0��6=   $��5q�6M   $��Center=�6X   �� 5      -   5        $	 txtCustomerCompanyName��5      $��1��6:   $��1��6G   $��5q�6W   $��5q�6b   �� 5!      $��ContactName:��6   $��2��60   $��0��6=   $��5q�6M   $��Center=�6X   �� 5"      -   5        $	 txtCustomerContactName��5"      $��2��6:   $��1��6G   $��5q�6W   $��5q�6b   �� 5$      $��ContactTitle:��6   $��3��61   $��0��6>   $��5q�6N   $��Center=�6Y   �� 5%      -   5        $	 txtCustomerContactTitle��5%      $��3��6;   $��1��6H   $��5q�6X   $��5q�6c   �� 5'      $��Address:��6   $��4��6,   $��0��69   $��5q�6I   $��Center=�6T   �� 5(      -   5        $	 txtCustomerAddress��5(      $��4��66   $��1��6C   $��5q�6S   $��5q�6^   �� 5*      $��Phone:��6   $��5��6*   $��0��67   $��5q�6G   $��Center=�6R   �� 5+      -   5        $	 txtCustomerPhone��5+      $��5��64   $��1��6A   $��5q�6Q   $��5q�6\   5,      �� 5-       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��0,20,0,0q�6N   .+�5.      �� -   5        $
��Save��5.      $��5q�6(   $
��15,8q�63   6B   �� 5/      -	   5        $��Cancel��5/      $��5q�6*   $
��15,8q�65   6D   50      51      52      53      