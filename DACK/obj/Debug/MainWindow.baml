   M S B A M L   `   `   `  ����C  ?Fluent, Version=6.1.0.326, Culture=neutral, PublicKeyToken=null/$clr-namespace:Fluent;assembly=FluentFluent  5   	    DACK   DACK.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7Fluent$clr-namespace:Fluent;assembly=Fluent     5   	   -   5          � Title$(  "Phần mềm quản lí bán hàng��5   	   $	��350��6+   $	��525��68    � WindowState$ 	Maximized=�6D   .��5      ]� ��. .+�5   
      Fluent.Ribbon  -   5        $��ribbon��5   -   $	��Top=�6      Menu 5         Fluent.Backstage  5	         Fluent.RibbonControl   Header$
 File��6#      Content. 5
          Fluent.BackstageTabControl  .@�5         Fluent.BackstageTabItem     Header$ Options��62   5        5      $ About��62   5      5      5         Tabs. 5         Fluent.RibbonTabItem     Header$ Category��6#      Groups. 5         Fluent.RibbonGroupBox  	   Header$	 
Operations��6(   .@�5         Fluent.Button  -   5        $��btnAddCategory��5   $   
   Header$	
 Add��6W      	LargeIcon$ Images/Add.png��6d   $��80��6   6�   5      5        5      $ Product��6#   . 5!        $	 
Operations��6(   .@�5"        -   5        $��btnAddProduct��5"   $   $	
 Add��6U   $ Images/Add.png��6b   $��80��6~   6�   5#        5$      $	 
Operations��6(   .@�5%        -   5        $��btnDeleteProduct��5%   $   $
 Delete��6<   $ Images/Delete.png��6L   $��80��6k   6x   5&        5'      $	 
Operations��6(   .@�5(        -   5        $��btnUpdateProduct��5(   $   $
 Update��6<   $ Images/edit.png��6L   $��80��6i   6v   5)      5+        5.      $ Customer��6#   . 50        $	 
Operations��6(   .@�51        -   5        $��btnAddCustomer��51   $   $	
 Add��6W   $ Images/Add.png��6d   $��80��6�   6�   52      54        57      $
 Bill��6#   . 59        $	 
Operations��6(   .@�5:        -   5        $��btnCreateBill��5:   $   $	
 Add��69   $ Images/Add.png��6F   $��80��6b   6o   5;        5<      $	 
Operations��6(   .@�5=        -	   5        $��btnDeleteBill��5=   $   $
 Delete��69   $ Images/Delete.png��6I   $��80��6h   6u   5>        5?      $	 
Operations��6(   .@�5@        -
   5        $��btnUpdateStateBill��5@   $   $
 Update��6>   $ Images/edit.png��6N   $��80��6k   6x   5A      5C        5F      $ 
Promotions��6#   . 5H        $	 
Operations��6(   .@�5I        -   5        $��btnAddPromotions��5I   $   $	
 Add��6<   $ Images/Add.png��6I   $��80��6e   6r   5J        5K      $	 
Operations��6(   .@�5L        -   5        $��btnDeletePromotions��5L   $   $
 Delete��6?   $ Images/Delete.png��6O   $��80��6n   6{   5M        5N      $	 
Operations��6(   .@�5O        -   5        $��btnUpdatePromotions��5O   $   $
 Update��6?   $ Images/edit.png��6O   $��80��6l   6y   5P        5Q      $	 
Operations��6(   .@�5R        -   5        $��btnCreateCoupons��5R   $   $
 Create coupons��6<   $ Images/coupon.png��6T   $��80��6s   6�   5S      5U        5X      $ 	Statistic��6#   . 5Z        $	 
Operations��6(   .@�5[        -   5        $��btnByProduct��5[   $   $
 
By product��68   $ Images/product.png��6L   $	��100��6k   6y   5\        5]      $	 
Operations��6(   .@�5^        -   5        $��btnByRevenue��5^   $   $
 
By revenue��68   $ Images/income.png��6L   $	��100��6j   6x   5_      5a      5c      �� 5e   
   -   5        $
��tabs��5e      $��0q�6e    �� SelectedIndex 6!   ��  �� ElementName$ ribbon�� �� Path$ SelectedTabIndex� � 	Resources 5f       �� 
TargetType �� Property �� Value �� 
TargetType��%w   '��       �� 5g      " ��6   .�5h      ��  � �� 5i      �� 5j      " ��6.   6E   5l      5m      5n      5o      5p      5q      