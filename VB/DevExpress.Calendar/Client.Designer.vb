Imports Microsoft.VisualBasic
Imports System
Namespace DevExpress.Calendar
	Partial Public Class Client
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Client))
            Me._ribbon = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.userFilterBarButton = New DevExpress.XtraBars.BarButtonItem()
            Me.userFilterPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
            Me.newItemBarButton = New DevExpress.XtraBars.BarButtonItem()
            Me.newItemPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
            Me.newAppointmentBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
            Me.newMeetingBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
            Me.newTaskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
            Me.newEventBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
            Me.newProjectBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
            Me.barStaticCurrentUser = New DevExpress.XtraBars.BarStaticItem()
            Me.ribbonHomePage = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonNewPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonFilterPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
            Me.clientPanel = New DevExpress.XtraEditors.PanelControl()
            Me.pictureBox1 = New System.Windows.Forms.PictureBox()
            Me.defaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            CType(Me._ribbon, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.userFilterPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.newItemPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.clientPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.clientPanel.SuspendLayout()
            CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' ribbon
            ' 
            Me._ribbon.ApplicationButtonText = Nothing
            Me._ribbon.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.userFilterBarButton, Me.newItemBarButton, Me.newAppointmentBarButtonItem, Me.newTaskBarButtonItem, Me.newEventBarButtonItem, Me.newMeetingBarButtonItem, Me.newProjectBarButtonItem, Me.barStaticCurrentUser})
            Me._ribbon.Location = New System.Drawing.Point(0, 0)
            Me._ribbon.MaxItemId = 10
            Me._ribbon.Name = "ribbon"
            Me._ribbon.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonHomePage})
            Me._ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010
            Me._ribbon.SelectedPage = Me.ribbonHomePage
            Me._ribbon.Size = New System.Drawing.Size(1164, 148)
            Me._ribbon.StatusBar = Me.ribbonStatusBar
            ' 
            ' userFilterBarButton
            ' 
            Me.userFilterBarButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
            Me.userFilterBarButton.Caption = "Filter"
            Me.userFilterBarButton.DropDownControl = Me.userFilterPopupMenu
            Me.userFilterBarButton.Id = 1
            Me.userFilterBarButton.LargeGlyph = My.Resources.UserFilter_Large
            Me.userFilterBarButton.Name = "userFilterBarButton"
            Me.userFilterBarButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
            ' 
            ' userFilterPopupMenu
            ' 
            Me.userFilterPopupMenu.Name = "userFilterPopupMenu"
            Me.userFilterPopupMenu.Ribbon = Me._ribbon
            ' 
            ' newItemBarButton
            ' 
            Me.newItemBarButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
            Me.newItemBarButton.Caption = "New"
            Me.newItemBarButton.DropDownControl = Me.newItemPopupMenu
            Me.newItemBarButton.Id = 3
            Me.newItemBarButton.LargeGlyph = My.Resources.Task_Large
            Me.newItemBarButton.Name = "newItemBarButton"
            Me.newItemBarButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
            '			Me.newItemBarButton.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.newItemBarButton_ItemClick);
            ' 
            ' newItemPopupMenu
            ' 
            Me.newItemPopupMenu.ItemLinks.Add(Me.newAppointmentBarButtonItem)
            Me.newItemPopupMenu.ItemLinks.Add(Me.newMeetingBarButtonItem)
            Me.newItemPopupMenu.ItemLinks.Add(Me.newTaskBarButtonItem)
            Me.newItemPopupMenu.ItemLinks.Add(Me.newEventBarButtonItem)
            Me.newItemPopupMenu.ItemLinks.Add(Me.newProjectBarButtonItem)
            Me.newItemPopupMenu.Name = "newItemPopupMenu"
            Me.newItemPopupMenu.Ribbon = Me._ribbon
            ' 
            ' newAppointmentBarButtonItem
            ' 
            Me.newAppointmentBarButtonItem.Caption = "Appointment"
            Me.newAppointmentBarButtonItem.Id = 4
            Me.newAppointmentBarButtonItem.Name = "newAppointmentBarButtonItem"
            '			Me.newAppointmentBarButtonItem.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.newAppointmentBarButtonItem_ItemClick);
            ' 
            ' newMeetingBarButtonItem
            ' 
            Me.newMeetingBarButtonItem.Caption = "Meeting"
            Me.newMeetingBarButtonItem.Id = 7
            Me.newMeetingBarButtonItem.Name = "newMeetingBarButtonItem"
            '			Me.newMeetingBarButtonItem.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.newMeetingBarButtonItem_ItemClick);
            ' 
            ' newTaskBarButtonItem
            ' 
            Me.newTaskBarButtonItem.Caption = "Task"
            Me.newTaskBarButtonItem.Id = 5
            Me.newTaskBarButtonItem.Name = "newTaskBarButtonItem"
            '			Me.newTaskBarButtonItem.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.newTaskBarButtonItem_ItemClick);
            ' 
            ' newEventBarButtonItem
            ' 
            Me.newEventBarButtonItem.Caption = "Event"
            Me.newEventBarButtonItem.Id = 6
            Me.newEventBarButtonItem.Name = "newEventBarButtonItem"
            '			Me.newEventBarButtonItem.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.newEventBarButtonItem_ItemClick);
            ' 
            ' newProjectBarButtonItem
            ' 
            Me.newProjectBarButtonItem.Caption = "Project"
            Me.newProjectBarButtonItem.Id = 8
            Me.newProjectBarButtonItem.Name = "newProjectBarButtonItem"
            '			Me.newProjectBarButtonItem.ItemClick += New DevExpress.XtraBars.ItemClickEventHandler(Me.newProjectBarButtonItem_ItemClick);
            ' 
            ' barStaticCurrentUser
            ' 
            Me.barStaticCurrentUser.Id = 9
            Me.barStaticCurrentUser.Name = "barStaticCurrentUser"
            Me.barStaticCurrentUser.TextAlignment = System.Drawing.StringAlignment.Near
            ' 
            ' ribbonHomePage
            ' 
            Me.ribbonHomePage.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ribbonNewPageGroup, Me.ribbonFilterPageGroup})
            Me.ribbonHomePage.Name = "ribbonHomePage"
            Me.ribbonHomePage.Text = "Home"
            ' 
            ' ribbonNewPageGroup
            ' 
            Me.ribbonNewPageGroup.ItemLinks.Add(Me.newItemBarButton)
            Me.ribbonNewPageGroup.Name = "ribbonNewPageGroup"
            Me.ribbonNewPageGroup.Text = "New"
            ' 
            ' ribbonFilterPageGroup
            ' 
            Me.ribbonFilterPageGroup.ItemLinks.Add(Me.userFilterBarButton)
            Me.ribbonFilterPageGroup.Name = "ribbonFilterPageGroup"
            Me.ribbonFilterPageGroup.Text = "Filter"
            ' 
            ' ribbonStatusBar
            ' 
            Me.ribbonStatusBar.ItemLinks.Add(Me.barStaticCurrentUser)
            Me.ribbonStatusBar.Location = New System.Drawing.Point(0, 720)
            Me.ribbonStatusBar.Name = "ribbonStatusBar"
            Me.ribbonStatusBar.Ribbon = Me._ribbon
            Me.ribbonStatusBar.Size = New System.Drawing.Size(1164, 23)
            ' 
            ' clientPanel
            ' 
            Me.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.clientPanel.Controls.Add(Me.pictureBox1)
            Me.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.clientPanel.Location = New System.Drawing.Point(0, 148)
            Me.clientPanel.Name = "clientPanel"
            Me.clientPanel.Size = New System.Drawing.Size(1164, 572)
            Me.clientPanel.TabIndex = 2
            ' 
            ' pictureBox1
            ' 
            Me.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pictureBox1.Image = My.Resources.Loading
            Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
            Me.pictureBox1.Name = "pictureBox1"
            Me.pictureBox1.Size = New System.Drawing.Size(1164, 572)
            Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.pictureBox1.TabIndex = 1
            Me.pictureBox1.TabStop = False
            ' 
            ' defaultLookAndFeel
            ' 
            Me.defaultLookAndFeel.LookAndFeel.SkinName = "Blue"
            ' 
            ' Client
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1164, 743)
            Me.Controls.Add(Me.clientPanel)
            Me.Controls.Add(Me.ribbonStatusBar)
            Me.Controls.Add(Me._ribbon)
            Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
            Me.Name = "Client"
            Me._ribbon = Me._ribbon
            Me.StatusBar = Me.ribbonStatusBar
            Me.Text = "Calendar"
            CType(Me._ribbon, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.userFilterPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.newItemPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.clientPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.clientPanel.ResumeLayout(False)
            CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private _ribbon As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonHomePage As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonFilterPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private ribbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
		Private clientPanel As DevExpress.XtraEditors.PanelControl
		Private defaultLookAndFeel As LookAndFeel.DefaultLookAndFeel
		Private userFilterBarButton As XtraBars.BarButtonItem
		Private userFilterPopupMenu As XtraBars.PopupMenu
		Private WithEvents newItemBarButton As XtraBars.BarButtonItem
		Private ribbonNewPageGroup As XtraBars.Ribbon.RibbonPageGroup
		Private WithEvents newAppointmentBarButtonItem As XtraBars.BarButtonItem
		Private WithEvents newTaskBarButtonItem As XtraBars.BarButtonItem
		Private WithEvents newEventBarButtonItem As XtraBars.BarButtonItem
		Private WithEvents newMeetingBarButtonItem As XtraBars.BarButtonItem
		Private newItemPopupMenu As XtraBars.PopupMenu
		Private WithEvents newProjectBarButtonItem As XtraBars.BarButtonItem
		Private pictureBox1 As System.Windows.Forms.PictureBox
		Private barStaticCurrentUser As XtraBars.BarStaticItem
	End Class
End Namespace