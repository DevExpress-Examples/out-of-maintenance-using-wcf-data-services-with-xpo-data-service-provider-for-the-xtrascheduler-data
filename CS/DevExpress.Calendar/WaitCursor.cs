using System;
using System.Windows.Forms;

namespace DevExpress.Calendar {
    public class WaitCursor : IDisposable {

#if WIN
        Cursor _cursor;
#endif
        bool _disposed = false;
        
        public WaitCursor() {
#if WIN
            _cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
#endif
        }
        
        public void Dispose() {
            if (!_disposed) {
                _disposed = true;
#if WIN
                Cursor.Current = _cursor;
#endif
            }
        }
    }
}