   M S B A M L   `   `   `  ����M  IHarpSimulasyonuWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:HarpSimulasyonuWPF.UCControllerHarpSimulasyonuWPF.UCController  5   	   2    ,HarpSimulasyonuWPF.UCController.UCAddVehicle   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:HarpSimulasyonuWPF.UCController     5   	   -   5          � Title$  UCAddVehicle��5   	   $	��960��6   $	��600��6+    � WindowStyle$
 None=�67   
������� � WindowStartupLocation$ CenterScreen=�6]   .��5	      � .+�5   
   � $��50��6   $	��Top=�6   $��5q�64   .+�5      �� -   5        
�������$��60��5   (   $
��Bold"�63   $��Right=�6E   $��5q�6a   $��20(�6l    � Cursor$
 Hand��6�   ��6z   Z� .��6�   X6�   5      � 5   
   $	��880��6   $	��Top=�6   $��5 65 5 5q�64   .+�5      � $	��200��6   $	��Top=�6     � RowDefinitions 5      �� 5      6&   �� 5      6&    � ColumnDefinitions 5      �� 5      6)   �� 5      6)   �� 5      6)   �� 5      6)   .+�5      � $��0��6   $��0��6$   .+�5      �� -   5         ��Name$ TopGrid1Border1��5      $��5q�66   
��� � �$y�Hidden=�6^   6t   �� 5      -   5         ��Name$ TopGrid1��5      $��5q�6/   $
��Fill=�6:   $
 Hand��6I   6�   5       � 5!      $��0��6   $��1��6$   .+�5"      �� -   5        $ TopGrid2Border2��5"      $��5q�66   
��� � �$y�Hidden=�6^   6t   �� 5#      -   5        $ TopGrid2��5#      $��5q�6/   $
��Fill=�6:   $
 Hand��6I   6�   5$      � 5%      $��0��6   $��2��6$   .+�5&      �� -   5        $ TopGrid3Border3��5&      $��5q�66   
��� � �$y�Hidden=�6^   6t   �� 5'      -   5        $ TopGrid3��5'      $��5q�6/   $
��Fill=�6:   $
 Hand��6I   6�   5(      � 5)      $��0��6   $��3��6$   .+�5*      �� -	   5        $ TopGrid4Border4��5*      $��5q�66   
��� � �$y�Hidden=�6^   6t   �� 5+      -
   5        $ TopGrid4��5+      $��5q�6/   $
��Fill=�6:   $
 Hand��6I   6�   5,      � 5-      $��1��6   $��0��6$   .+�5.      �� -   5        $ TopGrid5Border5��5.      $��5q�66   
��� � �$y�Hidden=�6^   6t   �� 5/      -   5        $ TopGrid5��5/      $��5q�6/   $
��Fill=�6:   $
 Hand��6I   6�   50      � 51      $��1��6   $��1��6$   .+�52      �� -   5        $ TopGrid6Border6��52      $��5q�66   
��� � �$y�Hidden=�6^   6t   �� 53      -   5        $ TopGrid6��53      $��5q�6/   $
��Fill=�6:   $
 Hand��6I   6�   54      � 55      $��1��6   $��2��6$   .+�56      �� -   5        $ TopGrid7Border7��56      $��5q�66   
��� � �$y�Hidden=�6^   6t   �� 57      -   5        $ TopGrid7��57      $��5q�6/   $
��Fill=�6:   $
 Hand��6I   6�   58      � 59      $��1��6   $��3��6$   .+�5:      �� -   5        $ TopGrid8Border8��5:      $��5q�66   
��� � �$y�Hidden=�6^   6t   �� 5;      -   5        $ TopGrid8��5;      $��5q�6/   $
��Fill=�6:   $
 Hand��6I   6Y   5<      5>      � 5@      $	��280��6   $��Center=�6    $��	0 0 0 120q�6;   .+�5A      � $	��580��6   $	��280��6#   $��Right=�60   $	��Top=�6L   $��5q�6d   .+�5B      � $	��260��6   $	��270��6'   $	��Top=�64   $
��Left=�6L   .+�5C      � $��40��6   $	��Top=�6+   $��5q�6C   .+�5D      �� 
�������$��16(�67   $
��Left=�6E   $��Center=�6`   $��14 0 0 0q�6{   .��6�   Taşıt İsmi6�   5E      � 5F      $��40��6   $	��Top=�6+   $��5 55 5 5q�6C   .+�5G      �� 
�������$��16(�67   $
��Left=�6E   $��Center=�6`   $��14 0 0 0q�6{   .��6�   Taşıt Hızı6�   5H      � 5I      $��40��6   $��Bottom=�6+   $��	5 0 0 125q�6F   .+�5J      �� 
�������$��15(�67   $
��Left=�6E   $��Center=�6`   $��14 0 0 0q�6{   .��6�   " Hedef Koordinat (ENLEM - BOYLAM)6�   5K      � 5L      $	��250��6   $��40��6+   $��Bottom=�67   $
��Left=�6R   $��5 5 5 75q�6m   .+�5M      � $	��240��6#   $��30��6/   $
��Left=�6;   $��Center=�6V   $��5q�6q   .+�5N   "   �� 
�������$��16(�6;   $
��Left=�6I   $��Center=�6d   $��14 0 0 0q�6   .��6�   " Taşıtın Sahip Olduğu Yükler6�   5O      5P      � 5Q      $��40��6   $��Bottom=�6+   $��5 0 5 30q�6F   .+�5R      �� 
�������$��15(�67   $
��Left=�6E   $��Center=�6`   $��14 0 0 0q�6{   .��6�   #!Anlık Koordinat (ENLEM - BOYLAM)6�   5S      5T      � 5U      $	��310��6   $��Right=�6'   $��5q�6C   .+�5V      � $	��300��6   $
��Left=�6+   .+�5W      � $��40��6#   $	��Top=�6/   $��5 5 0 5q�6G   .+�5X   "   �� -   5         ��Name$ VehicleNameTextbox��5X   *   $��0 4 0 0q�6F   $	��200��6Y   $��30��6e   $��TC_SNL_X��6q   ���	#FFA5A2A2{�.  6�   5Y      � 5Z      $��40��6#   $	��Top=�6/   $��5 55 0 5q�6G   .+�5[   "   �� -   5        $ VehicleSpeedTextbox��5[   *   $��0 4 0 0q�6G   $	��200��6Y   $��30��6e   ���	#FFA5A2A26  5\      � 5]      $	��290��6#   $��40��6/   $��Bottom=�6;   $��	5 0 0 130q�6V   .+�5^   "   � $��40��6'   $��5 5 0 5q�63   .+�5_   &   �� -   5        $ TargetLatitudeTextbox��5_   .   $��0 4 0 0q�6M   $
��Left=�6_   $	��100��6z   $��30��6�   $��5q�6�   6�   �� 5`   &   -   5        $ TargetLongitudeTextbox��5`   .   $��0 4 0 0q�6N   $��Right=�6`   $	��100��6|   $��30��6�   $��5 5 70 5q�6�   6�   �� 5a   &   -   5        	 ��Name$!	 TakeTargetCoordinatesButton��5a   -   $��60��6R   $��10(�6]   $��Right=�6k   $��5q�6�   .��6�   Anlık Konum6�   5b   #   5c      � 5d      $	��290��6#   $��35��6/   $��Bottom=�6;   $��Right=�6V   $��5 5 0 85q�6r   .+�5e   "   �� -   5        
 ��Name$
 AmmoCountCombobox��5e   +   $��5 4 0 0q�6F   $
��Left=�6X   $��50��6s   $��30��6~   $��5q�6�    �� Text$
 Adet��6�   ���	#FFA5A2A26�   �� 5f   "   -   5        $
 AmmoCombobox��5f   +   $��5 4 0 0q�6A   $��Center=�6S   $	��150��6p   $��30��6|   $��5 5 5 5q�6�   ���	#FFA5A2A2 �� SelectedIndex$ 0��6�   6�   �� 5g   "   -   5        $	 AmmoAddButton��5g   )   $��60��6@   $��Right=�6K   $��5q�6g   .��6�   Ekle6�   5h      � 5i      $��40��6#   $��Bottom=�6/   $��5 5 0 35q�6J   .+�5j   "   �� -   5        $ InstantLatitudeTextbox��5j   *   $��0 4 0 0q�6J   $
��Left=�6\   $	��130��6w   $��30��6�   $��5q�6�   {�.  6�   �� 5k   "   -   5        $ InstantLongitudeTextbox��5k   *   $��0 4 0 0q�6K   $��Right=�6]   $	��130��6y   $��30��6�   $��5q�6�   {�.  6�   5l      5m      5n      5o      5q      � 5s      $	��150��6   $��Bottom=�6    $��	5 5 5 210q�6;   .+�5t      � $	��200��6   $
��Left=�6#   $��5q�6>   .+�5u      �� 
�������$��16(�6/   $��Center=�6=   $��Center=�6Z   $��14 0 0 0q�6u   .��6�   Mühimmat Listesi6�   5v      � 5w      $	��300��6   $	��120��6#   $	��Top=�60   $��Right=�6H   $��5q�6d   .+�5x      �� -   5         ��Name$ AmmoListListView��5x      $��5q�69   ��5y      �� 5z       �� 
TargetType" ��6$   .�5{   "   ��  �� Property � �� �� Value$ Center=�6O   6`   5|       �� View 5~      �� 5      .P�5�   "   �� $
��Adet��61    �� Width$ 70��6?    �� DisplayMemberBinding 6J   �� *	AmmoCount+6w   �� 5�   "   $��Mühimmat Adı��61   $	 210��6G    6S   �� *
AmmoName+6   5�      5�      5�      � 5�      $	��145��6   $��35��6#   $��Right=�6/   $��Bottom=�6K   $��5 5 85 0q�6f   .+�5�      �� -   5        $	 AmmoClearListButton��5�      $	��135��6:   $��Right=�6F   $��5 5 5 0q�6b   $
 Hand��6s   .��6�   Listeyi Temizle6�   5�      5�      � 5�      $	��100��6   $��Bottom=�6    $��5 5 5 75q�6;    5�      �� 5�      6&   �� 5�      6&    5�      �� 5�      6)   �� 5�      6)   �� 5�      6)   �� 5�      6)   .+�5�      � $��0��6   $��0��6$   .+�5�      �� -   5        $ BottomGrid1Border1��5�      $��5q�69   
��� � �$y�Hidden=�6a   6w   �� 5�      -    5        $ BottomGrid1��5�      $��50��61   $
��Fill=�6=   $
 Hand��6L   6�   5�      � 5�      $��0��6   $��1��6$   .+�5�      �� -!   5        $ BottomGrid2Border2��5�      $��5q�69   
��� � �$y�Hidden=�6a   6w   �� 5�      -"   5        $ BottomGrid2��5�      $��50��61   $
��Fill=�6=   $
 Hand��6L   6�   5�      � 5�      $��0��6   $��2��6$   .+�5�      �� -#   5        $ BottomGrid3Border3��5�      $��5q�69   
��� � �$y�Hidden=�6a   6w   �� 5�      -$   5        $ BottomGrid3��5�      $��50��61   $
��Fill=�6=   $
 Hand��6L   6�   5�      � 5�      $��0��6   $��3��6$   .+�5�      �� -%   5        $ BottomGrid4Border4��5�      $��5q�69   
��� � �$y�Hidden=�6a   6w   �� 5�      -&   5        $ BottomGrid4��5�      $��50��61   $
��Fill=�6=   $
 Hand��6L   6�   5�      � 5�      $��1��6   $��0��6$   .+�5�      �� -'   5        $ BottomGrid5Border5��5�      $��5q�69   
��� � �$y�Hidden=�6a   6w   �� 5�      -(   5        $ BottomGrid5��5�      $��50��61   $
��Fill=�6=   $
 Hand��6L   6�   5�      � 5�      $��1��6   $��1��6$   .+�5�      �� -)   5        $ BottomGrid6Border6��5�      $��5q�69   
��� � �$y�Hidden=�6a   6w   �� 5�      -*   5        $ BottomGrid6��5�      $��50��61   $
��Fill=�6=   $
 Hand��6L   6�   5�      � 5�      $��1��6   $��2��6$   .+�5�      �� -+   5        $ BottomGrid7Border7��5�      $��5q�69   
��� � �$y�Hidden=�6a   6w   �� 5�      -,   5        $ BottomGrid7��5�      $��50��61   $
��Fill=�6=   $
 Hand��6L   6�   5�      � 5�      $��1��6   $��3��6$   .+�5�      �� --   5        $ BottomGrid8Border8��5�      $��5q�69   
��� � �$y�Hidden=�6a   6w   �� 5�      -.   5        $ BottomGrid8��5�      $��50��61   $
��Fill=�6=   $
 Hand��6L   6\   5�      5�      � 5�      $��50��6   $��Bottom=�6    $��5q�6;   .+�5�      �� -/   5        $	 FrAddVehicleButton��5�      
�������$	��250��6H   $
��Bold"�6T   $��Center=�6f   $��5q�6�   $��20(�6�   $
 Hand��6�   ��6�   Z� .��6�   EKLE6�   5�      5�      5�      5�      