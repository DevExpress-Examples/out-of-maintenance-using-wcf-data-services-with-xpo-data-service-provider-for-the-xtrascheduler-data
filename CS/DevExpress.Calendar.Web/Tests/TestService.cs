#if DEBUG
namespace DevExpress.Xpo.Services {
    using System;
    using System.Data.Services;
    using System.Data.Services.Client;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DevExpress.Calendar;
    using DevExpress.Calendar.Model;
    using DevExpress.Data.Filtering;
    using System.Security.Principal;

    [TestClass]
    public class TestService {
       
        UnitOfWork _session;
        UnitOfWork Session {
            get {
                if (_session == null) {
                    _session = new UnitOfWork();
                    using (Service service = new Service()) {
                        _session.ConnectionString = service.ConnectionString;
                    }
                }
                return _session;
            }
        }       

        [TestMethod]
        public void CreateUsers() {
            bool bHasChanges = false;

            Resource user = Session.FindObject<Resource>(new BinaryOperator("Email", "bill.gates@devexpress.com"));
            if (user == null) {
                user = new Resource(Session);
                user.UserName = WindowsIdentity.GetCurrent().Name;
                user.Name = "Bill Gates";
                user.Email = "bill.gates@devexpress.com";
                user.Save();
                bHasChanges = true;
            }

            user = Session.FindObject<Resource>(new BinaryOperator("Email", "bill.clinton@devexpress.com"));
            if (user == null) {
                user = new Resource(Session);
                user.UserName = @"DEVEXPRESS\BillC";
                user.Name = "Bill Clinton";
                user.Email = "bill.clinton@devexpress.com";
                user.Save();
                bHasChanges = true;
            }

            if (bHasChanges) {
                Session.CommitChanges();
            }
        }

    }
}
#endif