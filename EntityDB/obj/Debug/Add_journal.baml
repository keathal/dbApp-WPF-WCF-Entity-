   M S B A M L   `   `   `  ����C  ?EntityDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:EntityDBEntityDB  5   	       EntityDB.Add_journal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:EntityDB     5   	     � Title$>  8Добавить/редактировать запись��5   	   $	��300��6/   $	��300��6<   .��5	      �  � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   .+�5   
   �� -   5        $��c_reader��5      $��15q�6#   $��0��6/   $��25��6<   ��5      �� 5      .R�5      � .+�5      �� ��6$   ��  �� Path$ 	R_surname�6F   5      5      5      �� 5   
   -   5        $��c_book��5      $��15q�6!   $��1��6-   $��25��6:   ��5      �� 5      .R�5      � .+�5      �� ��6$   �� $ 	Book_name�6F   5      5       5"      �� 5$   
   -   5        $��b_add��5$   ?   
�������
�����F�$��Добавить��6L   $��Right=�6_   $��0, 0, 8, 10q�6{   $��3��6�   $��Bottom=�6�   $��75��6�   6�   �� 5%   
   -   5        $��b_edit��5%   ?   
�������
�����F�$��Изменить��6M   $
��Left=�6`   $��10, 0, 0, 10q�6{   $��3��6�   $��Bottom=�6�   $��75��6�   6�   5&      5'      