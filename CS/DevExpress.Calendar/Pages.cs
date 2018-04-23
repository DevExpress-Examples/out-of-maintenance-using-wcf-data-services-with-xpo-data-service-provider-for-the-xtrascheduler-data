using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Diagnostics;

namespace DevExpress.Calendar {
    public static class Pages {
        static Control s_ContentPresenter;
        public static Control ContentPresenter {
            get {
                return s_ContentPresenter;
            }
            set {
                s_ContentPresenter = value;
            }
        }
        public static void RegisterContentPresenter(Control contentPresenter) {
            ContentPresenter = contentPresenter;
        }

        static Control s_WaitPresenter;
        static Control[] s_WaitControlsList;

        public static void RegisterWaitPresenter(Control waitPresenter, params Control[] waitControlsList) {
            s_WaitPresenter = waitPresenter;
            s_WaitControlsList = waitControlsList;
 
            if (s_WaitPresenter != null) {
                s_WaitPresenter.Hide();
            }
        }

        static int s_IsWaiting = 0;

        public static void ShowWaitPanel() {
            int isWaiting = System.Threading.Interlocked.Increment(ref s_IsWaiting);
            Debug.Assert(isWaiting > 0);
            
            if (isWaiting > 0) {
                
                if (s_WaitPresenter != null) {
                    s_WaitPresenter.Show();
                    s_WaitPresenter.BringToFront();
                    Application.DoEvents();
                }
                
                if (isWaiting == 0) {
                    if (s_WaitControlsList != null) {
                        foreach (Control c in s_WaitControlsList) {
                            if (c != null) {
                                c.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        public static void HideWaitPanel() {
            int isWaiting = System.Threading.Interlocked.Decrement(ref s_IsWaiting);
            Debug.Assert(isWaiting >= 0);

            if (isWaiting == 0) {
                if (s_WaitPresenter != null) {
                    s_WaitPresenter.Hide();
                }
                if (s_WaitControlsList != null) {
                    foreach (Control c in s_WaitControlsList) {
                        if (c != null) {
                            c.Enabled = true;
                        }
                    }
                }
            }
        }

        static Control s_ActivePage;
        public static Control ActivePage {
            get {
                return s_ActivePage;
            }
            set {
                s_ActivePage = value;
            }
        }
        
        static Dictionary<Type, UserControl> s_Pages 
            = new Dictionary<Type, UserControl>();
        
        public static void GoTo<T>(PageLoadEventArgs e)
            where T : UserControl, new() {
            
            if (s_ContentPresenter == null) {
                return;
            }
            
            using (new WaitCursor()) {

                ShowWaitPanel();
                s_ContentPresenter.SuspendLayout();

                try {
                    UserControl c = null;

                    if (!s_Pages.TryGetValue(typeof(T), out c)) {
                        c = null;
                    }

                    if (c == null) {
                        c = new T();
                        c.Parent = s_ContentPresenter;
                        c.Dock = DockStyle.Fill;
                        s_Pages.Add(typeof(T), c);
                    }

                    s_ActivePage = c;

                    c.Show();
                    c.BringToFront();

                    if (s_WaitPresenter != null) {
                        s_WaitPresenter.Show();
                        s_WaitPresenter.BringToFront();
                    }



                    IPage page = c as IPage;

                    if (page != null) {
                        page.Page_Load(e);
                    }

                    if (c.Handle != IntPtr.Zero) {
                        c.Invoke(new Action(() => { c.Focus(); }));
                    }

                } finally {

                    s_ContentPresenter.ResumeLayout();
                    HideWaitPanel();

                }

            }
        }
    }
}
