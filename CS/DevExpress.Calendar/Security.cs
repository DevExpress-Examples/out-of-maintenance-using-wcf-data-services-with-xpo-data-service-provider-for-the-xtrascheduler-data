namespace DevExpress.Calendar {
    using System;
    using DevExpress.Calendar.Model;
    public class Security {
        public static readonly Security Current = new Security();

        public Security() {
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
