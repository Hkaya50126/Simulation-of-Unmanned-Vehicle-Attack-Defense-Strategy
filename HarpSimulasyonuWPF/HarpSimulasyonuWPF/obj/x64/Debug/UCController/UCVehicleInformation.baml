   M S B A M L   `   `   `  ����M  IHarpSimulasyonuWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:HarpSimulasyonuWPF.UCControllerHarpSimulasyonuWPF.UCController  5      :    4HarpSimulasyonuWPF.UCController.UCVehicleInformation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:HarpSimulasyonuWPF.UCController     5      .��5	      � .+�5
   
   ]� .+�5      �� $	��Top=�6   $	��790��6.   $	��150��6:   $��5 0 5 0q�6G   .+�5      � .+�5      � $	��140��6   $	��150��6'   $
��Left=�64   $	��Top=�6O   .+�5      ��   �� CornerRadius$  5��6!   ._�5      � 
�������$	��130��65   $��90��6A   $��5q�6M   $
��Left=�6X   $	��Top=�6s   .+�5   "   �� -   5         ��Name$ InformationImage��5   (   $	��120��6B   $��90��6N   $��Center=�6Z   $��Center=�6w   $
��Fill=�6�   6�   5      5      � 5      $	��130��6   $��40��6+   $��Center=�67   $��Bottom=�6T   .+�5      �� -   5         ��Name$ InformationVehicleName��5   $   
�������$��12(�6W   $��Center=�6e   $��Center=�6�   .��6�   Taşıt İsmi (Taşıt Tipi)6�   5      5      � 5      $	��580��6   $	��150��6'   $��Right=�64   $	��Top=�6P   $��5q�6h   .+�5      � $	��260��6   $
��Left=�6+   .+�5      � $��40��6#   $	��Top=�6/   $��5q�6G   .+�5   "   �� 
�������$��16(�6;   $
��Left=�6I   $��Center=�6d   .��6   Enlem6�   5      � 5      $��40��6#   $��5q�6/   .+�5   "   �� 
�������$��16(�6;   $
��Left=�6I   $��Center=�6d   .��6   Boylam6�   5       � 5!      $��40��6#   $��Bottom=�6/   $��5 0 0 15q�6J   .+�5"   "   �� 
�������$��15(�6;   $
��Left=�6I   $��Center=�6d   .��6   #!Hedef Koordinat( ENLEM - BOYLAM )6�   5#      5$      � 5%      $	��310��6   $��Right=�6+   .+�5&      � $	��300��6#   $
��Left=�6/   .+�5'   "   � $��40��6'   $	��Top=�63   $��5q�6K   .+�5(   &   �� -   5         ��Name$  InformationLatitudeTextbox��5(   .   $	��200��6R   $��30��6^   {�.  6   5)   #   � 5*   "   $��40��6'   $��5q�63   .+�5+   &   �� -   5        $! InformationLongitudeTextBox��5+   .   $	��200��6S   $��30��6_   {�.  6   5,   #   � 5-   "   $��40��6'   $��Bottom=�63   $��0 0 0 13q�6N   .+�5.   &   � $��40��6+   $��5q�67   .+�5/   *   �� -   5        $&  InformationTargetLatitudeTextbox��5/   2   $
��Left=�6\   $	��135��6w   $��30��6�   $��5q�6�   6�   �� 50   *   -   5        $' !InformationTargetLongitudeTextbox��50   2   $��Right=�6]   $	��135��6y   $��30��6�   $��5 5 0 5q�6�   6�   51   '   52   #   53      54      55      56      57      �� 5:      $	��Top=�6   $	��790��6.   $��90��6:   $��5 0 5 0q�6F   .+�5;      � .+�5<      � $	��390��6   $��40��6'   $	��Top=�63   $
��Left=�6K   $��5q�6f   .+�5=      � $	��380��6   $��30��6+   $
��Left=�67   $	��Top=�6R   $��5q�6j   .+�5>      �� 
�������$��16(�67   $��Center=�6E   $��Center=�6b   .��6~   " Taşıtın Sahip Olduğu Yükler6�   5?      5@      � 5A      $	��390��6   $��40��6'   $��Right=�63   .+�5B      � $	��380��6   $��30��6+   $
��Left=�67   $	��Top=�6R   $��5q�6j   .+�5D      �� -   5        $ InformationAmmoList��5D   $   
�������$��12(�6T   $��Center=�6b   $��Center=�6   $��5 0 0 0q�6�   .��6�   MAM-L(2), MAM-C(2)6�   5F      5G      5H      � 5I      .+�5J      � $	��390��6   $��40��6'   $��Bottom=�63   $
��Left=�6N   $��5 0 5 5q�6i   .+�5K      � $	��380��6   $��30��6+   $
��Left=�67   $	��Top=�6R   $��5 0 5 0q�6j   .+�5L      �� 
�������$��16(�67   $��Center=�6E   $��Center=�6b   .��6}   Hızı6�   5M      5N      � 5O      $	��390��6   $��40��6'   $��Right=�63   $	��Top=�6O   .+�5P      � $	��280��6   $��30��6+   $��Center=�67   $	��Top=�6T   $��25 5 5 5q�6l   .+�5Q      � .+�5R   "   �� -   5        $ InformationVehicleSpeed��5R   *   $
��Left=�6K   $	��135��6f   $��30��6r   $��5q�6~   {�.  6�   5S      � 5T      .+�5U   "   �� -	   5         ��Name$ InformationIncreaseSpeed��5U   )   $��60��6K   $
��Left=�6V   $��	150 5 5 5q�6q   $��12(�6�   $
��Bold"�6�   
���   �
������.��6�   +6�   �� 5V   "   -
   5        $ InformationReduceSpeed��5V   )   $��60��6I   $
��Left=�6T   $��	220 5 5 5q�6o   $��12(�6�   $
��Bold"�6�   
���   �
���  ��.��6�   -6�   5W      5X      5Y      5Z      5[      �� 5^      $	��Top=�6   $	��790��6.   $��50��6:   .+�5_      � $	��780��6   $��40��6#   $��5q�6/   .+�5c      � $	��200��6   $
��Left=�6'   $��5 0 0 0q�6B   .+�5d      �� -   5        $ UpdateVehicleInformation��5d   !   $	��200��6C   $��16(�6O   $
��Bold"�6]   
������� � Cursor$
 Hand��6�   ��6�   Z� .��6�   Araç Bilgilerini Güncelle6�   5e      � 5f      $	��150��6   $��Right=�6'   .+�5g      �� -   5        $ DeleteVehicle��5g   !   $	��150��68   $��16(�6D   $
��Bold"�6R   
�������$
 Hand��6�   ��6w   Z� .��6�   
Aracı Sil6�   5h      5i      5j      5k      5l      5m      