using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using DevExpress.Xpo.Services;
using DevExpress.Calendar.Model;
using DevExpress.Xpo;

namespace DevExpress.Calendar {
    public class Service : XpoDataService {
        public static void InitializeService(DataServiceConfiguration config) {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.UseVerboseErrors = true;
        }

        protected override void OnStartProcessingRequest(ProcessRequestArgs args) {
            base.OnStartProcessingRequest(args);
        }

        public override Xpo.DB.AutoCreateOption AutoCreateOption {
            get {
                return Xpo.DB.AutoCreateOption.DatabaseAndSchema;
            }
        }

        public override string ConnectionString {
            get {
                return @"Data Source=.\SQLExpress;Initial Catalog=Calendar;Integrated Security=True";
            }
        }

        protected override void RegisterEntities() {
            this.RegisterEntity(typeof(Appointment));
            this.RegisterEntity(typeof(Resource));
            base.RegisterEntities();
        }

    }
}
