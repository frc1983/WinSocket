using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinSocket
{
    public class HelperClass
    {
        Form1 Form { get; set; }

        public HelperClass(Form1 form)
        {
            Form = form;
        }

        internal void ServerStatus_onChange(Enum.ServerState state)
        {
            switch(state)
            {
                case WinSocket.Enum.ServerState.Running:
                    Form.SetLabel(Enum.ServerState.Running.ToString());
                    break;
                case WinSocket.Enum.ServerState.Stopped:
                    Form.SetLabel(Enum.ServerState.Stopped.ToString());
                    break;
                default:
                    Form.SetLabel(Enum.ServerState.Stopped.ToString());
                    break;
            }
        }
    }
}
