   M S B A M L   `   `   `  ����D  @dentistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:dentistry.PageFdentistry.PageF  5      "    dentistry.PageF.AddOrModPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:dentistry.PageF     5        N� Title$  AddOrModPage��5	      .��5      � ���	#FFE5E5E5 � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.3* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataInfo��5      $��2��6%   $��10,10,10,10q�69   $��Stretch=�6N   $	��Top=�5         
IsReadOnly$
 True��6#      AutoGenerateColumns$ False��5         SelectionMode$ Single=�6'      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID услуги��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 5      1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5      �� *
ServicesId+5        5      $# Название услуги��6%   $		 200 5      
 5      �� *ServicesTitle+5        5      $ Описание��6%   $		 300 5       
 5      �� *ServicesDesc+5         5!      $ Цена��6%   $	 80 5#      
 5"      �� *ServicesPrice+5#        5$      $ Тип услуги��6%   $		 150 5&      
 5%      �� * ServicesType.ServicesTypeTitle+5&      5(      �� 5)   
   -   5         ��Name$
 AddB��5)      $��1��6   $��Center=�6,   $	��100��6G   $��Center=�6S   $��Добавить��6p    � 	Resources 5*       �� 
TargetType �� Property �� Value��%_   '��       �� 5+      " ��6   .�5,      ��  �@��CornerRadius$ 12��65   5-      5.      z�5/      V� 50      .~�51      ��  �� ScaleX$ 1Q�6%   �� 52      �� 53      T� 54      55      57      �� 58   
   -   5        $
 ModB��58      $��1��6   $��Center=�6,   $	��160��6G   $��Center=�6S   $ ��Редактировать��6p   $��1��6�    59      ��%_   '��       �� 5:      " ��6   .�5;      ��  �@��CornerRadius$ 12��65   5<      5=      z�5>      V� 5?      .~�5@      �� $ 1Q�6%   �� 5A      �� 5B      T� 5C      5D      5F      5G      5H      