using System.Text.RegularExpressions;

namespace jcevallosT3.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) ||
               string.IsNullOrWhiteSpace(txtNombres.Text) ||
               string.IsNullOrWhiteSpace(txtApellidos.Text) ||
               string.IsNullOrWhiteSpace(txtCorreo.Text) ||
               string.IsNullOrWhiteSpace(txtSalario.Text)) 
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

     
        if (pickerIdentificacion.SelectedItem.ToString() == "CI" && txtIdentificacion.Text.Length != 10)
        {
            await DisplayAlert("Error", "La cédula debe tener 10 dígitos", "OK");
            return;
        }

        else if (pickerIdentificacion.SelectedItem.ToString() == "RUC" && txtIdentificacion.Text.Length != 13)
        {
            await DisplayAlert("Error", "El RUC debe tener 13 dígitos", "OK");
            return;
        }

       
        if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Error", "Correo electrónico inválido", "OK");
            return;
        }

      
        double salario = double.Parse(txtSalario.Text);
        await Navigation.PushAsync(new vSecundaria(
            pickerIdentificacion.SelectedItem.ToString(),
            txtIdentificacion.Text,
            txtNombres.Text,
            txtApellidos.Text,
            dateFechaNacimiento.Date,
            txtCorreo.Text,
            salario));
    }

}
