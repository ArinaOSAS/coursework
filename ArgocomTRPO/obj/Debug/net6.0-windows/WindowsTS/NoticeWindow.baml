   M S B A M L   `   `   `  ����F  BArgocomTRPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ArgocomTRPO.WindowsTSArgocomTRPO.WindowsTS  5   	   (    "ArgocomTRPO.WindowsTS.NoticeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   5local#clr-namespace:ArgocomTRPO.WindowsTS     5   	     � Title$  NoticeWindow��5   	   $	��220��6   $	��500��6+    � WindowStyle$
 None=�68    � WindowStartupLocation$ CenterScreen=�6K    � 
ResizeMode$ NoResize=�6q   .��5	      � .+�5
   
   �� 
�������._�5      �  � RowDefinitions 5      �� 5      $��45 �6$   62   �� 5      $��* �6$   61   �� 5      $��* �6$   61   �� 5      $��* �6$   61    � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $��* �6'   63   .+�5      �� $��0��6   $��2��6&   $��4��6:   
���   �$��2q�6_   
�������$��10q�6�    �� CornerRadius$ 30��6�    �� Padding$ 30q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 30Q�6+   
   Color$
 	LightGray��6;   5      �� 5      $��0��6   $��2��6&   $��
10,10,10,0q�6:   
���   �$��2q�6b   $ 30��6v   $ 30q�6�    5        5      $	 30Q�6+   $
 	LightGray��6;   5      � 5       -   5        $��0��5       $��2��6%   $��2��66   $��50��6J   $	��450��6V   ���	#00990055$	��Top=�6y   .+�5!      �� -   5        $��35��5!      $��35��6)   ���	#0040E0D0���	#0040E0D0$
��Bold"�6y   $��Right=�6�   $	��Top=�6�   $��0,8,0,0q�6�   .��5"      �� $��/Image/Крестик.png��6     J� RenderTransformOrigin$ 0.5,0.5&�6<   z�5#      V� 5$   "   .~�5%   &   �� �� 5&   &   �� 5'   &    �� Angle$ 44.589Q�66   T� 5(   &   5)   #   5+      5,      5-      �� 5.      $��1��6   $��2��6%      Label_TypeTechnology#���   66   $��20(�6g   $
��Auto��6u   $��Center=�6�   $	��Top=�6�   $��0,12,0,0q�6�   6�   �� 5/      $��1��6   $��1��6%   $��2��65     Label_NumberDepartment#���  6F   $��20(�6y   $
��Auto��6�   $��Center=�6�   $	��Top=�6�   $��0,12,0,0q�6�   6�   �� 51      -   5        $��TextBlock_Type��51      $��2��62   $��2��6?   $��20(�6Q   $
��Auto��6_   $��Center=�6m   $	��Top=�6�   $��0,10,0,0q�6�   �� 52      -   5        $��TextBlock_Departament��52      $��2��6:   $��1��6G   $��20(�6X   $
��Auto��6f   $��Center=�6s   $	��Top=�6�   $��0,10,0,0q�6�   �� 53      -   5        $��TextBlock_Date��53      $��2��63   $��2��6@   $��1��6Q   $��15(�6b   $
��Auto��6p   $��Right=�6}   $	��Top=�6�   $��	0,62,30,0q�6�   55      56      57      58      