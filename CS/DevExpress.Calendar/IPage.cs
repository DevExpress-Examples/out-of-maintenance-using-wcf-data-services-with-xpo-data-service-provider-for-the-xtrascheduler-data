using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace DevExpress.Calendar {
    public interface IPage {
        void Page_Load(PageLoadEventArgs e);
        void Page_Invalidate();
    }
}
