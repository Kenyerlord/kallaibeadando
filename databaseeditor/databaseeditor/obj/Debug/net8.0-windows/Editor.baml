   M S B A M L   `   `   `  ����I  Edatabaseeditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:databaseeditordatabaseeditor  5   	       databaseeditor.Editor   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:databaseeditor     5   	     � Title$  Editor��5   	   $	��450��6   $	��800��6%   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� ���#ababab$��0��6*   $��10q�6:   .+�5      �� -   5        $��Beer Database��5      ���#a8fa82$��5q�6`   �� 5      -   5        $
��Type��5      ���#a8fa82$��5q�6L   �� 5      -   5        $��Volume��5      ���#a8fa82$��5q�6P   �� 5      -   5        $��Country��5      ���#a8fa82$��5q�6R   �� 5      -   5        $��Bottle��5      ���#a8fa82$��5q�6P   �� 5      -   5        ���#eb433d$��Return��5   *   $��5q�6P   5      �� 5   
   -   5         ��Name$ Databox��5      $��1��6#   $��
335,10,0,0q�64   6H   �� 5   
   -   5         ��Name$ addbox��5      $��1��6#   $
��Left=�63   $��	40,43,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -	   5        $ editbox��5      $��1��6#   $
��Left=�63   $��	40,79,0,0q�6N   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -
   5         ��Name$ 	AddButton��5      
����������#182ed6$��1��6M   $	��Add��6]   $
��Left=�6k   $��
172,43,0,0q�6�   $	��Top=�6�   $��56��6�   6�   �� 5   
   -   5        $ 
EditButton��5      
����������#182ed6$��1��6N   $
��Edit��6^   $
��Left=�6m   $��
173,77,0,0q�6�   $	��Top=�6�   $��55��6�   6�   �� 5   
   -   5        $ DeleteButton��5      ���#eb433d$��1��6<   $��Delete��6L   $
��Left=�6]   $��172,110,0,0q�6x   $	��Top=�6�   $��55��6�   6�   5      5      