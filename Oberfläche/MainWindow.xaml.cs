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

namespace Oberfläche
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Parser.EingabePfad == "" || !File.Exists(Parser.EingabePfad))
                PfadLaden();
        }

        void PfadLaden()
        {
            Microsoft.Win32.OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();
            openDialog.DefaultExt = ".html";
            openDialog.Filter = "Traktor Webseite | *.html";

            bool? ergebnisEingabe = openDialog.ShowDialog();
            if(ergebnisEingabe == true)
            {
                string pfadEingabe = openDialog.FileName;
                System.Diagnostics.Debug.WriteLine("Eingabedatei: " + pfadEingabe);
                Parser.EingabePfad = pfadEingabe;
            }
        }

        private void TB_Pfad_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PfadLaden();
        }

        private void Btn_Suchen_Click(object sender, RoutedEventArgs e)
        {
            PfadLaden();
        }

        private void Btn_Speichern_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Eingabepfad != "" && File.Exists(Properties.Settings.Default.Eingabepfad))
            {
                Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog();
                saveDialog.DefaultExt = "xml";
                saveDialog.Filter = "XML-Datei | *xml";

                bool? ergebnisAusgabe = saveDialog.ShowDialog();
                if (ergebnisAusgabe == true)
                {
                    string pfadAusgabe = saveDialog.FileName;
                    System.Diagnostics.Debug.WriteLine("Ausgabedatei: " + pfadAusgabe);
                    Parser.AusgabePfad = pfadAusgabe;
                }
                Parser.MakeXmlFile();
            }
            else PfadLaden();
        }
    }
}
