   M S B A M L   `   `   `  ����F  BDelivery.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Delivery.UIDelivery.UI  5   	       Delivery.UI.OrdersTable   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Delivery.UI     5   	     � Title$  OrdersTable��5   	   $	��450��6   $	��800��6*    � WindowStyle$
 None=�66    � WindowStartupLocation$ CenterScreen=�6I   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ orderItemDataGrid��5      $��10,10,10,192q�6.      AutoGenerateColumns$ False��6D      
IsReadOnly$
 True��6`      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ User ID��6%    66   �� *UserId+  5      $ Order ID��6%    67   �� *
OrdersId+  5      $ 	Dish Name��6%    68   �� *
NameDish+  5      $ 
Order Date��6%    69   �� *	OrderDate+  5      $ 
Dish Price��6%    69   �� *	DishPrice+  5      $ Address��6%    66   �� *	Address+  5      $ Status��6%    65   �� *Orders.status.Name+5      �� 5   
   -   5        	 ��Name$	 UserPhoneTxtBox��5      $
��Left=�6+   $��	5,275,0,0q�6F   
 �� TextWrapping$

 Wrap=�6Y   $��Ведіть номер��6m   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $��Інфо��5      $
��Left=�6    $��148,275,0,0q�6;   $	��Top=�6P   $��28��6h   $��94��6t   6   �� 5   
   -   5         ��Name$ 
ChekButton��5      $��Чек��6%   $
��Left=�63   $��268,275,0,0q�6N   $	��Top=�6c   $��28��6{   $��94��6�   6�   �� 5   
   -   5         ��Name$ DeliverList��5      $��0,308,438,3q�6R   $y�	Collapsed=�6g   �� 5   
   -   5        $ ChangeStatusButton��5      $��
Взяти��6-   $
��Left=�6=   $��388,309,0,0q�6X   $	��Top=�6m   $��28��6�   $��94��6�   $y�	Collapsed=�6�   �� 5   
   -   5        $ FinishOrderBTN��5      $��Закінчити��6)   $
��Left=�6=   $��388,356,0,0q�6X   $	��Top=�6m   $��28��6�   $��94��6�   $y�	Collapsed=�6�   �� 5   
   -   5        $ Deliver��5      $��Я Кур'єр��6"   $
��Left=�65   $��660,369,0,0q�6P   $	��Top=�6e    J� RenderTransformOrigin$ 0.499,0.254&�6�   �� 5   
   -	   5        $
 Back��5      $�� Exit ��6   $
��Left=�60   $��
702,10,0,0q�6K   $	��Top=�6_   $��29��6w   $��88��6�   6�   �� 5    
   $C��=На табло лише активні замовлення!��6   $
��Left=�6<   $��541,289,0,0q�6W   $	��Top=�6l   5&      5'      