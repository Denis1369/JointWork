   M S B A M L   `   `   `  ����D  @dentistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:dentistry.PageFdentistry.PageF  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      !    dentistry.PageF.EditingPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      +localclr-namespace:dentistry.PageF   5      2sys&clr-namespace:System;assembly=mscorlib   5        N� Title$  EditingPage��5       � 	Resources 5      �� 5   
      Key
StatusList   �� Type" ��6%   .s�5      ��Ожидание��6#   ��5      Подтвержден��6&   ��5      Отменено��6#   5      �� 5   
   MaterialDesignDropDown   �� 
TargetType" ��6/   .�5      �� .  (MaterialDesignThemes.Wpf.TextFieldAssist �� Property �@ DecorationVisibility �� Value$ Hidden=�6T   �� 5      )  #MaterialDesignThemes.Wpf.HintAssist �@ 
Foreground �#7575756E   �� 5       � ��$ 4q�6'   5      �� 5   
   " ��6   .�5      �� +  %MaterialDesignThemes.Wpf.ButtonAssist �@ CornerRadius$ 8��6I   �� 5       � ��$
 16 8q�6(   �� 5       � ��$ 4q�6'   5      ,   &dentistry.PageF.StatusToColorConverter  5    
   StatusToColorConverter  6'   .��5$      �   MaterialDesignPaper#���  6    � RowDefinitions 5%   
   �� 5&      $
��Auto �6   �� 5'      $��* �6   .+�5*   
   #  MaterialDesignThemes.Wpf.Card  $��0��6   $��16q�6+   $��16q�67   .��5+      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5,      �� -   5        $��Все��5,        MaterialDesignPrimaryColor#���  5-        MaterialDesignRaisedButton#��[ 5.      
 � Tag$  ��50      �� 51      -   5        $��Ожидание��51        WarningBrush#��[ 52      #��[ 53      $ Ожидание��55      �� 56      -   5        $��Подтвержден��56        SuccessBrush#��[ 57      #��[ 58      $ Подтвержден��5:      �� 5;      -   5        $��Отменено��5;        
ErrorBrush#��[ 5<      #��[ 5=      $ Отменено��5?      5@      5A        5C   
   $��1��6   $��16q�6+   $��16q�67   .��5D      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 EntriesDataGrid��5D      
   AutoGenerateColumns$
 False��5E         CanUserAddRows$ False��5G      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 16q�5H      ��5F      �� *EntriesView+   RowStyle 5I      �� 5J      )  #System.Windows.Controls.DataGridRow"  6   .�5K      ��  � ��$ 70��63   �� 5L      .	  (MaterialDesignThemes.Wpf.ColorZoneAssist �@	 
Background 5M      �� *EntryStatus+  StatusToColorConverter �� 	Converter# [ 5N         Columns 5P      0
  *System.Windows.Controls.DataGridTextColumn
  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 5S   )     RightAlignedTextBlock1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5T   )      Binding 5R   )   �� *	EntryId+5T   )   
  5U      $ Дата и время��6)   $ * 5W   )    5V   )   �� *
DateTime+ �� StringFormat$ dd.MM.yyyy HH:mm��5W   )   
  5X      $ Имя��6)   $ * 5Z   )    5Y   )   �� *
UserName+5Z   )   
  5[      $ Email��6)   $ * 5]   )    5\   )   �� *	UserEmail+5]   )   4  .System.Windows.Controls.DataGridTemplateColumn  5_      $ Статус��6-   $	 250 6=      CellTemplate 5`      �� 5a      .R�5b   "   �� -   5         	 
StatusList#��[	 5c   %    
 MaterialDesignDropDown#��[
 5e   %   $��Stretch=�5f   %    �� SelectedItem 5d   %   �� *EntryStatus+ �� UpdateSourceTrigger$ PropertyChanged=�5g   %   5i      5k      5m      5n      5o      5p      