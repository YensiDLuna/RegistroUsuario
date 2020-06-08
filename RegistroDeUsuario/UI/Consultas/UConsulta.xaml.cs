using RegistroDeUsuario.BLL;
using RegistroDeUsuario.Entidades;
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

namespace RegistroDeUsuario.UI.Consultas
{
    /// <summary>
    /// Interaction logic for UConsulta.xaml
    /// </summary>
    public partial class UConsulta : Window
    {
        public UConsulta()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)

        {

            var listado = new List<Usuario>();

            if (CriterioTextBox.Text.Trim().Length > 0)

            {

                switch (FiltroComboBox.SelectedIndex)

                {

                    case 0: //EstudianteId

                        listado = UsuarioBLL.GetList(e => e.UsuarioId == Utilidades.ToInt(CriterioTextBox.Text));

                        break;



                    case 1: //Nombres                       

                        listado = UsuarioBLL.GetList(e => e.Nombre.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));

                        break;

                }

              





            }

            else

            {

                listado = UsuarioBLL.GetList(c => true);

            }



            DatosDataGrid.ItemsSource = null;

            DatosDataGrid.ItemsSource = listado;

        }
    }
}
