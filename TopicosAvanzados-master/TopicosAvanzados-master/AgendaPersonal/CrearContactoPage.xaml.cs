using AgendaPersonal.Models;

namespace AgendaPersonal;

public partial class CrearContactoPage : ContentPage
{
    private Contacto contacto;

    // Constructor para agregar contacto nuevo
    public CrearContactoPage()
    {
        InitializeComponent();
        contacto = new Contacto(); // nuevo contacto
    }

    // Constructor para editar contacto existente
    public CrearContactoPage(Contacto existente)
    {
        InitializeComponent();
        contacto = existente;

        // Cargar los datos en los campos
        entryNombre.Text = contacto.Nombre;
        entryCorreo.Text = contacto.CorreoElectronico;
        entryTelefono.Text = contacto.Telefono;
    }
    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNombre.Text) ||
            string.IsNullOrWhiteSpace(entryCorreo.Text) ||
            string.IsNullOrWhiteSpace(entryTelefono.Text))
        {
            await DisplayAlert("Error", "Todos los campos obligatorios deben estar llenos.", "OK");
            return;
        }

        contacto.Nombre = entryNombre.Text;
        contacto.CorreoElectronico = entryCorreo.Text;
        contacto.Telefono = entryTelefono.Text;
        contacto.Direccion = entryDireccion.Text;
        contacto.Activo = true;

        await App.Database.GuardarContactoAsync(contacto);
        await DisplayAlert("Éxito", "Contacto guardado correctamente", "OK");
        await Shell.Current.GoToAsync("..");
    }
}
