   M S B A M L   `   `   `  ����F  BDelivery.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Delivery.UIDelivery.UI  5   	       Delivery.UI.Registration   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Delivery.UI     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Registration��5	   	   $	��600��6   $	��500��6+    � WindowStyle$
 None=�67    � WindowStartupLocation$ CenterScreen=�6J    � 	Resources 5         WeakStatusStyle �� 
TargetType �� Property �� Value  MediumStatusStyle  StrongStatusStyle��%n  &	        &	 p     &	 �     �� 5   
   " ��6(   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��
 �  ��6+   5      �� 5   
   " ��6*   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��
 � ���6+   5      �� 5   
   " ��6*   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��
 � � �6+   5      5      .��5      � ���	#ffdadada$��0,0,0,0q�6"   .+�5   
   �� $	��400��6   $��15q�6    
�������$��Center=�6?    �� Padding$ 40q�6Z   $	��550��6g    �� CornerRadius$ 20��6v   	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5       
   
BlurRadius$
 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   ._�5"      �� .+�5#      �� $��Create account��6   $��30(�62   $
��Bold"�6@   $��0 0 0 20q�6R   � 5$      $��0 0 0 0q�6   .+�5%      �� -   5        $
��Left=�5%      $
��Exit��69   6H   �� 5&      -   5        $��Right=�5&      $��Login��69     MaterialDesignFlatButton#��[ 6`   5'      �� 5)      -   5         ��Name$ txtBoxLogin��5)      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Insert Name��6/    % !MaterialDesignFloatingHintTextBox#��[ 6\   G� 5*      -   5         G�Name$ passboxInsert��5*      $ Insert Password��65    ) %MaterialDesignFloatingHintPasswordBox#��[ 6f   6�   �� 5+      -   5         ��Name$ labelstatus��5+      $�� ��6-   $��23��68   G� 5,      -   5        $ passboxCheck��5,      $ Repeat Password��64   #��[ 6e   �� 5-      -   5        $ txtBoxEmail��5-      $ Insert Email��6/   #��[ 6]   �� 5.      -   5        $ txtBoxPhone��5.      $ Insert Phone��6/   #��[ 6]   �� 5/      -	   5        $��Regestration��5/      $
��0 20q�60   6>   �� 50      $(��"Do not share your data with anyone��6   $��Center=�6E   $��0,0,0,0q�6b   51      52      53      54      