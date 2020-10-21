using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Registro_Detalle6.BLL;
using Registro_Detalle6.Entidades;

namespace Registro_Detalle6.UI.Registros
{
    /// <summary>
    /// Interaction logic for rSuplidores.xaml
    /// </summary>
    public partial class rSuplidores : Window
    {
        private Suplidores suplidores= new Suplidores ();
        public rSuplidores()
        {
            InitializeComponent();
        this.DataContext = suplidores;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var suplidores = SuplidoresBLL.Buscar(Utiidades.ToInt(SuplidorIdTextBox.Text));
            if (suplidores != null)
            {
                this.suplidores = suplidores;
                this.DataContext = this.suplidores;
            }

        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = SuplidoresBLL.Guardar(this.suplidores);

            if (paso)
            {


                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuplidoresBLL.Eliminar(Utiidades.ToInt(SuplidorIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Limpiar()
        {
            this.suplidores = new Suplidores();
            this.DataContext = this.suplidores;

        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

                return esValido;
            }
            return esValido;
        }
    }
}
    

