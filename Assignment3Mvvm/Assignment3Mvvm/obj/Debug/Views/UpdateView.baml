   M S B A M L   `   `   `  ����J  FAssignment3Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Assignment3Mvvm.ViewsAssignment3Mvvm.Views  5   	   &     Assignment3Mvvm.Views.UpdateView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Assignment3Mvvm.Views     5   	   -   5          �Name$  UpateMemberWindow��5   	    � Title$ Update Member��5	   	   $	��400��6   $	��500��6,    � 
ResizeMode$ NoResize=�68   .��5
      �  � DataContext 6   �� *UpdateViewModel+   ViewModelLocator �� Source# [   � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��350 �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��80 �6   �� 5      $��80 �6   �� 5      $��80 �6   .+�5   
   �� $��0��6   $��0��6!   $��First Name:��61   $��Center=�6D   $��Center=�6_   $
��Bold"�6|   �� 5   
   $��0��6   $��1��6   $��30��6/   $	��300��6;   $��Right=�6G   $��0,0,30,0q�6c   $��1q�6u   
���   ���6�   �� *FirstNameTextBox+�� 5   
   $��1��6   $��0��6!   $��
Last Name:��61   $��Center=�6C   $��Center=�6^   $
��Bold"�6{   �� 5   
   $��1��6   $��1��6   $��30��6/   $	��300��6;   $��Right=�6G   $��0,0,30,0q�6c   
���   �$��1q�6�   ��6�   �� *LastNameTextBox+�� 5   
   $��2��6   $��0��6!   $��Email:��61   $��Center=�6?   $��Center=�6\   $
��Bold"�6w   �� 5   
   $��2��6   $��1��6   $��30��60   $	��300��6<   $��Right=�6H   $��0,0,30,0q�6d   
���   �$��1q�6�   ��6�   �� *EmailTextBox+�� 5   
   $��2��6   $
��Save��6%   $
��Left=�64   $��106,34.6,0,0q�6O   $��3��6e   $	��Top=�6r   $��75��6�   ��6�   �� *UpdateCommand+ �� Mode$ OneWay=���6�   ��  �� ElementName$ UpateMemberWindow���� 5   
   $��Cancel��6   $��1��6"   $
��Left=�62   $��165,34.6,0,0q�6M   $��3��6c   $	��Top=�6p   $��75��6�   ��6�   �� *CancelCommand+��6�   �� $ UpateMemberWindow��5      5      