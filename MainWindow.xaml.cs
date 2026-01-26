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

namespace cigan_dialog
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Chyba_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Došlo k chybě v programu.",
                "Chyba",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        private void Otazka_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult vysledek = MessageBox.Show(
                "Chcete pokračovat?",
                "Otázka",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (vysledek == MessageBoxResult.Yes)
            {
                MessageBox.Show("Pokračujeme.");
            }
        }

        private void Upozorneni_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Tato akce je nevratná!",
                "Upozornění",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }

        private void Informace_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Operace byla úspěšná.",
                "Informace",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
