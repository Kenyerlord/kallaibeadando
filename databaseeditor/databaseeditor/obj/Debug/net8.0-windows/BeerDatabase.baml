   M S B A M L   `   `   `  ����I  Edatabaseeditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:databaseeditordatabaseeditor  5   	   !    databaseeditor.BeerDatabase   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:databaseeditor     5   	     � Title$  BeerDatabase��5   	   $	��450��6   $	��800��6+   .��5	      � 
�������.+�5
   
   �� $��Beer database��6   $
��Left=�6(   $��
309,10,0,0q�6C   $	��Top=�6W   $��22(�6o   �� 5   
   -   5         ��Name$ return��5      ���#eb433d$��Return��66   $
��Left=�6G   $��
722,15,0,0q�6b   $	��Top=�6v   $��56��6�   6�   �� 5   
   -   5        $ 	AddButton��5      
����������#182ed6$	��Add��6N   $
��Left=�6\   $��702,123,0,0q�6w   $	��Top=�6�   $��59��6�   6�   �� 5   
   -   5        $ 
EditButton��5      
����������#182ed6$
��Edit��6O   $
��Left=�6^   $��702,169,0,0q�6y   $	��Top=�6�   $��59��6�   6�   �� 5   
   -   5        $ DeleteButton��5      ���#eb433d$��Delete��6<   $
��Left=�6M   $��702,217,0,0q�6h   $	��Top=�6}   $��59��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ beerdata��5      $��	0,261,0,0q�6%   68   �� 5   
   -   5         ��Name$ addname��5      $
��Left=�6#   $��
10,125,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��220��6�   �� 5   
   -   5        $ addtype��5      $
��Left=�6#   $��235,124,0,0q�6>   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $��37��6�   �� 5   
   -   5        $ 
addcountry��5      $
��Left=�6&   $��277,125,0,0q�6A   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��106��6�   �� 5   
   -	   5        $ addalcohollv��5      $
��Left=�6(   $��388,124,0,0q�6C   $
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $��83��6�   �� 5   
   -
   5        $ 	addvolume��5      $
��Left=�6%   $��476,125,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $��84��6�   �� 5   
   -   5        $ addbottletype��5      $
��Left=�6)   $��565,125,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��73��6�   �� 5   
   -   5        $ addprice��5      $
��Left=�6$   $��643,125,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $��54��6�   �� 5   
   -   5        $ editname��5      $
��Left=�6$   $��
10,170,0,0q�6?   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��220��6�   �� 5   
   -   5        $ edittype��5      $
��Left=�6$   $��235,169,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $��37��6�   �� 5   
   -   5        $ editcountry��5      $
��Left=�6'   $��280,170,0,0q�6B   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��103��6�   �� 5   
   -   5        $ editalcohollv��5      $
��Left=�6)   $��392,169,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��79��6�   �� 5   
   -   5        $ 
editvolume��5      $
��Left=�6&   $��480,170,0,0q�6A   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $��80��6�   �� 5   
   -   5        $ editbottletype��5      $
��Left=�6*   $��567,171,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $��71��6�   �� 5   
   -   5        $ 	editprice��5      $
��Left=�6%   $��644,169,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $��53��6�   �� 5   
   -   5        $ deleteid��5      $
��Left=�6$   $��622,219,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $��72��6�   �� 5    
   $��Name:��6   $
��Left=�6    $��	10,95,0,0q�6;   $	��Top=�6N   �� 5!   
   $��Type:��6   $
��Left=�6    $��
235,95,0,0q�6;   $	��Top=�6O   �� 5"   
   $��Country of origin:��6   $
��Left=�6-   $��
280,94,0,0q�6H   $	��Top=�6\   �� 5#   
   $��Alcohol Level:��6   $
��Left=�6)   $��
392,94,0,0q�6D   $	��Top=�6X   �� 5$   
   $��Bottle Volume:��6   $
��Left=�6)   $��
477,95,0,0q�6D   $	��Top=�6X   �� 5%   
   $��Bottle Type:��6   $
��Left=�6'   $��
567,95,0,0q�6B   $	��Top=�6V   �� 5&   
   $��Price:��6   $
��Left=�6!   $��
643,94,0,0q�6<   $	��Top=�6P   �� 5'   
   $��Name:��6   $
��Left=�6    $��
10,149,0,0q�6;   $	��Top=�6O   �� 5(   
   $��Type:��6   $
��Left=�6    $��235,149,0,0q�6;   $	��Top=�6P   �� 5)   
   $��Country of origin:��6   $
��Left=�6-   $��280,148,0,0q�6H   $	��Top=�6]   �� 5*   
   $��Alcohol Level:��6   $
��Left=�6)   $��392,148,0,0q�6D   $	��Top=�6Y   �� 5+   
   $��Bottle Volume:��6   $
��Left=�6)   $��477,144,0,0q�6D   $	��Top=�6Y   �� 5,   
   $��Bottle Type:��6   $
��Left=�6'   $��567,144,0,0q�6B   $	��Top=�6W   �� 5-   
   $��Price:��6   $
��Left=�6!   $��639,143,0,0q�6<   $	��Top=�6Q   �� 5.   
   $��
Delete ID:��6   $
��Left=�6%   $��620,192,0,0q�6@   $	��Top=�6U   51      52      