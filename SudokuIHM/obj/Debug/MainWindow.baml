   M S B A M L   `   `   `  ����D  @SudokuIHM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SudokuIHM	SudokuIHM  5   	       SudokuIHM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:SudokuIHM     5   	   $	��350��5   +   $	��525��68     � Title  6	   �� *NomApplicattion+ � DataContext 5         SudokuIHM.SudokuManager  5   
   .��5	      � -   5         �Name$ 
gridGlobal��5	       � RowDefinitions 5
   
   �� 5      $��21 �6   �� 5      $��* �6   .+�5   
   o� -   5         o�Name$ menuTop��5      $��0��6    .@�5      m� -   5         m�Name$ menuFichier��5      $��Fichier��6,   .@�5      m� -   5        $ 
menuOuvrir��5      $��Ouvrir��6/   6?   m� 5      -   5        $ menuQuitter��5      $��Quitter��60   5      m� 5      -   5        $ menuRésoudre��5      $��Résoudre le sudoku��6.   6J   5      � 5   
   -   5        $ gridSecondaire��5      $��1��6'   $��0��64    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      � -   5        $ 
gridGauche��5      $��0��6'   
������� 5      �� 5      $��90 �6$   �� 5       $��* �6$   .+�5#      �� -	   5         ��Name$ ListBoxSudokus��5#      $��1��62   $��Stretch=�5$      ��5#   A   �� *ListeGrilles+ �� SelectedItem 5$   r   �� *grilleSelect+��5%      �� 5&      .R�5'      �  5(   "   �� 5)   &   $��* �67   �� 5*   &   $��* �67   �� 5+   &   $��* �67   .+�5-   "   �� $��0��6,   ��6<   �� *Nom+�� 5.   "   $��1��6,   ��6<   �� *Date+�� 5/   "   $��2��6,   ��6<   �� *
Symboles+50      51      53      �� 55      $��0��6   .+�56      �� -
   5        	 ��Name$	 	cbVerbeux��56      .��6J   Mode Verbeux6Y   �� 57      -   5        
 ��Name$
 
btnValider��57      {�.  .��6\   Valider le sudoku6o   �� 58      -   5        $
 btnRésoudre��58      {�.  .��6^   Résoudre le sudoku6r   �� 59      �� 5:      ��6%   �� *grilleSelect.Taille+ �� 5;      $��X��6%    �� 5<      ��6%   �� *grilleSelect.Taille+5=      5>      5?      � 5A      -   5        $ 
gridDroite��5A      $��1��6'    5B      �� 5C      $��90 �6$   �� 5D      $��* �6$   .+�5F      � -   5        $��gridSudokuSelect��5F      $��1��6/   
��� � �6<   �� 5G      -   5        $��
txtVerbeux��5G      $��0��6,   
���   ����#FFF �� TextWrapping$
 Wrap=�6_   $ �� HorizontalScrollBarVisibility$
 Auto=�6s   " �� VerticalScrollBarVisibility$
 Auto=�6�    �� AcceptsReturn .  �� 
IsReadOnly . 6�   5I      5K      5L      5N      