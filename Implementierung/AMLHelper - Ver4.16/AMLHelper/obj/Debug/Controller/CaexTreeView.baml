   M S B A M L   `   `   `  ����D  @AMLHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AMLHelper.ViewAMLHelper.View  5      I)clr-namespace:AMLHelper.ElementExtractionAMLHelper.ElementExtraction  5      1clr-namespace:AMLHelper.ModelAMLHelper.Model  5      '    !AMLHelper.Controller.CaexTreeView   5      %viewclr-namespace:AMLHelper.View  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:AMLHelper.ElementExtraction     5      0nonlocclr-namespace:AMLHelper.Model     5        � DataContext  5      #  AMLHelper.Model.TreeViewModel  5   
    � 	Resources 5         CloseNoHoverImg  CloseImg  TreeViewItemContextmenu m� Icon��%  &	       &	 L    &	 �     �� 5   
   $8��2/AMLHelper;component/Properties/Close_No_Hover.png��69   �� 5   
   $/��)/AMLHelper;component/Properties/Close.png��62   �� 5   
   .@�5      m� -   5        $��In neuem Tab öffnen��5       5      �� 5      $9��3/AMLHelper;component/Properties/Open_In_New_Tab.png��6   $��16��6Y   $��16��6d   5      m� 5      -   5        $��In aktuellem Tab öffnen��5       5      �� 5      $=��7/AMLHelper;component/Properties/Open_In_Current_Tab.png��6   $��16��6]   $��16��6h   5      m� 5      -   5        $��Dieses Element löschen��5       5      �� 5      $/��)/AMLHelper;component/Properties/Close.png��6   $��16��6O   $��16��6Z   5       5!      5"       � ContextMenu 5#      �� 5$   
   .@�5%      m� -   5         m�Name$ NewInstanceHierachy��5%      $$��Neue Instanzhierarchie anlegen��64    m� InputGestureText$ Strg+T��6v   {�.   5&      �� 5'      $-��'/AMLHelper;component/Properties/Add.png��6   $��16��6M   $��16��6X   5)      m� 5*      -   5        $ 
RestoreTab��5*      $(��"Geschlossenen Tab wiederherstellen��6+   {�6n   ��  �� Path$ hasDeletedTabs� 5+      �� 5,      $1��+/AMLHelper;component/Properties/Restore.png��6   $��16��6Q   $��16��6\   5.      m� 5/      -   5        $ DeleteAllTabs��5/      $��Alle Elemente löschen��6.   {�.   50      �� 51      $3��-/AMLHelper;component/Properties/Close_ALL.png��6   $��16��6S   $��16��6^   53      54      .��56      �� ._�57   
   �  � RowDefinitions 58      �� 59      $
��Auto �6    �� 5:      $��* �6    .+�5<      �� $��0��6   $��1q�6"   #��� ��66   ._�5=      �  5>       �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  '��       7   7  �� 5?      " ��6    .�5@      �� 	 � ��8
   68   �� 5A      	 � ��
 5B   "   �� 5C   &   " ��66   .R�5D   *   �� #��z��61   ._�5E   .   �� $��Center=�6?   $��Center=�6\   5F   +   5G   '   5I       5J      P� 5K   "    �@J�IsMouseOver . . �5L   &   �� 	 � ��8
  6@   �� 5M   &   	 � ��

 �����6D   5N   #   5P      5Q       � ColumnDefinitions 5R      �� 5S      $��* �6+   �� 5T      $
��Auto �6+   .+�5V      �� -   5        $��TextBox��5V   .   $��0��6   $��Suche...��5W      {�. $��2��5Z   O   ��68   Z� 6O   �� 5\      -   5         ��Name$ CleanSearchboxButton��5\      $��1��6;   $��16��5]   !   $��16��5^   !   $��0,0,2,0q�5_   !   
������ 
������  K� ZIndex$ 10��5b   ;   $y�Hidden=�6M    � ToolTip$( "Löscht die Eingabe in der Suchbox��6a   5d      5e         AMLHelper.View.Resultview  5h      -	   5          Name$ 
Resultview��5h      $��1��62   $y�Hidden=�6?   $	 100��6S   �� 5j      $��1��6   $��1q�6"   #��� ��66   $��2��6�   ._�5k      �� $
��Auto=�6   $
��Auto=�6B   .��5l      R� -
   5        $
��Tree��5l   E   ��6   �� $ TreeList���6Q   Z� ��5m      �� 5n      " Q�6$    �� 	Resources 5o   "     
HoverBrush �� Opacity �� Color��%3   &	       �� 5p   &   $	 .05Q�6I   # � ��6W   5q   #    5r   "   P� 5s   &    �@J�IsMouseOver . . �5t   *   �� 	 � ��#
 �  6G   5u   '   .�5w   "   -   5        �� 5y   "   	 � ��$

 Left=�6H   �� 5z   "   	 �@�ContextMenu#
 [ 6@   5{      ��5}      �� 5~       �� DataType-   'AMLHelper.ElementExtraction.CAEXElement"  6b    �� ItemsSource 67   �� $ ChildElements�.R�5   "   �� ��6,   �� $
 Name�5�      5�      5�      5�      5�      5�      5�      