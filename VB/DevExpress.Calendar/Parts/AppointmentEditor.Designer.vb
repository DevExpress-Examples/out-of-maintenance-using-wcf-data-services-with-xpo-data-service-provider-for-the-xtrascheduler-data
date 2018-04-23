Imports Microsoft.VisualBasic
Imports System
Namespace DevExpress.Calendar.Parts
	Partial Public Class AppointmentEditor
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing


		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(AppointmentEditor))
            Me._ribbon = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.barButtonItemSaveAndClose = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonHomePage = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.repositoryItemFontEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemFontEdit()
            Me.repositoryItemRichEditFontSizeEdit1 = New DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit()
            Me.repositoryItemRichEditStyleEdit1 = New DevExpress.XtraRichEdit.Design.RepositoryItemRichEditStyleEdit()
            Me.ribbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
            Me.clientPanel = New DevExpress.XtraEditors.PanelControl()
            Me.panelControl2 = New DevExpress.XtraEditors.PanelControl()
            Me.richEditControl = New DevExpress.XtraRichEdit.RichEditControl()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.endTimeEdit = New DevExpress.XtraEditors.TimeEdit()
            Me.endDateEdit = New DevExpress.XtraEditors.DateEdit()
            Me.labelControl4 = New DevExpress.XtraEditors.LabelControl()
            Me.statusEdit = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.statusLabel = New DevExpress.XtraEditors.LabelControl()
            Me.subjectEdit = New DevExpress.XtraEditors.TextEdit()
            Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
            Me.startTimeEdit = New DevExpress.XtraEditors.TimeEdit()
            Me.startDateEdit = New DevExpress.XtraEditors.DateEdit()
            Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
            CType(Me._ribbon, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repositoryItemRichEditStyleEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.clientPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.clientPanel.SuspendLayout()
            CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl2.SuspendLayout()
            CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            CType(Me.endTimeEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.endDateEdit.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.endDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.statusEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.subjectEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startTimeEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startDateEdit.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' ribbon
            ' 
            Me._ribbon.ApplicationButtonText = Nothing
            Me._ribbon.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.barButtonItemSaveAndClose})
            Me._ribbon.Location = New System.Drawing.Point(0, 0)
            Me._ribbon.MaxItemId = 45
            Me._ribbon.Name = "ribbon"
            Me._ribbon.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonHomePage})
            Me._ribbon.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repositoryItemFontEdit1, Me.repositoryItemRichEditFontSizeEdit1, Me.repositoryItemRichEditStyleEdit1})
            Me._ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010
            Me._ribbon.SelectedPage = Me.ribbonHomePage
            Me._ribbon.Size = New System.Drawing.Size(770, 143)
            Me._ribbon.StatusBar = Me.ribbonStatusBar
            ' 
            ' barButtonItemSaveAndClose
            ' 
            Me.barButtonItemSaveAndClose.Caption = "Save && Close"
            Me.barButtonItemSaveAndClose.Id = 1
            Me.barButtonItemSaveAndClose.LargeGlyph = My.Resources.SaveAndClose_Large
            Me.barButtonItemSaveAndClose.Name = "barButtonItemSaveAndClose"
            Me.barButtonItemSaveAndClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
            '			Me.barButtonItemSaveAndClose.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.OnSaveAndClose);
            ' 
            ' ribbonHomePage
            ' 
            Me.ribbonHomePage.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ribbonPageGroup1})
            Me.ribbonHomePage.Name = "ribbonHomePage"
            Me.ribbonHomePage.Text = "Task"
            ' 
            ' ribbonPageGroup1
            ' 
            Me.ribbonPageGroup1.ItemLinks.Add(Me.barButtonItemSaveAndClose)
            Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
            Me.ribbonPageGroup1.Text = "Action"
            ' 
            ' repositoryItemFontEdit1
            ' 
            Me.repositoryItemFontEdit1.AutoHeight = False
            Me.repositoryItemFontEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1"
            ' 
            ' repositoryItemRichEditFontSizeEdit1
            ' 
            Me.repositoryItemRichEditFontSizeEdit1.AutoHeight = False
            Me.repositoryItemRichEditFontSizeEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repositoryItemRichEditFontSizeEdit1.Control = Nothing
            Me.repositoryItemRichEditFontSizeEdit1.Name = "repositoryItemRichEditFontSizeEdit1"
            ' 
            ' repositoryItemRichEditStyleEdit1
            ' 
            Me.repositoryItemRichEditStyleEdit1.AutoHeight = False
            Me.repositoryItemRichEditStyleEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repositoryItemRichEditStyleEdit1.Control = Nothing
            Me.repositoryItemRichEditStyleEdit1.Name = "repositoryItemRichEditStyleEdit1"
            ' 
            ' ribbonStatusBar
            ' 
            Me.ribbonStatusBar.Location = New System.Drawing.Point(0, 530)
            Me.ribbonStatusBar.Name = "ribbonStatusBar"
            Me.ribbonStatusBar.Ribbon = Me._ribbon
            Me.ribbonStatusBar.Size = New System.Drawing.Size(770, 25)
            ' 
            ' clientPanel
            ' 
            Me.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.clientPanel.Controls.Add(Me.panelControl2)
            Me.clientPanel.Controls.Add(Me.panelControl1)
            Me.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.clientPanel.Location = New System.Drawing.Point(0, 143)
            Me.clientPanel.Name = "clientPanel"
            Me.clientPanel.Size = New System.Drawing.Size(770, 387)
            Me.clientPanel.TabIndex = 2
            ' 
            ' panelControl2
            ' 
            Me.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.panelControl2.Controls.Add(Me.richEditControl)
            Me.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panelControl2.Location = New System.Drawing.Point(0, 86)
            Me.panelControl2.Name = "panelControl2"
            Me.panelControl2.Padding = New System.Windows.Forms.Padding(4)
            Me.panelControl2.Size = New System.Drawing.Size(770, 301)
            Me.panelControl2.TabIndex = 9
            ' 
            ' richEditControl
            ' 
            Me.richEditControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
            Me.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControl.Location = New System.Drawing.Point(4, 4)
            Me.richEditControl.MenuManager = Me._ribbon
            Me.richEditControl.Name = "richEditControl"
            Me.richEditControl.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Visible
            Me.richEditControl.Size = New System.Drawing.Size(762, 293)
            Me.richEditControl.TabIndex = 6
            Me.richEditControl.Views.DraftView.Padding = New System.Windows.Forms.Padding(15)
            Me.richEditControl.Views.SimpleView.Padding = New System.Windows.Forms.Padding(10, 15, 4, 0)
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.panelControl1.Controls.Add(Me.endTimeEdit)
            Me.panelControl1.Controls.Add(Me.endDateEdit)
            Me.panelControl1.Controls.Add(Me.labelControl4)
            Me.panelControl1.Controls.Add(Me.statusEdit)
            Me.panelControl1.Controls.Add(Me.statusLabel)
            Me.panelControl1.Controls.Add(Me.subjectEdit)
            Me.panelControl1.Controls.Add(Me.labelControl2)
            Me.panelControl1.Controls.Add(Me.startTimeEdit)
            Me.panelControl1.Controls.Add(Me.startDateEdit)
            Me.panelControl1.Controls.Add(Me.labelControl1)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(770, 86)
            Me.panelControl1.TabIndex = 8
            ' 
            ' endTimeEdit
            ' 
            Me.endTimeEdit.EditValue = New System.DateTime(2010, 7, 23, 0, 0, 0, 0)
            Me.endTimeEdit.Location = New System.Drawing.Point(253, 59)
            Me.endTimeEdit.MenuManager = Me._ribbon
            Me.endTimeEdit.Name = "endTimeEdit"
            Me.endTimeEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.endTimeEdit.Size = New System.Drawing.Size(99, 20)
            Me.endTimeEdit.TabIndex = 4
            ' 
            ' endDateEdit
            ' 
            Me.endDateEdit.EditValue = Nothing
            Me.endDateEdit.Location = New System.Drawing.Point(101, 59)
            Me.endDateEdit.MenuManager = Me._ribbon
            Me.endDateEdit.Name = "endDateEdit"
            Me.endDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.endDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.endDateEdit.Size = New System.Drawing.Size(147, 20)
            Me.endDateEdit.TabIndex = 3
            ' 
            ' labelControl4
            ' 
            Me.labelControl4.Location = New System.Drawing.Point(12, 61)
            Me.labelControl4.Name = "labelControl4"
            Me.labelControl4.Size = New System.Drawing.Size(47, 13)
            Me.labelControl4.TabIndex = 15
            Me.labelControl4.Text = "End date:"
            ' 
            ' statusEdit
            ' 
            Me.statusEdit.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.statusEdit.Location = New System.Drawing.Point(407, 33)
            Me.statusEdit.MenuManager = Me._ribbon
            Me.statusEdit.Name = "statusEdit"
            Me.statusEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.statusEdit.Properties.Items.AddRange(New Object() {"Not Started", "In Progress", "Canceled", "Completed"})
            Me.statusEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.statusEdit.Size = New System.Drawing.Size(354, 20)
            Me.statusEdit.TabIndex = 5
            ' 
            ' statusLabel
            ' 
            Me.statusLabel.Location = New System.Drawing.Point(362, 36)
            Me.statusLabel.Name = "statusLabel"
            Me.statusLabel.Size = New System.Drawing.Size(35, 13)
            Me.statusLabel.TabIndex = 12
            Me.statusLabel.Text = "Status:"
            ' 
            ' subjectEdit
            ' 
            Me.subjectEdit.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.subjectEdit.Location = New System.Drawing.Point(101, 7)
            Me.subjectEdit.MenuManager = Me._ribbon
            Me.subjectEdit.Name = "subjectEdit"
            Me.subjectEdit.Size = New System.Drawing.Size(660, 20)
            Me.subjectEdit.TabIndex = 0
            ' 
            ' labelControl2
            ' 
            Me.labelControl2.Location = New System.Drawing.Point(12, 10)
            Me.labelControl2.Name = "labelControl2"
            Me.labelControl2.Size = New System.Drawing.Size(40, 13)
            Me.labelControl2.TabIndex = 7
            Me.labelControl2.Text = "Subject:"
            ' 
            ' startTimeEdit
            ' 
            Me.startTimeEdit.EditValue = New System.DateTime(2010, 7, 23, 0, 0, 0, 0)
            Me.startTimeEdit.Location = New System.Drawing.Point(253, 33)
            Me.startTimeEdit.MenuManager = Me._ribbon
            Me.startTimeEdit.Name = "startTimeEdit"
            Me.startTimeEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.startTimeEdit.Size = New System.Drawing.Size(99, 20)
            Me.startTimeEdit.TabIndex = 2
            ' 
            ' startDateEdit
            ' 
            Me.startDateEdit.EditValue = Nothing
            Me.startDateEdit.Location = New System.Drawing.Point(101, 33)
            Me.startDateEdit.MenuManager = Me._ribbon
            Me.startDateEdit.Name = "startDateEdit"
            Me.startDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.startDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.startDateEdit.Size = New System.Drawing.Size(147, 20)
            Me.startDateEdit.TabIndex = 1
            ' 
            ' labelControl1
            ' 
            Me.labelControl1.Location = New System.Drawing.Point(12, 35)
            Me.labelControl1.Name = "labelControl1"
            Me.labelControl1.Size = New System.Drawing.Size(53, 13)
            Me.labelControl1.TabIndex = 1
            Me.labelControl1.Text = "Start date:"
            ' 
            ' AppointmentEditor
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(770, 555)
            Me.Controls.Add(Me.clientPanel)
            Me.Controls.Add(Me.ribbonStatusBar)
            Me.Controls.Add(Me._ribbon)
            Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
            Me.Name = "AppointmentEditor"
            Me._ribbon = Me._ribbon
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.StatusBar = Me.ribbonStatusBar
            Me.Text = "Task Editor"
            CType(Me._ribbon, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repositoryItemRichEditStyleEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.clientPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.clientPanel.ResumeLayout(False)
            CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl2.ResumeLayout(False)
            CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.panelControl1.PerformLayout()
            CType(Me.endTimeEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.endDateEdit.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.endDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.statusEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.subjectEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.startTimeEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.startDateEdit.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.startDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private _ribbon As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonHomePage As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private clientPanel As DevExpress.XtraEditors.PanelControl
		Private labelControl1 As XtraEditors.LabelControl
		Private startDateEdit As XtraEditors.DateEdit
		Private WithEvents barButtonItemSaveAndClose As XtraBars.BarButtonItem
		Private startTimeEdit As XtraEditors.TimeEdit
		Private labelControl2 As XtraEditors.LabelControl
		Private subjectEdit As XtraEditors.TextEdit
		Private repositoryItemFontEdit1 As XtraEditors.Repository.RepositoryItemFontEdit
		Private repositoryItemRichEditFontSizeEdit1 As XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit
		Private repositoryItemRichEditStyleEdit1 As XtraRichEdit.Design.RepositoryItemRichEditStyleEdit
		Private panelControl1 As XtraEditors.PanelControl
		Friend statusLabel As XtraEditors.LabelControl
		Private statusEdit As XtraEditors.ComboBoxEdit
		Private endTimeEdit As XtraEditors.TimeEdit
		Private endDateEdit As XtraEditors.DateEdit
		Private labelControl4 As XtraEditors.LabelControl
		Private panelControl2 As XtraEditors.PanelControl
		Private richEditControl As XtraRichEdit.RichEditControl
	End Class
End Namespace