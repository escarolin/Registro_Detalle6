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
using Registro_Detalle6.Entidades;
using Registro_Detalle6.DAL;
using Registro_Detalle6.BLL;
namespace Registro_Detalle6.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    { 
        private Productos productos=new Productos();
        public  rProductos()
        {
            InitializeComponent();
             this.DataContext = productos;

            
        }

                private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var productos = ProductosBLL.Buscar(Utiidades.ToInt(ProductoIdTextBox.Text));
            if (productos != null)
            {
                this.productos = productos;
                this.DataContext = this.productos;
            }
            else
            {
                this.productos = new Productos();
                this.DataContext = this.productos;
                MessageBox.Show("Este productos no fue encontrado.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
                ProductoIdTextBox.SelectAll();
                ProductoIdTextBox.Focus();
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

            //--------------------------------------------(Aqui van las exepciones)---------------------------------------
           // if (PersonasIdComboBox.Text == string.Empty)
            //{
                //MessageBox.Show("El campo Persona Id esta vacio.\n\nPorfavor seleccione una persona.", "Warning",
                   // MessageBoxButton.OK, MessageBoxImage.Warning);

                //PersonasIdComboBox.IsDropDownOpen = true;
               // return;
           // }

            if (DecripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo Concepto esta vacio.\n\nPorfavor escriba un concepto.", "Warning",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);

               DecripcionTextBox.SelectAll();
                DecripcionTextBox.Focus();
                return;
            }

            //------------------------------------------------------------------------------------------------------------

            var paso = ProductosBLL.Guardar(this.productos);

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
            if (ProductosBLL.Eliminar(Utiidades.ToInt(ProductoIdTextBox.Text)))
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
            this.productos = new Productos();
            this.DataContext = this.productos;

        }

        private bool Validar()
        {
            bool esValido = true;

            //if (ConceptoTextBox.Text.Length == 0)
            //{
            //    esValido = false;
            //    MessageBox.Show("Transaccion Fallida", "Fallo",
            //        MessageBoxButton.OK, MessageBoxImage.Warning);
            //}

            return esValido;
        }
    }
    }

