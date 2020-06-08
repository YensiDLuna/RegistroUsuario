using RegistroDeUsuario.BLL;
using RegistroDeUsuario.Entidades;
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

namespace RegistroDeUsuario
{
    /// <summary>
    /// Interaction logic for Rusuarioxaml
    /// </summary>
    public partial class Rusuario : Window
    {
        private Usuario Usuario = new Usuario();
        public Rusuario()
        
        {
			InitializeComponent();
			this.DataContext = Usuario;

		}
	private void Cargar()
	{
		this.DataContext = null;
		this.DataContext = Usuario;
	}

	private void Limpiar()
	{
		this.Usuario = new Usuario();
		this.DataContext = Usuario;

	}


	private bool Validar()
	{
		bool esValido = true;
		if (NombreTextBox.Text.Length == 0 )
		{
			esValido = false;
			MessageBox.Show("Transaccion fallida", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
		}
		return esValido;
	}

	private void BuButton_Clic(object serder, RoutedEventArgs e)
	{
		Usuario encotrado = UsuarioBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));
		if (encotrado != null)
		{
			this.Usuario = encotrado;
			Cargar();
			MessageBox.Show("Puntos encontrados!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
		}
		else
		{
			Limpiar();
			MessageBox.Show("No existe en la base de datos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

	private void NuevoButton_Click(object serder, RoutedEventArgs e)
	{
		Limpiar();
	}
	private void GuardarButton_Click(object serder, RoutedEventArgs e)
	{

		if (!Validar())
		{
			return;
		}
		var paso = UsuarioBLL.Guardar(Usuario);
		if (paso)
		{
			Limpiar();
			MessageBox.Show("Exito Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
		}
		else
		{
			MessageBox.Show("Exito Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
		private void EliminarButton_Click(object sender, RoutedEventArgs e)

		{

			if (UsuarioBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextBox.Text))) 

			{

				Limpiar();

				MessageBox.Show("Eliminado", "EXITO");

			}

			else

			{

				MessageBox.Show("No se pudo eliminar", "Error");

			}

		}
	}
}
