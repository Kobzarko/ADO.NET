   M S B A M L   `   `   `  ����  Registration_ADO!    Registration_ADO.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��450��6)    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�6D    � 	Resources 5
         TextBlockMarker �� Property �� Value  TextBoxMarker��%U  &	        &	 �     �� 5   
   .�5      ��  � ��
 �����63   �� 5       � ��$ Verdana)�63   �� 5       � ��$
 Bold"�63   �� 5       � ��$ 30(�63   �� 5       � ��$ Center=�6<   �� 5       � ��$ 10q�61   5      �� 5   
   .�5      ��  � ��$ Center=�6:   5      5      ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/   	 �� 
StartPoint$	 0.5,0&�6S   .��5      � 
 � Color$
 	#FFDCD21E��6    � Offset$ 0.900Q�6-   � 5      $
 Azure��6   � 5      $
 	#BF324B80��6   � 5      $
 	#FF0596AA��6   $ 0.600Q�6-   5      .��5       �� $��5q�6    �� Padding$ 10q�6#   ��60   Z� ��5!   
   �� 5"      $ 0.5,1&�6"   $	 0.5,0&�63   .��5#      � $
 	#FF22B9D1��6   $ 0.011Q�61   � 5$      $
 	#FFC9C921��6   $ 1Q�61   � 5%      $
 	#FFC9C921��6   $ 1Q�61   5&      ._�5(   
   �  � RowDefinitions 5*      �� 5+      $��* �6    �� 5,      $��* �6    �� 5-      $��* �6    �� 5.      $��* �6    .+�50      �� $��0��6   .+�51      �� $ ��Вход в систему��6   
�������$��40(�6E   $
��Bold"�52      $
��Wrap=�6*    �� TextAlignment$ Center=�6>   $��0,50,0,0q�6U   53      �� 54       �� Orientation$ 
Horizontal=�6   $��1��62   .+�55      �� #��[  6   
Логин57      �� 58      -   5        $��UserName��58      $��30(�6*   $��90,40,20,40q�68   $��Center=�6M   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��59      
������� % !MaterialDesignFloatingHintTextBox#��[ 5:       � ToolTip$ Введите имя��5;      5<      �� 5=      $ 
Horizontal=�6   $��2��62   .+�5>      �� #��[  6   Пароль5@      G� 5A      -   5        $��Password��5A      $��Right=�6.   $��70,40,20,40q�6J   $��Center=�5B      $��30(�5C      $ Password��6(   
�������$! Введите пароль��5E       ) %MaterialDesignFloatingHintPasswordBox#��[ 5F      5G      �� 5H      $ 
Horizontal=�6   $��3��62   .+�5I      �� -   5        $��Registration��5I   $   $��5q�6   .��6T   Регистрация6a   �� 5J      -   5        $��Enter��5J   $   $��5q�6   .��6E   
Вход6K   �� 5K      -   5        $��
ForgotPass��5K   $   $��5q�6   .��6O   Забыл пароль6]   �� 5L      -   5         ��Name$	 Esc��5L      $��
Выход��6&    �� IsCancel .   MaterialDesignRaisedButton#��[ 5M   %   $��5q�6Y   $( "Выход из программы��5N      5O      5Q      5R      5S      