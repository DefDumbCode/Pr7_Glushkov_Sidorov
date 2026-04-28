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

namespace Scitala.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static List<string> actions = new List<string>() { "Шифровать", "Дешифровать" };
        public MainPage()
        {
            InitializeComponent();
        }

        private void ActionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ScitalaCipher.Validate(CipherTB.Text, DiamTB.Text))
            {
                string orig = CipherTB.Text;
                int diam = int.Parse(DiamTB.Text);
                if (CipherType.SelectedItem.ToString() == "Шифровать")
                {
                    ResultTB.Text = ScitalaCipher.Encrypt(orig, diam);
                }
                else
                {
                    ResultTB.Text = ScitalaCipher.Decrypt(orig, diam);
                }
            }
        }

        private void CipherType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActionBtn.Content = CipherType.SelectedItem.ToString();
        }
    }
}
