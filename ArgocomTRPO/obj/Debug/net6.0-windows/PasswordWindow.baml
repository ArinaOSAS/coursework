   M S B A M L   `   `   `  ����F  BArgocomTRPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ArgocomTRPOArgocomTRPO  5   	        ArgocomTRPO.PasswordWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   +localclr-namespace:ArgocomTRPO     5   	     � Title$  PasswordWindow��5   	   $	��350��6    $	��450��6-    � WindowStyle$
 None=�69    � WindowStartupLocation$ CenterScreen=�6L    � 
ResizeMode$ NoResize=�6r   .��5	      � .+�5
   
   �� 
�������._�5      �  � RowDefinitions 5      �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61    � ColumnDefinitions 5      �� 5      $��* �6'   63   .+�5      �� $��0��6   $��2��6&   $��6��6:   
���   �$��2q�6_   
�������$��10q�6�    �� CornerRadius$ 30��6�    �� Padding$ 30q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 30Q�6+   
   Color$
 	LightGray��6;   5      �� 5      $��0��6   $��2��6&   
���   �$��2q�6N   $��10q�6c   $ 30��6o   $ 30q�6�    5        5       $	 30Q�6+   $
 	LightGray��6;   5"      � 5#      -   5        $��0��5#      $��2��6%   $��50��67   $	��410��6C   ���	#00990055$	��Top=�6f   $��	20,0,20,0q�6~   .+�5$      �� -   5        $��35��5$      $��35��6)   ���	#0040E0D0���	#0040E0D0$
��Bold"�6y   $��Right=�6�   $	��Top=�6�   $��0,8,0,0q�6�   .��5%      �� $��/Image/Крестик.png��6     J� RenderTransformOrigin$ 0.5,0.5&�6<   z�5&      V� 5'   "   .~�5(   &   �� �� 5)   &   �� 5*   &    �� Angle$ 44.589Q�66   T� 5+   &   5,   #   5.      5/      50      �� 51      $��1��6   $��5��6*   .+�52      ��  J� IsHitTestVisible$ False��6    $	��180��69   $��25��6E      Label_CurrentPassword#���   6Q   $
��Left=�6�   $��Bottom=�6�   $��20(�6�    �� TextAlignment$
 Left=�6�   
���   �$��	55,15,0,0q�6�   G� 53      -   5         G�Name$ TextBox_CurrentPassword��53   "   $��15(�6C   $	��350��6Q   $��35��6]   $��
15,15,0,20q�6i   �� 54      $ False��6    $	��180��69   $��25��6E     Label_NewPassword#���  6Q   $
��Left=�6|   $��Bottom=�6�   $��20(�6�   $
 Left=�6�   
���   �$��55,0,0,0q�6�   G� 55      -   5        $ TextBox_NewPassword��55   "   $��15(�6?   $	��350��6M   $��35��6Y   $��
15,10,0,30q�6e   �� 56      -   5          	Button_OK#���  56      
���   �$	��1.5q�6X   $��20(�6o   $	��135��6   $��40��6�   $��30,0,0,0q�6�    � 	Resources 57       �� 
TargetType �� Property �� Value��%^   '��       �� 58      " ��6$   .�59   "   ��  �@��CornerRadius$ 8��6A   5:      5;      6B   5<      5=      5>      5?      5@      