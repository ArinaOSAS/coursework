   M S B A M L   `   `   `  ����F  BArgocomTRPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ArgocomTRPO.WindowsAdminArgocomTRPO.WindowsAdmin  5   	   2    ,ArgocomTRPO.WindowsAdmin.BreakingWindowAdmin   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   8local&clr-namespace:ArgocomTRPO.WindowsAdmin     5   	     � Title$  BreakingWindowAdmin��5   	   $	��540��6%   $	��930��62    � WindowStyle$
 None=�6>    � WindowStartupLocation$ CenterScreen=�6Q    � 
ResizeMode$ NoResize=�6w   .��5
      � .+�5   
   �� 
�������._�5      �  � RowDefinitions 5      �� 5      $	��35* �6$   63   �� 5      $	��10* �6$   63   �� 5      $	��45* �6$   63   �� 5      $	��35* �6$   63   �� 5      $	��45* �6$   63   �� 5      $	��35* �6$   63   �� 5      $	��50* �6$   63    � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $��* �6'   63   �� 5      $��* �6'   63   .+�5      �� $��0��6   
���   �$��2q�6:   $��3��6N   $��7��6b   
�������$��10q�6�    �� CornerRadius$ 30��6�    �� Padding$ 30q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 30Q�6+   
   Color$
 	LightGray��6;   5       �� 5!      $��0��6   
���   �$��2q�6:   $��3��6N   $��	9,10,9,25q�6b   $ 30��6u   $ 30q�6�    5"        5#      $	 30Q�6+   $
 	LightGray��6;   5%      � 5&      -   5        $��0��5&      $��7��6$   $��11q�68   ���	#00990055.+�5'      �� -   5        $��35��5'      $��35��6)   ���	#0040E0D0���	#0040E0D0$
��Bold"�6y   $��Right=�6�   $	��Top=�6�   $��0,0,5,0q�6�   .��5(      �� $��/Image/Крестик.png��6     J� RenderTransformOrigin$ 0.5,0.5&�6<   z�5)      V� 5*   "   .~�5+   &   �� �� 5,   &   �� 5-   &    �� Angle$ 44.589Q�66   T� 5.   &   5/   #   51      52      �� 53      -   5        $��35��53      $��35��6)   ���	#0040E0D0���	#0040E0D0$
��Bold"�6}   $��0,0,40,0q�6�   $��Right=�6�   $	��Top=�6�   .��54      �� $��/Image/Черта.png��6    $��40��6:   55      56      �� 57      -   5        $��ComboBoxSelection��57      $��20(�64    �� DisplayMemberPath$ Typebreaking1��6B   $��0��6e   $��2��6v   $	��180��6�   $��35��6�   $��Center=�6�   $
��Left=�6�   $��25,0,0,0q�6�   6�   �� 58       J� IsHitTestVisible$ False��6   $��0��65   $��2��6F   $	��180��6T   $��35��6`      ComboBox_Selection#���   6l   $��Center=�6�   $��18(�6�    �� TextAlignment$
 Left=�6�   ���#696969$��	0,10,60,0q�6�   ��59      �� 5:       �� 
TargetType" ��6    .�5;      ��  �� Property � y� �� Value$ 	Collapsed=�6;    �� Triggers 5<      �� 5=   "    �� Binding 6.   �� *Text+ �� ElementName$ ComboBoxSelection�� �� Value  6f   .a�5>   &   ��  � y�$ Visible=�6C   5?   #   5A      5C      �� 5D      -   5        $��0��5D      $��2��6)   $��35��66   $��35��6A   $��	170,0,0,0q�6M   .��5E      �� $��/Image/Сброс.png��6   $��22��66   $��30��6A    � 	Resources 5F      ��%^   '��       �� 5G      " ��6    .�5H      ��  �@��CornerRadius$ 8��6=   5I      5J      5K      �� 5L      -   5         ��Name$ TextBox_Search��5L      $��0��62   $��2��6B   $��2��6P   $	��220��6e   $��35��6q   $��Center=�6}   
���   � �� TextAlignment$
 Left=�6�   $��20(�6�   $��	150,0,0,0q�6�   6�   �� 5M      $ False��6   $��0��65   $��2��6E   $��2��6S     Text_Search#���  6g   $��Center=�6�   $��30��6�   $	��170��6�   $��18(�6�   $
 Left=�6�   ���#696969$��	125,0,0,0q�6�   ��5N      �� 5O      " ��6    .�5P      ��  � y�$ 	Collapsed=�6;    5Q      �� 5R   "    6.   �� *Text+$ TextBox_Search��  6c   .a�5S   &   ��  � y�$ Visible=�6C   5T   #   5V      5X      &   System.Windows.Controls.DataGrid  5Z      -   5        $��DataGrid_Breaking��5Z         
IsReadOnly$
 True��64   $��20(�6G   $��0��6U   $��3��6e   $��3��6r   $��3��6�      AutoGenerateColumns$ False��6�   $��
20,0, 20,0q�6�      Columns 5[      0  *System.Windows.Controls.DataGridTextColumn  5\        Label_NumberTechnology,  &System.Windows.Controls.DataGridColumn   Header# �  6c      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *#!FktechnologyNavigation.Uniquecode+6�     5]        Label_TypeTechnology# �  6�   $ * 6�    6-   �� *CAFktechnologyNavigation.FktypetechnologyNavigation.Typetechnology1+6�     5^        Grid_DateBreaking# �  6j   $ * 6�    6-   �� *Datebreaking+  �� StringFormat$  
dd.MM.yyyy��6�     5_        Grid_DescriptionBreaking# �  6M   $ * 6�    6-   �� *Description+6�     5`        Grid_TypeBreaking# �  6h   $
 Auto 6�    6-   �� *(&FktypebreakingNavigation.Typebreaking1+6�   5c      �� 5d      -   5          Button_SendRepair#���  5d      $��25(�6G   $��2��6U   $��1��6b   $��2��6r   $	��290��6�   $��40��6�   $��Right=�6�   $��
130,0,25,0q�6�    5e      ��%^   '��       �� 5f      " ��6    .�5g      ��  �@��CornerRadius$ 8��6=   5h      5i      5j      �� 5k      -	   5          Button_Mending#���  5k      $��20(�6D   ���	#00990055���	#00990055
���   �$��1��6�   $��0��6�   $��2��6�   $
��Auto��6�   $��35��6�   $
��Left=�6�   $��	25,0,0,80q�6�   6	  �� 5l      -
   5         	 Button_Technology#��� 	 5l      $��20(�6G   $��1��6U   $��0��6b   $��2��6r   $��2��6�   
���   ����	#00990055���	#00990055$	��150��6�   $��35��6�   $��Center=�6�   $��
0,0,250,80q�6  6"  �� 5m      -   5         
 Button_Diagram#��� 
 5m      $��25(�6D   $��6��6R   $��2��6_   $	��150��6o   $��40��6{   $��Center=�6�   $��90,0,0,0q�6�    5n      ��%^   '��       �� 5o      " ��6    .�5p      ��  �@��CornerRadius$ 8��6=   5q      5r      5s      �� 5t      -   5          Button_Account#���  5t      $��35��6D   $
��Auto��6P   $��20(�6]   
���   ����	#00990055���	#00990055$��1��6�   $��2��6�   $��2��6�   $��Center=�6�   $��
100,0,0,80q�6�   6  5x      5y      5z      5{      