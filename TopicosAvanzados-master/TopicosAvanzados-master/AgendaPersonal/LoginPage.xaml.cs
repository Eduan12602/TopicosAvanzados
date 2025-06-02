using AgendaPersonal.Models;

namespace AgendaPersonal;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        var usuario = Username.Text?.Trim();
        var clave = Password.Text?.Trim();

        if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
        {
            await DisplayAlert("Error", "Ingresa usuario y contraseña.", "OK");
            return;
        }

        var userDB = await App.UsuarioDB.GetUsuarioAsync(usuario);
        if (userDB != null && userDB.Contrasena == clave)
        {
            Preferences.Set("UsuarioActual", usuario);
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
        }
    }
}