namespace DevExpress.Calendar.Parts {
    partial class AppointmentEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentEditor));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonHomePage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.repositoryItemRichEditFontSizeEdit1 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit();
            this.repositoryItemRichEditStyleEdit1 = new DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.richEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.endTimeEdit = new DevExpress.XtraEditors.TimeEdit();
            this.endDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.statusEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.statusLabel = new DevExpress.XtraEditors.LabelControl();
            this.subjectEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.startTimeEdit = new DevExpress.XtraEditors.TimeEdit();
            this.startDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endTimeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTimeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemSaveAndClose});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 45;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonHomePage});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemFontEdit1,
            this.repositoryItemRichEditFontSizeEdit1,
            this.repositoryItemRichEditStyleEdit1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.SelectedPage = this.ribbonHomePage;
            this.ribbon.Size = new System.Drawing.Size(770, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItemSaveAndClose
            // 
            this.barButtonItemSaveAndClose.Caption = "Save && Close";
            this.barButtonItemSaveAndClose.Id = 1;
            this.barButtonItemSaveAndClose.LargeGlyph = global::DevExpress.Calendar.Properties.Resources.SaveAndClose_Large;
            this.barButtonItemSaveAndClose.Name = "barButtonItemSaveAndClose";
            this.barButtonItemSaveAndClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnSaveAndClose);
            // 
            // ribbonHomePage
            // 
            this.ribbonHomePage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonHomePage.Name = "ribbonHomePage";
            this.ribbonHomePage.Text = "Task";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemSaveAndClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Action";
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // repositoryItemRichEditFontSizeEdit1
            // 
            this.repositoryItemRichEditFontSizeEdit1.AutoHeight = false;
            this.repositoryItemRichEditFontSizeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditFontSizeEdit1.Control = null;
            this.repositoryItemRichEditFontSizeEdit1.Name = "repositoryItemRichEditFontSizeEdit1";
            // 
            // repositoryItemRichEditStyleEdit1
            // 
            this.repositoryItemRichEditStyleEdit1.AutoHeight = false;
            this.repositoryItemRichEditStyleEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRichEditStyleEdit1.Control = null;
            this.repositoryItemRichEditStyleEdit1.Name = "repositoryItemRichEditStyleEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 530);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(770, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.panelControl2);
            this.clientPanel.Controls.Add(this.panelControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(770, 387);
            this.clientPanel.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.richEditControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 86);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(4);
            this.panelControl2.Size = new System.Drawing.Size(770, 301);
            this.panelControl2.TabIndex = 9;
            // 
            // richEditControl
            // 
            this.richEditControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl.Location = new System.Drawing.Point(4, 4);
            this.richEditControl.MenuManager = this.ribbon;
            this.richEditControl.Name = "richEditControl";
            this.richEditControl.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Visible;
            this.richEditControl.Size = new System.Drawing.Size(762, 293);
            this.richEditControl.TabIndex = 6;
            this.richEditControl.Views.DraftView.Padding = new System.Windows.Forms.Padding(15);
            this.richEditControl.Views.SimpleView.Padding = new System.Windows.Forms.Padding(10, 15, 4, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.endTimeEdit);
            this.panelControl1.Controls.Add(this.endDateEdit);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.statusEdit);
            this.panelControl1.Controls.Add(this.statusLabel);
            this.panelControl1.Controls.Add(this.subjectEdit);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.startTimeEdit);
            this.panelControl1.Controls.Add(this.startDateEdit);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(770, 86);
            this.panelControl1.TabIndex = 8;
            // 
            // endTimeEdit
            // 
            this.endTimeEdit.EditValue = new System.DateTime(2010, 7, 23, 0, 0, 0, 0);
            this.endTimeEdit.Location = new System.Drawing.Point(253, 59);
            this.endTimeEdit.MenuManager = this.ribbon;
            this.endTimeEdit.Name = "endTimeEdit";
            this.endTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.endTimeEdit.Size = new System.Drawing.Size(99, 20);
            this.endTimeEdit.TabIndex = 4;
            // 
            // endDateEdit
            // 
            this.endDateEdit.EditValue = null;
            this.endDateEdit.Location = new System.Drawing.Point(101, 59);
            this.endDateEdit.MenuManager = this.ribbon;
            this.endDateEdit.Name = "endDateEdit";
            this.endDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.endDateEdit.Size = new System.Drawing.Size(147, 20);
            this.endDateEdit.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 61);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "End date:";
            // 
            // statusEdit
            // 
            this.statusEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusEdit.Location = new System.Drawing.Point(407, 33);
            this.statusEdit.MenuManager = this.ribbon;
            this.statusEdit.Name = "statusEdit";
            this.statusEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.statusEdit.Properties.Items.AddRange(new object[] {
            "Not Started",
            "In Progress",
            "Canceled",
            "Completed"});
            this.statusEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.statusEdit.Size = new System.Drawing.Size(354, 20);
            this.statusEdit.TabIndex = 5;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(362, 36);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "Status:";
            // 
            // subjectEdit
            // 
            this.subjectEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectEdit.Location = new System.Drawing.Point(101, 7);
            this.subjectEdit.MenuManager = this.ribbon;
            this.subjectEdit.Name = "subjectEdit";
            this.subjectEdit.Size = new System.Drawing.Size(660, 20);
            this.subjectEdit.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Subject:";
            // 
            // startTimeEdit
            // 
            this.startTimeEdit.EditValue = new System.DateTime(2010, 7, 23, 0, 0, 0, 0);
            this.startTimeEdit.Location = new System.Drawing.Point(253, 33);
            this.startTimeEdit.MenuManager = this.ribbon;
            this.startTimeEdit.Name = "startTimeEdit";
            this.startTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.startTimeEdit.Size = new System.Drawing.Size(99, 20);
            this.startTimeEdit.TabIndex = 2;
            // 
            // startDateEdit
            // 
            this.startDateEdit.EditValue = null;
            this.startDateEdit.Location = new System.Drawing.Point(101, 33);
            this.startDateEdit.MenuManager = this.ribbon;
            this.startDateEdit.Name = "startDateEdit";
            this.startDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.startDateEdit.Size = new System.Drawing.Size(147, 20);
            this.startDateEdit.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Start date:";
            // 
            // AppointmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 555);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppointmentEditor";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Task Editor";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditFontSizeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichEditStyleEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endTimeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTimeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonHomePage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private XtraEditors.LabelControl labelControl1;
        private XtraEditors.DateEdit startDateEdit;
        private XtraBars.BarButtonItem barButtonItemSaveAndClose;
        private XtraEditors.TimeEdit startTimeEdit;
        private XtraEditors.LabelControl labelControl2;
        private XtraEditors.TextEdit subjectEdit;
        private XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit repositoryItemRichEditFontSizeEdit1;
        private XtraRichEdit.Design.RepositoryItemRichEditStyleEdit repositoryItemRichEditStyleEdit1;
        private XtraEditors.PanelControl panelControl1;
        internal XtraEditors.LabelControl statusLabel;
        private XtraEditors.ComboBoxEdit statusEdit;
        private XtraEditors.TimeEdit endTimeEdit;
        private XtraEditors.DateEdit endDateEdit;
        private XtraEditors.LabelControl labelControl4;
        private XtraEditors.PanelControl panelControl2;
        private XtraRichEdit.RichEditControl richEditControl;
    }
}