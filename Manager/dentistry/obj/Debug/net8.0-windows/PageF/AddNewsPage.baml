   M S B A M L   `   `   `  ����D  @dentistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:dentistry.Modeldentistry.Model  5      !    dentistry.PageF.AddNewsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      +localclr-namespace:dentistry.Model   5        N� Title$  AddNewsPage��5
       � 	Resources 5         ShowAnimation �� 
TargetName �� TargetProperty W� From	 W� To g� Duration  HideAnimation  ActiveButtonStyle �� 
TargetType  MaterialDesignRaisedButton �� BasedOn	 �� Property
 �� Value  InactiveButtonStyle   MaterialDesignOutlinedButton��%z  &	        &	 '    &	 N    7  &	 �    7  �� 5   
   .��5      W� $ CustomSnackbar��5      $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�5       1005       06   $ 0:0:0.3D�6#   W� 5      $ CustomSnackbar��5      $ Opacity�5       05       16   $ 0:0:0.3D�6!   5      �� 5   
   .��5      W� $ CustomSnackbar��5      $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�5       05       1006   $ 0:0:0.3D�6#   W� 5      $ CustomSnackbar��5      $ Opacity�5       15        06   $ 0:0:0.3D�6!   5!      �� 5#   
   " ��6*   8   .�5$      �� 	 � ��
 �	#FF1976D26+   �� 5%      	 � ��

 �����6+   5&      �� 5(   
   " ��6,   8   .�5)      �� 	 � ��
 �	#FF1976D26,   �� 5*      	 � ��
 �	#FF1976D26+   5+      5,      .��5.      � ���	#FFE5E5E5 � RowDefinitions 5/   
   �� 50      $
��Auto �6   �� 51      $��* �6   .+�55   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��16 8q�6K   .+�56      �� -   5         ��Name$ 
BtnAddNews��56      $)��#Добавление новости��57      
 � Tag$	 Add��5:      $
��24 8q�5;      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 2��5<      $��0 0 8 0q�5=       5?      ��%_   '��       �� 5@      " ��6   .�5A      �� 	 �@��CornerRadius$
 12��69   5B      5C      5D      �� 5F      -   5        $ BtnViewNews��5F      $'��!Просмотр новостей��5G      $
 View��5I      $
��24 8q�5J      $ 2��5K       5L      ��%_   '��       �� 5M      " ��6   .�5N      �� 	 �@��CornerRadius$
 12��69   5O      5P      5Q      5R      � 5U   
   -   5         �Name$ GridAddNews��5U      $��1��6$   $��16q�61   $y�Visible=�6=    5V      �� 5W      $
��Auto �6    �� 5X      $
��Auto �6    �� 5Y      $
��Auto �6    �� 5Z      $
��Auto �6    �� 5[      $
��Auto �6    �� 5\      $
��Auto �6    .+�5_      �� -   5         ��Name$ TitleT��5_      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Заголовок новости��5`       % !MaterialDesignFloatingHintTextBox#��[ 5a       �� TextWrapping$
 Wrap=�5b      $��0 0 0 16q�5c      �� 5e      -   5        $ DescT��5e      $��1��5f      $ Текст новости��5g      #��[ 5h      $
 Wrap=�5i       �� AcceptsReturn$
 True��5j      $	��150��5k      $��0 0 0 16q�5l      �� 5n      -   5        $ 	SelectImg��5n      $��2��5o      $-��'Добавить изображение��5p      #��[ 5q      $ 16��5r      $��0 0 0 16q�5s      ��5u      �� 5v      .R�5w      �� $ 
Horizontal=�6%   .+�5x      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ImagePlus=�66   $��0 0 8 0q�6G   �� 5y      $+��%Выбрать изображения��6(   5z      5{      5}      �� 5      -   5         ��Name$ ImagesListBox��5�      $��3��5      $��0 0 0 16q�5�      ��5�      �� 5�      .R�5�      #  MaterialDesignThemes.Wpf.Card  $��16q�6.   $��0 0 0 8q�6;   .��5�      �  � ColumnDefinitions 5�   "   �� 5�   &   $��48 �67   �� 5�   &   .+�5�   "   �� $��48��5�   (   $��48��5�   (   $��UniformToFill=�5�   (   ��5�   (   �� *
FilePath+5�   (   �� 5�   "   $��1��6-   $��16 0 0 0q�5�   -   .+�5�   &   �� $��Medium"�5�   0   ��5�   0   �� *Name+5�   0   �� 5�   &    J� Opacity$	 0.6Q�5�   0   ��5�   0   �� *	Extension+5�   0   5�   #   5�      5�      5�      5�      �� 5�      -   5        $ 	AddButton��5�      $��4��5�      $-��'Опубликовать новость��5�      $ 2��5�      $��Center=�5�      5�      5�      � 5�   
   -	   5        $ GridViewNews��5�      $��1��6%   $y�	Collapsed=�62    5�      �� 5�      $��* �6    �� 5�      $
��Auto �6    .+�5�      &   System.Windows.Controls.DataGrid  -
   5          Name$ NewsDataGrid��5�         AutoGenerateColumns$ False��5�         CanUserAddRows$ False��5�      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 16q�5�      $��16q�5�         RowStyle 5�      �� 5�      )  #System.Windows.Controls.DataGridRow"  6   .�5�      �� 	 � ��$
 70��63   5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Заголовок��6)     	  Width5
  /System.Windows.Controls.DataGridLengthConverter$  2*
 5�   )   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 5�   )   �� *	NewsTitle+5�   )     5�      $ Описание��6)   $  3*
 5�   )   ! 5�   )   �� *
NewsDesc+"   ElementStyle" 5�      �� 5�      " ��6$   .�5�   "   �� 	 � ��$

 Wrap=�6A   5�      5�        5�      $ Дата��6)   $	  120
 5�   )   ! 5�   )   �� *DatePublish+# �� StringFormat$# 
dd.MM.yyyy��5�   )   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Статус��6-   $	  150
 6=   $   CellTemplate$ 5�      �� 5�      .R�5�   "   �� &    dentistry.Model.NewsStatusValues
%   All#��Z% 5�   %     MaterialDesignComboBox#��[ 5�   %   $��4q�5�   %   & �� SelectedItem& 5�   %   �� *
NewsStatus+' �� UpdateSourceTrigger$' PropertyChanged=�5�   %   5�      5�      5�      �� 5�      -   5        $��1��5�      $+��%Сохранить изменения��5�      #��[ 5�      $��Right=�5�      $��16q�5�      $
��24 8q�5�      5�      5�      �� 5�   
   -   5        ( ��Name$( CustomSnackbar��5�      $��1��5�      ) �� CornerRadius$) 12��5�      $��16q�5�      * �� Padding$* 24 16q�5�      $��Center=�5�      $��Bottom=�5�      ���#333333+ J� RenderTransformOrigin$+ 0.5,1.0&�5�      $y�	Collapsed=�5�      z�5�      T� 5�      , T� Y$	, 100Q�6%   ._�5�      �  5�      �� 5�      $
��Auto �6'   �� 5�      .+�5�      �� -   5        - ��Name$- MessTextBlock��5�      $��1��5�      $�� ��5�      
�������$��14(�5�      $
��Wrap=�5�      $	��350��5�      5�      5�      5�      5�      