namespace DevExpress.Calendar {
    using System;
    using System.Windows.Forms;
    
    public static class Program {
        static Uri _service
            = new Uri("http://localhost:60995/Service.svc");
        
        public static Uri Service {
            get {
                return _service;
            }
        }

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();
            
            Application.Run(new Client());
        }
    }
}