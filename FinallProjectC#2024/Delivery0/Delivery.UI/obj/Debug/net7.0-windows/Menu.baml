   M S B A M L   `   `   `  ����F  BDelivery.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Delivery.UIDelivery.UI  5   	       Delivery.UI.Menu   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Delivery.UI     5   	     � Title$
  Menu��5   	   $	��450��6   $
��1000��6#    � WindowStyle$
 None=�60    � WindowStartupLocation$ CenterScreen=�6C   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��201* �6   �� 5      $��8* �6   �� 5      $
��431* �6   �� 5      $
��160* �6   .+�5   
   �� $��1��6   
����ح�$��2��68   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ MenuDataGrid��5      $��1��6-   
����ح�$��2��6T      AutoGenerateColumns$ False��6h      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Назва страви��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Name+  5      $ Ціна��6)    67   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Фото страви��6-   	   CellTemplate	 5      �� 5      .R�5   "   �� $	��100��6E   $	��100��6Q   ��6(   �� *	PhotoPath+6Q   5      5        5      $ Дії��6-   	 5      �� 5       .R�5!   "   �� 
 �� Orientation$
 
Horizontal=�6-   .+�5"   &   �� -   5        $��Додати��5"   -   $��5q�6V   5#   #   5$      5&      5(      5*      �� 5-   
   -   5         ��Name$ LogoRest��5-      $
��Left=�6"   $	��142��6=   $��	57,10,0,0q�6J   $	��Top=�6]   $	��130��6u   �� 5/   
   -   5         ��Name$ SearchTxtBox��5/      
������� �� TextWrapping$
 Wrap=�6<   $��Назва страви��6P   $��
0,10,0,392q�6d   $��3��6�   �� 51   
   -   5         ��Name$ Review��51      $��3��6!   $��Відгук��61   $��Center=�6B   $	��Top=�6_   $��28��6w   $	��140��6�   $��0,82,0,0q�6�   6�   �� 52   
   -   5        $ CreateOrderButton��52      $��3��6,   $��Замовлення��6<   $��Center=�6Q   $	��Top=�6n   $��28��6�   $	��140��6�   $��	0,270,0,0q�6�   6�   �� 53   
   -   5         ��Name$ OrdersListBox��53      $��3��6)   $��0,157,0,203q�6d   �� 54   
   -   5        $ PhoneInformationTextBox��54      $��3��63   $��Center=�6C   $��	0,303,0,0q�6`   $
 Wrap=�6s   $"��3. Введіть номер��6�   $	��Top=�6�   $	��140��6�   �� 55   
   -	   5        $ AdressTextBox��55      $��3��6)   $��Center=�69   $��	0,346,0,0q�6V   $
 Wrap=�6i   $"��4. Введіть адрес��6}   $	��Top=�6�   $	��140��6�   �� 56   
   -
   5        $ PanelOrderButton��56      $'��!Таблиця замовлень��6+   $��Center=�6G   $	��Top=�6d   $��28��6|   $	��180��6�   $��	0,396,0,0q�6�   $��3��6�   �� 57   
   -   5        $ ReviewTextListBox��57      $��	0,266,0,0q�6X   6k   �� 58   
   -   5         ��Name$ Rating��58      $��Рейтинг��6    $
��Left=�62   $��
73,178,0,0q�6M   $	��Top=�6a   $��18(�6y   $
��Bold"�6�   �� 59   
   -   5        $ RestName��59      $��Ресторан��6"   $��Center=�65   $��	0,150,0,0q�6R   $	��Top=�6e   $��22(�6}   $
��Bold"�6�   �� 5:   
   $��3��6   $8��2Крок 1. Створіть замовлення.��6    $��Center=�6G   $��	0,247,0,0q�6d   $	��Top=�6w   $��24��6�   �� 5;   
   $��3��6   $?��92 .Оберіть створене замовлення .��6    $��Center=�6K   $��	0,133,0,0q�6h   $	��Top=�6{   $��24��6�   5?      5@      