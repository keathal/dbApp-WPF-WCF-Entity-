   M S B A M L   `   `   `  ����C  ?EntityDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:EntityDBEntityDB  5   	       EntityDB.Report   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:EntityDB     5   	     � Title$  Report��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgMain��5   e   $��0��6   $��0��6    
���   � J� Opacity$	 0.8Q�6D   
���   �$��15,15,15,35q�6s      AutoGenerateColumns .     
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6T   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� 
 �� Path$
 	ID_reader�6a     5      $ Имя��6%   $ 1* 6R   	 62   �� $
 R_name�6_     5      $ Фамилия��6%   $ 1* 6Y   	 66   �� $
 	R_surname�6f     5      $ Взято книг��6%   $ 1* 6X   	 69   �� $
 Books�6e     5      $2 ,Процент от общего кол-ва��6%   $ 1* 6h   	 6G   �� $
 Percent�6u   5      5      5      