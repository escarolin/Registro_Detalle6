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
using Registro_Detalle6.UI.Registros;
using Registro_Detalle6.UI.Consultas;
namespace Registro_Detalle6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void rPedidosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPedidos rPedidos = new rPedidos();
            rPedidos.Show();
        }
         private void cPedidosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPedidos cPedidos = new cPedidos();
            cPedidos.Show();
        }

    }

}
