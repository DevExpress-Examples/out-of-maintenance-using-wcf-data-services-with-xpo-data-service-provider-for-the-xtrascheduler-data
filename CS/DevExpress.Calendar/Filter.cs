namespace DevExpress.Calendar {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using DevExpress.XtraBars;
    using DevExpress.Calendar.Parts;
    using DevExpress.Xpo;
    using System.Configuration;
    using DevExpress.Calendar.Model;
    using System.Linq;
    using System.Security.Principal;
    using System.Diagnostics;

    public class Filter {
        public static readonly Filter Current = new Filter();
        
        public Filter() {            
        }

        public event EventHandler UserChanged;
        void RaiseUserChanged() {
            if (UserChanged != null) {
                UserChanged(User, new EventArgs());
            }
        }

        Resource _user;
        public void SetCurrentUser(Resource value) {
            _user = value;
        }        
        public Resource User {
            get {
                return _user;
            }
            set {
                if (_user != value) {
                    _user = value;
                    RaiseUserChanged();
                }
            }
        }                                             
    }
}