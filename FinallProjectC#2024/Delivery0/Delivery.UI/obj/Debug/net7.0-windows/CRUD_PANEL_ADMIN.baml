   M S B A M L   `   `   `  ����F  BDelivery.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Delivery.UIDelivery.UI  5   	   "    Delivery.UI.CRUD_PANEL_ADMIN   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Delivery.UI     5   	     � Title$  CRUD_PANEL_ADMIN��5   	   $	��450��6"   $	��800��6/    � WindowStyle$
 None=�6;    � WindowStartupLocation$ CenterScreen=�6N   .��5
      � 
�������$	��450��6   $	��800��6+    � ColumnDefinitions 5   
   �� 5      �� 5      $��4* �6   �� 5      $��0* �6   .+�5   
   � ���	#FF1976D2.+�5      �� $��Страва��6   $��Center=�6&   $��Center=�6A   $��24(�6^   
�������6l   5      � 5   
   $��1��6   ���	#FFE0E0E0.+�5      �� $��20q�6   .+�5      �� $��
Назва��6   $��16(�6)   $
��0 10q�67   �� 5      -   5         ��Name$ 
NameTxtBox��5      $��Введіть назву��6.    %  !MaterialDesignFloatingHintTextBox#��[  6C   $��0 0 0 20q�6~   �� 5      $��Ціна��6   $��16(�6(   $
��0 10q�66   �� 5      -   5        $ PriceTxtBox��5      $��Введіть ціну��6/   #��[  6C   $��0 0 0 20q�6~   �� 5      $��Фото��6   $��16(�6'   $
��0 10q�65   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $ photoTextBox��5      $�� ��64   #��[  6<    �� 
IsReadOnly$
 True��6w   $	��150��6�   $��0 0 10 0q�6�   �� 5      -   5        $��Обрати��5      
���� ��6B   5      5      5      �� 5    
   -   5        $��Меню��5       
���� ��$��1��6Q   $��534,395,25,23q�6a   �� 5!   
   -   5        $��Створити��5!      
���� ��$��1��6Q   $��15,339,18,79q�6a    J� RenderTransformOrigin$ 0.5,0.5&�6w   z�5"      V� 5#      .~�5$      �� �� 5%      �� 5&       �� Angle$ -0.429Q�6&   T� 5'      5(      5*      5+      5,      