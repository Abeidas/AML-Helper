   M S B A M L   `   `   `  ����D  @AMLHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AMLHelper.ViewAMLHelper.View  5   	   ;"clr-namespace:AMLHelper.ControllerAMLHelper.Controller  5   	   !    AMLHelper.View.PluginWindow   5   	   %viewclr-namespace:AMLHelper.View  5   	   1
controller"clr-namespace:AMLHelper.Controller  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	AMLHelper��5   	   $	��699��6   $
��1000��6(    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$	 New��5      6'     5	   
   -   5        $
 Save��5	      6(     5
   
   -   5        $ SaveAs��5
      6*     5   
   -   5        $
 Open��5      6(     5   
   -   5        $ Close��5      6)    J� InputBindings 5      �� 5   
   
 �� Key$ T��6    �� 	Modifiers$ Controlf�6    �� Command$	 New��61   �� 5   
   $ O��6   $ Controlf�6   $
 Open��61   �� 5   
   $ S��6   $ Controlf�6   $
 Save��61   �� 5   
   $ S��6   $ Control+Shiftf�6   $ SaveAs��67   �� 5   
   $ Q��6   $ Controlf�6   $ Close��61   .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      $	��33* �6   .+�5   
      AMLHelper.View.MenuPanel  -   5        	  Name$	 	MenuPanel��5      $��2��6,   5      '   !AMLHelper.Controller.CaexTreeView  5    
   -   5        
  Name$

 Tree��5    "   $��1��60   $��0��6=   (   "AMLHelper.Controller.TabController  5!   
   -	   5          Name$ TabController��5#      $��1��5!   #   $��1��5"      5#      5$      5%      