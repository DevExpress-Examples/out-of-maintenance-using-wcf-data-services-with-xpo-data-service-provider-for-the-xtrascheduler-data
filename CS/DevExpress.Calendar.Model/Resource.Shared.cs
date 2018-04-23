namespace DevExpress.Calendar.Model {
#if !WIN
    using DevExpress.Xpo;
#endif
    public partial class Resource {
#if !WIN
        [NonPersistent]
#endif
        public string DisplayText {
            get {
                return ToString();
            }
        }        

        /// <summary>Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</summary>
        /// <returns>A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString() {
            string name = Name;

            if (!string.IsNullOrEmpty(name)) {
                return name;
            }

            string email = Email;

            if (!string.IsNullOrEmpty(email)) {
                return email;
            }

            string userName = UserName;

            if (!string.IsNullOrEmpty(userName)) {
                return userName;
            }

            return base.ToString();
        }
    }
}