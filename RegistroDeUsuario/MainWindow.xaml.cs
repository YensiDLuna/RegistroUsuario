using RegistroDeUsuario.UI.Consultas;
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

namespace RegistroDeUsuario
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void UsuarioMenuItem_Click(object sender, RoutedEventArgs e)

        {

            Rusuario m= new Rusuario();

            m.Show();

        }

        private void ConsultaUMenuItem_Click(object sender, RoutedEventArgs e)

        {

            UConsulta c = new UConsulta();

            c.Show();

        }
    }
}
