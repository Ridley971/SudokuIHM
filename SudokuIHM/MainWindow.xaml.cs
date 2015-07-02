using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudokuIHM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.sudoManager;
        }

        private void menuOuvrir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Selectionner le plan";
            opFile.Filter = "Sudoku Texte ou XML|*.sud;*.sudx";

            Nullable<bool> result=opFile.ShowDialog();
             
                if (result==true )                
                   App.sudoManager.ChargerFichier(opFile.FileName);                      
        }

        private void menuSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Helllo Sauvegarder");
        }

        private void menuRésoudre_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Helllo Résoudre");
        }


        private FrameworkElement CreerCaseDeGrid(Grille gril, int i, int j)
        {
            FrameworkElement b;
            char c = gril.Tab[i, j].Valeur;
            if (c == '\0')
            {
                b = new Rectangle();
                ((Rectangle)b).Fill = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                b = new Button();
                ((Button)b).Content = c;
            }
            Grid.SetRow(b, i);
            Grid.SetColumn(b, j);
            return b;
        }

        private void ListBoxSudokus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridSudokuSelect.Children.Clear();
            gridSudokuSelect.ColumnDefinitions.Clear();
            gridSudokuSelect.RowDefinitions.Clear();
            Grille g = App.sudoManager.grilleSelect;

            for (int i = 0; i < g.Taille; i++)
            {
                gridSudokuSelect.ColumnDefinitions.Add(new ColumnDefinition());
                gridSudokuSelect.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < g.Taille; i++)
            {
                for (int j = 0; j < g.Taille; j++)
                {
                    FrameworkElement b = CreerCaseDeGrid(g, i, j);
                    gridSudokuSelect.Children.Add(b);
                }
            }

        }
   

    }
}
