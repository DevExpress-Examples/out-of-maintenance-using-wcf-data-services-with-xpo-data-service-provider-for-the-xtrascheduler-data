namespace DevExpress.Calendar {
    partial class Client {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.userFilterBarButton = new DevExpress.XtraBars.BarButtonItem();
            this.userFilterPopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.newItemBarButton = new DevExpress.XtraBars.BarButtonItem();
            this.newItemPopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.newAppointmentBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.newMeetingBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.newTaskBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.newEventBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.newProjectBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticCurrentUser = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonHomePage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonNewPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonFilterPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userFilterPopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newItemPopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.userFilterBarButton,
            this.newItemBarButton,
            this.newAppointmentBarButtonItem,
            this.newTaskBarButtonItem,
            this.newEventBarButtonItem,
            this.newMeetingBarButtonItem,
            this.newProjectBarButtonItem,
            this.barStaticCurrentUser});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonHomePage});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.SelectedPage = this.ribbonHomePage;
            this.ribbon.Size = new System.Drawing.Size(1164, 148);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // userFilterBarButton
            // 
            this.userFilterBarButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.userFilterBarButton.Caption = "Filter";
            this.userFilterBarButton.DropDownControl = this.userFilterPopupMenu;
            this.userFilterBarButton.Id = 1;
            this.userFilterBarButton.LargeGlyph = global::DevExpress.Calendar.Properties.Resources.UserFilter_Large;
            this.userFilterBarButton.Name = "userFilterBarButton";
            this.userFilterBarButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // userFilterPopupMenu
            // 
            this.userFilterPopupMenu.Name = "userFilterPopupMenu";
            this.userFilterPopupMenu.Ribbon = this.ribbon;
            // 
            // newItemBarButton
            // 
            this.newItemBarButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.newItemBarButton.Caption = "New";
            this.newItemBarButton.DropDownControl = this.newItemPopupMenu;
            this.newItemBarButton.Id = 3;
            this.newItemBarButton.LargeGlyph = global::DevExpress.Calendar.Properties.Resources.Task_Large;
            this.newItemBarButton.Name = "newItemBarButton";
            this.newItemBarButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.newItemBarButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newItemBarButton_ItemClick);
            // 
            // newItemPopupMenu
            // 
            this.newItemPopupMenu.ItemLinks.Add(this.newAppointmentBarButtonItem);
            this.newItemPopupMenu.ItemLinks.Add(this.newMeetingBarButtonItem);
            this.newItemPopupMenu.ItemLinks.Add(this.newTaskBarButtonItem);
            this.newItemPopupMenu.ItemLinks.Add(this.newEventBarButtonItem);
            this.newItemPopupMenu.ItemLinks.Add(this.newProjectBarButtonItem);
            this.newItemPopupMenu.Name = "newItemPopupMenu";
            this.newItemPopupMenu.Ribbon = this.ribbon;
            // 
            // newAppointmentBarButtonItem
            // 
            this.newAppointmentBarButtonItem.Caption = "Appointment";
            this.newAppointmentBarButtonItem.Id = 4;
            this.newAppointmentBarButtonItem.Name = "newAppointmentBarButtonItem";
            this.newAppointmentBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newAppointmentBarButtonItem_ItemClick);
            // 
            // newMeetingBarButtonItem
            // 
            this.newMeetingBarButtonItem.Caption = "Meeting";
            this.newMeetingBarButtonItem.Id = 7;
            this.newMeetingBarButtonItem.Name = "newMeetingBarButtonItem";
            this.newMeetingBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newMeetingBarButtonItem_ItemClick);
            // 
            // newTaskBarButtonItem
            // 
            this.newTaskBarButtonItem.Caption = "Task";
            this.newTaskBarButtonItem.Id = 5;
            this.newTaskBarButtonItem.Name = "newTaskBarButtonItem";
            this.newTaskBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newTaskBarButtonItem_ItemClick);
            // 
            // newEventBarButtonItem
            // 
            this.newEventBarButtonItem.Caption = "Event";
            this.newEventBarButtonItem.Id = 6;
            this.newEventBarButtonItem.Name = "newEventBarButtonItem";
            this.newEventBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newEventBarButtonItem_ItemClick);
            // 
            // newProjectBarButtonItem
            // 
            this.newProjectBarButtonItem.Caption = "Project";
            this.newProjectBarButtonItem.Id = 8;
            this.newProjectBarButtonItem.Name = "newProjectBarButtonItem";
            this.newProjectBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newProjectBarButtonItem_ItemClick);
            // 
            // barStaticCurrentUser
            // 
            this.barStaticCurrentUser.Id = 9;
            this.barStaticCurrentUser.Name = "barStaticCurrentUser";
            this.barStaticCurrentUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonHomePage
            // 
            this.ribbonHomePage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonNewPageGroup,
            this.ribbonFilterPageGroup});
            this.ribbonHomePage.Name = "ribbonHomePage";
            this.ribbonHomePage.Text = "Home";
            // 
            // ribbonNewPageGroup
            // 
            this.ribbonNewPageGroup.ItemLinks.Add(this.newItemBarButton);
            this.ribbonNewPageGroup.Name = "ribbonNewPageGroup";
            this.ribbonNewPageGroup.Text = "New";
            // 
            // ribbonFilterPageGroup
            // 
            this.ribbonFilterPageGroup.ItemLinks.Add(this.userFilterBarButton);
            this.ribbonFilterPageGroup.Name = "ribbonFilterPageGroup";
            this.ribbonFilterPageGroup.Text = "Filter";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticCurrentUser);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 720);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1164, 23);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.pictureBox1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 148);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(1164, 572);
            this.clientPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DevExpress.Calendar.Properties.Resources.Loading;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1164, 572);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Blue";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 743);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Client";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userFilterPopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newItemPopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonHomePage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonFilterPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private XtraBars.BarButtonItem userFilterBarButton;
        private XtraBars.PopupMenu userFilterPopupMenu;
        private XtraBars.BarButtonItem newItemBarButton;
        private XtraBars.Ribbon.RibbonPageGroup ribbonNewPageGroup;
        private XtraBars.BarButtonItem newAppointmentBarButtonItem;
        private XtraBars.BarButtonItem newTaskBarButtonItem;
        private XtraBars.BarButtonItem newEventBarButtonItem;
        private XtraBars.BarButtonItem newMeetingBarButtonItem;
        private XtraBars.PopupMenu newItemPopupMenu;
        private XtraBars.BarButtonItem newProjectBarButtonItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private XtraBars.BarStaticItem barStaticCurrentUser;
    }
}