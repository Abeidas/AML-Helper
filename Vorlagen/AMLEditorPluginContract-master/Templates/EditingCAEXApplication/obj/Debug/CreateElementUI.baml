   M S B A M L   `   `   `  ����  CreateElementPlugin%    AMLEditorPlugin.CreateElementUI   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$Q  KAutomationML Editor Plugin with it's own UI-Thread and Editing Capabilities��5   	   $	��800��5   	   $	��500��5   	   
������� � Icon$ AMLPlugin.png��5
   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��2��5       �� Orientation$ 
Horizontal=�5      .+�5      �� -   5         ��Name$
 File��5      $��2q�5      $��Stretch=�5      $��Center=�5       ��5!      �� *AmlFilePath+�� 5#      ��6   �� *SaveCommand+.��65   Save6;   5$      � 5&   
   $��1��6   $��0��6    5'      �� 5(      $
��Auto �6    �� 5)      $��* �6    .+�5+      �� $��2q�6   $��Instance Hierarchies��6#   �� 5,      $��1��6   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5-      ��5.      �� *InstanceHierarchies+5/      � 51   
   $��1��6   $��1��6    52      �� 53      $
��Auto �6    �� 54      $��* �6    .+�56      �� $��2q�6   $��Internal Elements��6#   �� 58      $��1��6   $
 TrueY�59      ��5:      �� *InternalElements+5;      �� 5=   
   $��2��6   $��1��5>      $ 
Horizontal=�5?      .+�5@      �� $��2q�6   ��6    �� *CreateCommand+.��6B   Create Internal Elements6\   �� 5A      $	��100��6   $��2q�5B      $��Stretch=�5C      $��Center=�5D      ��5E      �� *ElementCount+�� 5F      $��2q�6   .��6   Element Count:6/   �� 5G      $��2q�6   $��Center=�5H      ��5I      �� *TotalElementCount+5J      5K      5L      