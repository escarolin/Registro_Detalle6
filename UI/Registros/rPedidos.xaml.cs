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
    /// Interaction logic for rPedidos.xaml
    /// </summary>
    public partial class rPedidos : Window
    {
        private Ordenes ordenes = new Ordenes();
        public rPedidos()
        {
            InitializeComponent();
            this.DataContext = ordenes;

            //——————————————————————————[ VALORES DEL ComboBox Suplidores]——————————————————————————
            SuplidorIdComboBox.ItemsSource = SuplidoresBLL.GetSuplidores();
            SuplidorIdComboBox.SelectedValuePath = "SuplidorId";
            SuplidorIdComboBox.DisplayMemberPath = "Nombres";

            //——————————————————————————[ VALORES DEL ComboBox Productos]——————————————————————————
            ProductoIdComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductoIdComboBox.SelectedValuePath = "ProductoId";
            ProductoIdComboBox.DisplayMemberPath = "Descripcion";

        }
        //—————————————————————————————————————————————————————[ CARGAR ]—————————————————————————————————————————————————————
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = ordenes;
        }
        //—————————————————————————————————————————————————————[ LIMPIAR ]—————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.ordenes = new Ordenes();
            this.DataContext = ordenes;
        }
        //—————————————————————————————————————————————————————[ Validar ]—————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (OrdenIdTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return Validado;
        }
        //—————————————————————————————————————————————————————[ BUSCAR ]—————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ordenes encontrado = OrdenesBLL.Buscar(ordenes.OrdenId);

            if (encontrado != null)
            {
                ordenes = encontrado;
                Cargar();
            }
            else
            {
                MessageBox.Show($"Este pedido no fue encontrado.\n\nAsegurese que existe o cree uno nuevo.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                OrdenIdTextbox.Clear();
                OrdenIdTextbox.Focus();
            }
        }
        //—————————————————————————————————————————————————————[ AGREGAR FILA ]—————————————————————————————————————————————————————
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var filaDetalle = new OrdenesDetalle
            {
                OrdenId = this.ordenes.OrdenId,
                ProductoId = Convert.ToInt32(ProductoIdComboBox.SelectedValue.ToString()),
                Producto = (Productos)ProductoIdComboBox.SelectedItem,
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)
            };

            this.ordenes.Detalle.Add(filaDetalle);
            Cargar();

            ProductoIdComboBox.SelectedIndex = -1;
            CantidadTextBox.Clear();
            CantidadTextBox.Focus();
        }
        //—————————————————————————————————————————————————————[ REMOVER FILA ]—————————————————————————————————————————————————————
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
                {
                    ordenes.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                   // ordenes.Total -= Convert.ToDouble(TotalMorasTextBox.Text.ToString());
                    Cargar();
                }
            }
            catch
            {
                MessageBox.Show("No has seleccionado ninguna Fila\n\nSeleccione la Fila a Remover.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //—————————————————————————————————————————————————————[ NUEVO ]—————————————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //—————————————————————————————————————————————————————[ GUARDAR ]—————————————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = OrdenesBLL.Guardar(this.ordenes);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //—————————————————————————————————————————————————————[ ELIMINAR ]—————————————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (OrdenesBLL.Eliminar(Utiidades.ToInt(OrdenIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    }
}
