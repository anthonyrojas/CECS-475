   M S B A M L   `   `   `  ���� J  FAssignment3Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Assignment3Mvvm.ViewsAssignment3Mvvm.Views  )    #Assignment3Mvvm.Views.AddMemberView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:Assignment3Mvvm.Views     -     �Name$  AddMemberWindow�� � Title$ 
Add Member��$	��400��$	��500�� � 
ResizeMode$ NoResize=�.���  � DataContext �� *AddViewModel+   ViewModelLocator �� Source# [   � ColumnDefinitions �� $	��150 ��� $	��350 � � RowDefinitions �� $��80 ��� $��80 ��� $��80 ��� $��80 �.+��� $��0��$��0��$��First Name:��$��Center=�$��Center=�$
��Bold"��� $��0��$��1��$��30��$	��300��$��Right=�$��0,0,30,0q�$��1q�
���   ����� *AddFirstNameTextBox+�� $��1��$��0��$��
Last Name:��$��Center=�$��Center=�$
��Bold"��� $��1��$��1��$��30��$	��300��$��Right=�$��0,0,30,0q�
���   �$��1q����� *AddLastNameTextBox+�� $��2��$��0��$��Email:��$��Center=�$��Center=�$
��Bold"��� $��2��$��1��$��30��$	��300��$��Right=�$��0,0,30,0q�
���   �$��1q����� *AddEmailTextBox+�� $��2��$
��Save��$
��Left=�$��106,34.6,0,0q�$��3��$	��Top=�$��75������ *
AddCommand+ �� Mode$ OneTime=�����  �� ElementName$ AddMemberWindow���� $��Cancel��$��1��$
��Left=�$��165,34.6,0,0q�$��3��$	��Top=�$��75������ *CancelCommand+���� $ AddMemberWindow��