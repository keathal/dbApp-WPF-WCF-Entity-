   M S B A M L   `   `   `  ����C  ?EntityDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:EntityDBEntityDB  5   	       EntityDB.Add_reader   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:EntityDB     5   	     � Title$B  <Добавить/редактировать читателя��5   	   $	��300��61   $	��300��6>   .��5	      �  � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   .+�5   
   �� -   5        $��t_readername_edit��5   (   
�������$��30��6A   $��15, 0, 15, 0q�6M    �� TextWrapping$
 Wrap=�6c   $��Имя��6w   �� 5   
   -   5        $��t_readersname_edit��5   5   
�������$��1��6(   $��30��6O   $��15, 0, 15, 0q�6[   $
 Wrap=�6q   $��Фамилия��6�   �� 5   
   -   5        $��b_add��5   ?   
�������
�����F�$��Добавить��6L   $��Right=�6_   $��0, 0, 8, 10q�6{   $��4��6�   $��Bottom=�6�   $��75��6�   6�   �� 5   
   -   5        $��b_edit��5   ?   
�������
�����F�$��Изменить��6M   $
��Left=�6`   $��10, 0, 0, 10q�6{   $��4��6�   $��Bottom=�6�   $��75��6�   6�   �� 5   
   -   5         ��Name$ t_login��5   5   
�������$��2��6(   $��30��6F   $��15,10,15,14q�6R   $
 Wrap=�6g   $��
Логин��6{   G� 5   
   -   5        $��
t_password��5      
�������$��15,14,15,10q�6>   $��30��6S   $��3��6_   �� 5   
   $��Пароль��6   
�������$
��Left=�68   $��	15,40,0,0q�6S   $��2��6f   $	��Top=�6s   $��2��6�   5      5      