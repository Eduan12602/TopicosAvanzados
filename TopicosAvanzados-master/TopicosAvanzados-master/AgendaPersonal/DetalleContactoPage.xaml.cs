using System.ComponentModel;
using System.Runtime.CompilerServices;
using AgendaPersonal.Models;
namespace AgendaPersonal;

[QueryProperty(nameof(Contacto), "Contacto")]
public partial class DetalleContactoPage : ContentPage, INotifyPropertyChanged
{
    private Contacto _contacto;
    public Contacto Contacto
    {
        get => _contacto;
        set
        {
            _contacto = value;
            OnPropertyChanged();
            ActualizarUI();
        }
    }

    public DetalleContactoPage()
    {
        InitializeComponent();
    }

    private void ActualizarUI()
    {
        if (Contacto != null)
        {
            NombreLabel.Text = Contacto.Nombre;
            TelefonoLabel.Text = Contacto.Telefono;
            CorreoLabel.Text = Contacto.CorreoElectronico; // ← este es el correcto
            DireccionLabel.Text = ""; // opcional si ya no usas dirección
        }
    }
    private async void EliminarContacto_Clicked(object sender, EventArgs e)
    {
        if (Contacto == null)
            return;

        bool confirmar = await DisplayAlert("Confirmar", $"¿Eliminar a {Contacto.Nombre}?", "Sí", "No");

        if (confirmar)
        {
            await App.Database.EliminarContactoAsync(Contacto);
            await Shell.Current.GoToAsync(".."); // Regresa a la lista
        }
    }


    public new event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
