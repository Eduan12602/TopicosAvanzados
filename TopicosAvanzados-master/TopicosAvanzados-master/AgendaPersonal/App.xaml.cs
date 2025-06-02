using AgendaPersonal.Data;

namespace AgendaPersonal
{
    public partial class App : Application
    {
        private static ContactoDatabase database;
        public static ContactoDatabase Database
        {
            get
            {
                if (database == null)
                    database = new ContactoDatabase();
                return database;
            }
        }

        private static UsuarioDatabase usuarioDatabase;
        public static UsuarioDatabase UsuarioDB
        {
            get
            {
                if (usuarioDatabase == null)
                    usuarioDatabase = new UsuarioDatabase();
                return usuarioDatabase;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
