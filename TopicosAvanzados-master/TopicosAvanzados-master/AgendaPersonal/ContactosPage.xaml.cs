using System.Collections.ObjectModel;
using AgendaPersonal.Models;
namespace AgendaPersonal;

public partial class ContactosPage : ContentPage
{
    public ObservableCollection<Contacto> Contactos { get; set; }

    public ContactosPage()
    {
        InitializeComponent();
        Contactos = new ObservableCollection<Contacto>();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Limpia lista actual y carga desde base de datos
        var lista = await App.Database.ObtenerContactosAsync();

        Contactos.Clear();
        foreach (var contacto in lista)
            Contactos.Add(contacto);
    }

    private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto contactoSeleccionado)
        {
            await Shell.Current.GoToAsync(nameof(DetalleContactoPage), true, new Dictionary<string, object>
            {
                { "Contacto", contactoSeleccionado }
            });
        }
        ((CollectionView)sender).SelectedItem = null;
    }
}