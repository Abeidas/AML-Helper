   M S B A M L   `   `   `  ����D  @AMLHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AMLHelper.ViewAMLHelper.View  5          AMLHelper.View.TabPanel   5      &localclr-namespace:AMLHelper.View  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      � -   5          �Name$
  grid��5	       � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      $��30 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��200 �6   �� 5      .+�5   
   �� -   5         ��Name$ 
PathBorder��5   w   
�������$��1q�6)   $��3��6=   $��0,0,0,20q�6Q   $y�Hidden=�6c   ._�5      � -   5         �Name$ PathContainer��5   ,   $��3��6   5      5      �� 5   
   $��Name:��6   $��1��5      �� 5   
   -   5        $ border��5      $��1��6!   $��1��61   
���   �$��1q�5      $
��Left=�5      $��Center=�5      ._�5      �� -   5         ��Name$ 	textBlock��5      
�������$��Stretch=�5"      $	��150��69   ��5       ��  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5"   9   5#      � 5$   
   -   5        $  border2��5$      $��2��6    $��1��60   $��Right=�5%      $��Center=�5&      .+�5'      �� -   5        	 ��Name$	 Backward_Button��5'      $��2��5(      $��30��5)      $��0,0,0,0q�5*      {�5,      �� $ forwardButton_enable���5-      �� 5.      $2��,/AMLHelper;component/Properties/Backward.png��6   
 � ToolTip$!
 Im Tabverlauf zurück gehen��6R   ��50      �� 51       �� 
TargetType" ��6   52      54      �� 55      -   5        $	 Forward_Button��55      $��2��56      $��30��57      $��	100,0,7,0q�58      {�5:      �� $ backwardButton_enable���5;      �� 5<      $1��+/AMLHelper;component/Properties/Forward.png��6   $$
 Im Tabverlauf nach vorne gehen��6Q   ��5>      �� 5?      " ��6   5@      5B      5C       � 5E   
   -	   5          �Name$ frameForPanel��5E      $��2��5F      $��3��5G      5H      5I      5K      