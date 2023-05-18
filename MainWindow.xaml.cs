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
using System.IO;

namespace Kektura
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szakasz> lista = new List<Szakasz>();
        public MainWindow()
        {
            InitializeComponent();

            Allomanymegnyitas("kektura.txt");
            StreamWriter sw = new StreamWriter("utvonal.txt");

            foreach (Szakasz sor in lista)
            {
                sw.WriteLine($"{sor.Leiras};{sor.Tavolsag};{sor.Magassag};{Convert.ToString(sor.nehezseg)}");
            }

        }


        private void Allomanymegnyitas(string eleresiUt)
        {
            StreamReader sr = new StreamReader(eleresiUt);

            int seged = 1;
            string sor;

            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                Szakasz uj = new Szakasz(seged, sor.Split(';')[0], Convert.ToDouble(sor.Split(';')[1]), Convert.ToInt32(sor.Split(';')[2]), Convert.ToInt32(sor.Split(';')[3]));
                lista.Add(uj);
                seged++;
            }
            sr.Close();
            dtTartalom.ItemsSource = lista;
        }

        private void gomb_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Szakaszok száma: {lista.Count()}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbKeres.Content = lista.Where(x => x.Tavolsag <= Convert.ToInt32(txtKeres.Text)).Count();
            dtTartalom.ItemsSource = lista.Where(x => x.Tavolsag <= Convert.ToInt32(txtKeres.Text)).ToList();
        }

        private void btnatlag_Click(object sender, RoutedEventArgs e)
        {
            lbAtlag.Content = $"{Math.Round(lista.Where(x => x.Leiras.Contains("Pilis")).Average(x => x.Teljeseites))} perc";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Szakasz ut = lista.OrderBy(x => x.Tavolsag).First();
            MessageBox.Show($"Helyszín: {ut.Leiras}, hossz: {ut.Tavolsag}, idő: {ut.Teljeseites}");
        }
    }
}
