namespace jcevallosT3.Views;

public partial class vSecundaria : ContentPage
{
    private string datosExportar;

    public vSecundaria(string tipoId, string id, string nombres, string apellidos, 
        DateTime fecha, string correo, double salario)
    {
        InitializeComponent();

        double aporteIESS = salario * 0.0945; // 9.45% aporte

        lblIdentificacion.Text = $"Identificación ({tipoId}): {id}";
        lblNombres.Text = $"Nombres: {nombres}";
        lblApellidos.Text = $"Apellidos: {apellidos}";
        lblFecha.Text = $"Fecha de Nacimiento: {fecha:d}";
        lblCorreo.Text = $"Correo: {correo}";
        lblSalario.Text = $"Salario: ${salario:F2}";
        lblAporte.Text = $"Aporte al IESS: ${aporteIESS:F2}";

        datosExportar = $"{lblIdentificacion.Text}\n{lblNombres.Text}\n{lblApellidos.Text}" +
            $"\n{lblFecha.Text}\n{lblCorreo.Text}\n{lblSalario.Text}\n{lblAporte.Text}";
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string filename = Path.Combine(FileSystem.AppDataDirectory, "Contacto.txt");
        File.WriteAllText(filename, datosExportar);

        await DisplayAlert("Exportación de datos exitosa", $"Datos exportados a:\n{filename}", "OK");
    }
}