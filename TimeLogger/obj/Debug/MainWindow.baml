   M S B A M L   `   `   `  ����E  ATimeLogger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TimeLogger
TimeLogger  5   	       TimeLogger.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TimeLogger     5   	   -   5          � Title$  TimeTracker��5   	   $	��144��6   $	��244��6*    � 
ResizeMode$ NoResize=�66    � Topmost . .��5	      � .+�5
   
   �� -   5         ��Name$ TxtBlkDayCountdown��5
      $
��Left=�60   $��	10,29,0,0q�6K   $
��Wrap=�6^   $��99:99:99��6r   $	��Top=�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ TxtBlkDayCountup��5      $
��Left=�6.   $��	10,53,0,0q�6I   $
��Wrap=�6\   $��99:99:99��6p   $	��Top=�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ TxtBlkWeekCountdown��5      $
��Left=�61   $��
158,28,0,0q�6L   $
��Wrap=�6`   $��99:99:99��6t   $	��Top=�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ TxtBlkWeekCountup��5      $
��Left=�6/   $��
158,53,0,0q�6J   $
��Wrap=�6^   $��99:99:99��6r   $	��Top=�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5         ��Name$ 	BtnNewDay��5      $��New Day��6$   $
��Left=�66   $��	10,77,0,0q�6Q   $��60��6d   $��20��6o   $	��Top=�6{   6�   �� 5   
   -   5        $ BtnPause��5      $	��P/R��6#   $
��Left=�61   $��	83,77,0,0q�6L   $��56��6_   $��20��6j   $	��Top=�6v   6�   �� 5   
   -   5        $ 
BtnNewWeek��5      $��New Week��6%   $
��Left=�68   $��
150,77,0,0q�6S   $	��Top=�6g   $��70��6   6�   �� 5   
   $
��Left=�6   $��	19,13,0,0q�6/   $
��Wrap=�6B   $��Today��6V   $	��Top=�6c   �� 5   
   $
��Left=�6   $��
170,13,0,0q�6/   $
��Wrap=�6C   $
��Week��6W   $	��Top=�6c   �� 5   
   -	   5        $ TxtBlkRemaining��5      $
��Left=�6-   $��	78,31,0,0q�6H   $
��Wrap=�6[   $��: Remaining :��6o   $	��Top=�6�   �� 5   
   -
   5        $ TxtBlkTotal��5      $
��Left=�6)   $��	78,55,0,0q�6D   $
��Wrap=�6W   $��:     Total      :��6l   $	��Top=�6�   �� 5   
   $
��Wrap=�6   $	��Top=�6(   $��	87,13,0,0q�6@   $
��Left=�6S   $��70��6n   �� 6z   -   5        .�5   �   �� $�Schedule��6�   6�   6�   5      5      