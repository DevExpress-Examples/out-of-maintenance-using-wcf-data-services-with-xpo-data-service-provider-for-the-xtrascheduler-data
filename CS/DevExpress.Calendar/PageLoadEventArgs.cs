using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace DevExpress.Calendar {
    public class PageLoadEventArgs {
        public PageLoadEventArgs(Type typeInfo,
                    bool shouldLoadData, object state) {
            this._typeInfo = typeInfo;
            this._shouldLoadData = shouldLoadData;
            this._state = state;
        }

        public PageLoadEventArgs(Type typeInfo, object state) {
            this._typeInfo = typeInfo;
            this._shouldLoadData = true;
            this._state = state;
        }

        Type _typeInfo;
        public Type TypeInfo {
            get {
                return this._typeInfo;
            }
        }

        object _state;
        public object State {
            get {
                return this._state;
            }
        }

        bool _shouldLoadData = true;
        public bool ShouldLoadData {
            get {
                return _shouldLoadData;
            }
            set {
                _shouldLoadData = false;
            }
        }
    }
}
