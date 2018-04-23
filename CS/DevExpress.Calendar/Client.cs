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
    
    public partial class Client : DevExpress.XtraBars.Ribbon.RibbonForm {
        
        public Client() {
            InitializeComponent();
            defaultLookAndFeel.LookAndFeel.SkinName = "Office 2010 Blue";
            
            Pages.RegisterContentPresenter(clientPanel);
            Pages.RegisterWaitPresenter(pictureBox1, this);

            PopulateUserFilter();

            if (Security.Current.User != null) {

                barStaticCurrentUser.Caption = Security.Current.User.DisplayText;
            } else {

                barStaticCurrentUser.Caption = WindowsIdentity.GetCurrent().Name;
            }

            Pages.GoTo<Home>(null);
        }

        void PopulateUserFilter() {
            
            string currentUserName
                = WindowsIdentity.GetCurrent().Name.ToLower();

            userFilterBarButton.ItemClick += (object sender, ItemClickEventArgs e) => {
                Resource user
                    = e.Item.Tag as Resource;
                
                Debug.Assert(user != null);

                Filter.Current.User = user;
            };

            userFilterPopupMenu.BeginUpdate();
            try {

                userFilterPopupMenu.Popup += (object sender, EventArgs e) => {
                    foreach (BarItemLink itemLink in userFilterPopupMenu.ItemLinks) {
                        if (itemLink.Item.Tag is Resource && Filter.Current.User != null &&
                               ((Resource)itemLink.Item.Tag).ID == Filter.Current.User.ID) {

                            ((BarCheckItem)itemLink.Item).Checked = true;
                        } else {
                            ((BarCheckItem)itemLink.Item).Checked = false;
                        }
                    }
                };

                List<IDisposable> itemsToDispose 
                    = new List<IDisposable>();
                
                foreach (BarItemLink itemLink in userFilterPopupMenu.ItemLinks) {
                    IDisposable disp = itemLink.Item as IDisposable;
                    if (disp != null) {
                        itemsToDispose.Add(disp);
                    }
                }
                
                foreach (IDisposable disp in itemsToDispose) {
                    disp.Dispose();
                }
                
                userFilterPopupMenu.ItemLinks.Clear();

                var users = from p in new Model.Service(Program.Service).Resources
                            orderby p.Name
                            select p;

                BarCheckItem currentUserBarItem = null;

                foreach(Resource u in users) {
                    
                    bool bIsCurrentUser = (u.UserName.ToLower().Contains(currentUserName));
                    
                    BarCheckItem barCheckItem = new BarCheckItem();
                    barCheckItem.Caption = u.ToString();
                    barCheckItem.AllowAllUp = true;
                    barCheckItem.GroupIndex = 0xFF;
                    barCheckItem.Checked = bIsCurrentUser;
                    barCheckItem.Tag = u;
                    
                    barCheckItem.CheckedChanged += (object sender, ItemClickEventArgs e) => {
                        Resource user
                            = e.Item.Tag as Resource;
                        Debug.Assert(user != null);

                        if (!((BarCheckItem)e.Item).Checked) {
                            user = null;
                        }

                        Filter.Current.User = user;
                    };

                    if (!bIsCurrentUser) {
                        userFilterPopupMenu.ItemLinks.Add(barCheckItem);
                    } else {
                        currentUserBarItem = barCheckItem;
                    }
                }
                
                if (currentUserBarItem != null) {
                        userFilterBarButton.Tag = currentUserBarItem.Tag;
                    
                    if (userFilterPopupMenu.ItemLinks.Count > 0) {
                        userFilterPopupMenu.ItemLinks[0].BeginGroup = true;
                    }

                    userFilterPopupMenu.ItemLinks.Insert(0, currentUserBarItem);
                }

                Filter.Current.User 
                    = currentUserBarItem != null ? currentUserBarItem.Tag as Resource : null;

                Security.Current.User
                    = Filter.Current.User; 

            } finally {
                userFilterPopupMenu.EndUpdate();
            }
        }

        private void newItemBarButton_ItemClick(object sender, ItemClickEventArgs e) {
            ICalendar Calendar = Pages.ActivePage as ICalendar;
            if (Calendar != null) {
                Calendar.Create(Appointment.ItemCode.Task);
            }
        }

        private void newTaskBarButtonItem_ItemClick(object sender, ItemClickEventArgs e) {
            ICalendar Calendar = Pages.ActivePage as ICalendar;
            if (Calendar != null) {
                Calendar.Create(Appointment.ItemCode.Task);
            }
        }

        private void newAppointmentBarButtonItem_ItemClick(object sender, ItemClickEventArgs e) {
            ICalendar Calendar = Pages.ActivePage as ICalendar;
            if (Calendar != null) {
                Calendar.Create(Appointment.ItemCode.Appointment);
            }
        }

        private void newEventBarButtonItem_ItemClick(object sender, ItemClickEventArgs e) {
            ICalendar Calendar = Pages.ActivePage as ICalendar;
            if (Calendar != null) {
                Calendar.Create(Appointment.ItemCode.Event);
            }
        }

        private void newMeetingBarButtonItem_ItemClick(object sender, ItemClickEventArgs e) {
            ICalendar Calendar = Pages.ActivePage as ICalendar;
            if (Calendar != null) {
                Calendar.Create(Appointment.ItemCode.Meeting);
            }
        }

        private void newProjectBarButtonItem_ItemClick(object sender, ItemClickEventArgs e) {
            ICalendar Calendar = Pages.ActivePage as ICalendar;
            if (Calendar != null) {
                Calendar.Create(Appointment.ItemCode.Project);
            }
        }
    }
}