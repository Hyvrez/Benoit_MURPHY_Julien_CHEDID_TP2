   M S B A M L   `   `   `  ����C  ?Text_TP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Text_TP2Text_TP2  5   	       Text_TP2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Text_TP2     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��650��6,   $	��500��6;   $	��650��6K    � WindowStartupLocation$ CenterScreen=�6Z    � SizeToContent$ WidthAndHeight=�6   .��5	      � .+�5
   
   �� 
�����w�.+�5      �� $��
Encryption��6   $��Center=�6)   
���  ��$
��Bold"�6[   $��32(�6m   � 5      $	��220��6   $��	70,10,0,0q�6     � ColumnDefinitions 5      �� 5      $	��250 �6'   �� 5      $	��250 �6'   .+�5      �� -   5        $��InputTextBox��5      $��Input��6.   $
��Bold"�6;   $��0��6M    �� TextWrapping$
 Wrap=�6]    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5      -   5        $��OutputTextBox��5      $��Output��6/   $
��Bold"�6=   $��1��6O   $
 Wrap=�6_    . $
 Auto=�6�   5      � 5      $��35��6   $��0,15,0,0q�6    5      �� 5      $	��150 �6'   �� 5      $	��150 �6'   �� 5      $��* �6'   .+�5      �� -   5        $��EncryptionComboBox��5      $��25��65   $	��100��6A   $��Right=�6M   $��0��6i    �� SelectedIndex$ 0��6y   .@�5      �� $��Binary��6#   �� 5      $��Hexadecimal��6#   �� 5      $��Caesar��6#   �� 5      $��Vignere��6#   5       �� 5!      -   5        $��ConvertCheckBox��5!      $��Decrypt the code��62   $��1��6M   $��25��6]   $��Center=�6i   $
��5,10q�6�   �� 5"      -   5        $��(De)code text !!!��5"   .   $��2��6J   $��25��6Z   $	��200��6f   $��Center=�6r   5#      � 5$      -   5        $��Popup1��5$   '   $��Center=�6   $��Center=�65   $	��Top=�5%      $	��200��6,   $	��200��68   ��.  .��5&      �� .+�5'      �� -   5        $��McTextBlock��5'   8   
�����p�
���   �$
��Bold"�6^    �� TextAlignment$ Center=�6p   	 �� Padding$	 40,80,90,40q�6�   This is popup text5)      �� 5*      -   5        $��MyPopup��5*      
���  ��$��Close x��6A   
���   �$��20q�6y   5+      5,      �� 5-      -	   5        $	��Key��5-      $	��Key��6"   $��90��6-   $
 Wrap=�6:    . $
 Auto=�6c   �� 56      -
   5        $��	PCheckBox��56      $��	10,10,0,0q�6(   $��Popup Window��57      �� 58      $
��Left=�6   $	��129��60   $��	10,10,0,0q�6<   
 � Triggers
 59      :� 5:       :� RoutedEvent$ Button.Click��6#   .[�5;      �� .��5<      �� .��5=   "   W�  �� 
TargetName$ theTransform��5>   %    �� TargetProperty$ (RotateTransform.Angle)�5?   %    W� From$ 0X�5@   %   	 W� To$	 360X�6.    g� Duration$ 0:0:5D�67    g� AutoReverse . 6H   5A      5B      5C      .��5D   #   Start Animation5F      � 5G       � AllowsTransparency . $��Slide=�5J       � HorizontalOffset$	 150��5K       � VerticalOffset$	 100��5L      ��5G      ��  �� ElementName$ 	PCheckBox�� �� Path$ 	IsChecked� � PlacementTarget 5H      �� $ 	PCheckBox��.��5M      �� $	��100��6   $	��100��6%   
��� � �$	��150q�6E   z�5N      �� 5O      -   5        theTransform��5O   *   .+�5Q      �� $
��Wrap=�6    
�������lol.5S      5T      5U      5V      5W      5X      