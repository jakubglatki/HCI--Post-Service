   M S B A M L   `   `   `  ����L  HHCI- Post Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HCI__Post_ServiceHCI__Post_Service  5   	   Y1clr-namespace:HCI__Post_Service.UserControlFolder#HCI__Post_Service.UserControlFolder  67   )    #HCI__Post_Service.SendMessageWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HCI__Post_Service     5   	   Dlocal11clr-namespace:HCI__Post_Service.UserControlFolder     67   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  6x     � Title$  Send Message��5   	   $	��640��6   $
��1280��6+   .��5	      � -   5         �Name$ gridViewSendMessage��5	       � ColumnDefinitions 5
   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $	��400 �6   �� 5      $��15 �6    � RowDefinitions 5   
   �� 5      $��15 �6   �� 5      $��70 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��* �6   �� 5      $��50 �6   �� 5      $��15 �6   .+�5   
   �� 
������� J� IsHitTestVisible .  $��0��6?   $��8��6L   $��0��6]   $��5��6m   �� 5   
   
������� .  $��0��6?   $��8��6O   $��1��6c   �� 5!   
   -   5         ��Name$ senderSelect��5!      $��1��6)   $
��Left=�69   $��1��6U   $��Center=�6b   $	��300��6}   (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5#   
   -   5          Name$ receiverName��5#   0   $��1��6       	Watermark$ Receiver��6F   $��Stretch=�6[   $��2��6z   $��2��6�   $��Center=�6�     5&   
   -   5        $ subject��5&       $��1��61   $��Stretch=�6A   $��3��6`   $��2��6m   $��Center=�6�   $
��Bold"�6�   $ Subject��6�   5   /HCI__Post_Service.UserControlFolder.TextControl  5*   
   -   5          Name$ content��5*      $��1��6.   $��Stretch=�6>   $��4��6]   $��Stretch=�6j   $��2��6�   �� 5,   
   -   5        	 ��Name$	 buttonAttachment��5,      $��Add Attachment��6+   $��2��6D   $
��Left=�6T   $��	50,10,0,0q�6o   $��5��6�   $	��Top=�6�   $	��140��6�   $��30��6�   
�������$��13(�6�   6�   �� 5.   
   -   5        $	 
buttonSend��5.      $
��Send��6&   $��2��65   $��Right=�6E   $��0,10,0,0q�6a   $��5��6s   $	��Top=�6�   $	��140��6�   $��30��6�   
�������$��20(�6�   6�   �� 50   
   -   5        
 ��Name$
 boxAttachments��50      $��1��6*   $��Stretch=�6:   $��40��6X   $��0,10,0,0q�6d   $��5��6v   $��Stretch=�6�   ��51      �� 52      .R�53      $�  K� IsItemsHost .  $� Orientation$ 
Horizontal=�6@   54      56      58      59      