   M S B A M L   `   `   `  ����L  HHCI- Post Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:HCI__Post_Service.UserControlFolder#HCI__Post_Service.UserControlFolder  5      5    /HCI__Post_Service.UserControlFolder.TextControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:HCI__Post_Service.UserControlFolder     5      X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   9� -   5         9�Name$ expander��5      
�������$��0��68    9� 
IsExpanded . $��Stretch=�6W   .��5      ]� -   5         ]�Name$ panelButtonsExpander��5      $��Stretch=�67   .+�5      �� -   5         ��Name$ bBold��5   B   $��	50,0,0,10q�6   
�������
�������.��5      �� $��25��6   $��25��6'   $��..\Resources\bold.png��63   5      �� 5      -   5        $ bItalic��5   B   $��	20,0,0,10q�6   
�������
�������.��5      �� $��25��6   $��25��6'   $��..\Resources\italic.png��63   5      �� 5      -   5        $ 
bUnderline��5   B   $��	20,0,0,10q�6   
�������
�������.��5      �� $��25��6   $��25��6'   $ ��..\Resources\underline.png��63   5      �� 5       -   5         ��Name$ cbSize��5       $��	30,0,0,10q�6+   $��40��6>   $
��Left=�6I   $��Center=�6k   $��Medium"�6�   6�   #  Xceed.Wpf.Toolkit.ColorPicker  5"      -   5        $��colorPicker��5"   #   $��	30,0,0,10q�66   $��50��6I      SelectedColor$ BlackX�6T   6j   �� 5$      -   5        $ cbFontFamily��5$      $��	30,0,0,10q�61   $��20��6D   $	��130��6P   6\   �� 5&      -	   5        $ bClearFormatting��5&   l   $��
50,0,50,10q�6   $��13(�6.   
���   �$��Right=�6P   $��Clear all formating��6�   6�   5(      5+      �� 5-   
   -
   5         ��Name$ richTextBox��5-      $��1��6+   $��5,5,5,5q�68   $��11(�6J   	 � 	Resources	 5.      
 �� 
TargetType��%"   'J�       �� 5/      "
 J�6   51      52      53      54      