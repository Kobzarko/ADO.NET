   M S B A M L   `   `   `  ����K  GRegistration_ADO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Registration_ADORegistration_ADO  5   	   "    Registration_ADO.WindowHello   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Registration_ADO     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          � Title$  WindowHello��5	   	   $	��250��6   $	��400��6*    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�5   	   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ 	#FFDCD21E��6    � Offset$ 0.900Q�6-   � 5      $ Azure��6   � 5      $ 	#BF324B80��6   � 5      $ 	#FF0596AA��6   $ 0.600Q�6-   5      	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   "
 ��6   .�5      ��  � ��$ 20(�6)   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�64   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      .+�5!   
   �� $��0��6    �� Orientation$ Vertical=�5"      $��Center=�5#      .+�5$      �� -   5        $��	HelloText��5$   4   $ ��Привет, {RealName}! ��6   64   �� 5%      -   5        $��HelloLastDate��5%   A   $4��.Рад Вас видеть с {LastVisitDate}.��6   6A   5&      �� 5'   
   $��1��6   $ 
Horizontal=�6"   $��Center=�5(      $��Center=�5)      .+�5*      �� -   5        $��Thanks��5*      $��Спасибо��6#   65   5+      5-      5.      