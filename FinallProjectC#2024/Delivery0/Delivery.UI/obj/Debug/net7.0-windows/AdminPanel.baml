   M S B A M L   `   `   `  ����F  BDelivery.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Delivery.UIDelivery.UI  5   	       Delivery.UI.AdminPanel   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Delivery.UI     5   	     � Title$  
AdminPanel��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�65    � WindowStartupLocation$ CenterScreen=�6H   .��5	      �  J� RenderTransformOrigin$ 0.5,0.5&�6   z�5
   
   V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.242Q�6"   T� 5      5       � ColumnDefinitions 5   
   �� 5      $
��163* �6   �� 5      $
��196* �6   �� 5      $
��Auto �6   �� 5      $
��360* �6   .+�5   
   �� -   5         ��Name$ RestourantListBox��5   "   $��0��6   $��Stretch=�6=   $��Stretch=�6b   $��3��6�   $��0,0,80,0q�6�   5      �� 5   
   -   5        $��2��5      $ ��Додати до меню��6!   $��Center=�6:   $��Center=�6W   $��32��6�   $��81��6�   �� 5    
   -   5        $��2��5       $
��Menu��6!   $��Center=�60   $	��Top=�6M   $��32��6�   $��81��6�   $��	0,157,0,0q�6�   �� 5#   
   -   5        $ dishListBox��5#   "   $��2��6   $��Stretch=�67   $��Stretch=�6\   $��2��6�   $��80,0,0,0q�6�   5&      �� 5'   
   $��1��6   $��Ресторан��6    $
��Left=�63   $��	130,0,0,0q�6N   $	��Top=�6a   �� 5(   
   $��3��6   $��Страва��6    $
��Left=�61   $��	304,0,0,0q�6L   $	��Top=�6_   �� 5)   
   -   5        $��2��5)      $
��Exit��6!   $��Center=�60   $	��Top=�6M   $��32��6~   $��81��6�   $��	0,255,0,0q�6�   �� 5*   
   -   5        $��2��5*      $��ReLog��6!   $��Center=�61   $	��Top=�6N   $��32��6g   $��81��6s   $��	0,296,0,0q�6~   6�   5+      5,      