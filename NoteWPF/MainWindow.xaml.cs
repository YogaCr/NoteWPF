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
namespace NoteWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = 0;
            this.Top = SystemParameters.WorkArea.Height-this.Height;
            List<string> s = new List<string>();
            try {
                using (StreamReader sr = new StreamReader("Note.txt")) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        s.Add(line);
                    }
                    string kalimat="";
                    foreach (string S in s) {
                        kalimat += S + "\n";
                    }
                    textBox.AppendText(kalimat);
                }
            }
            catch {
                using (StreamWriter sw = new StreamWriter("Note.txt")) {
                    sw.Close();
                }
            }
        }

        private void Save(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Note.txt")) {
                sw.Write(new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd));
                sw.Close();
            }
        }

        private void Save(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Note.txt"))
            {
                sw.Write(new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text);
                sw.Close();
            }
        }
    }
}
