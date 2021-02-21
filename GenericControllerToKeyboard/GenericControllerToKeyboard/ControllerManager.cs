using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using System.Windows.Input;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GenericControllerToKeyboard
{
    public delegate void MyDelegate1(ControllerManager controllerManager); //delegates having same signature as method 
    public delegate void MyDelegate2(string msg); //delegates having same signature as method

    public class ControllerManager
    {
        public string name;
        KeyEventArgs lastKey;
        private Form1 form;
        private Joystick joystick;
        public IDictionary<string, KeyEventArgs> binds = new Dictionary<string, KeyEventArgs>();
        private bool waitingForKey = false;
        MyDelegate1 updateBindListDelegate;

        public ControllerManager(string productName, DeviceInstance deviceInstance, Form1 form1)
        {
            name = productName;
            form = form1;
            Guid guid = deviceInstance.InstanceGuid;
            DirectInput directInput = new DirectInput();
            joystick = new Joystick(directInput, guid);
            joystick.Properties.BufferSize = 512;
            joystick.Acquire();
            updateBindListDelegate = new MyDelegate1(form1.updateBindList);
        }
        public void AddBind()
        {

            string controllerButton="";
            KeyEventArgs keyboardKey;

            Console.WriteLine("Starting Thread"); // THREAD DEBUG

            //form.ChangeTextBox("Press a controller button");

            int delay = 0; // We will have to scan the inputs after a quick delay to prevent ghost inputs.
            while (delay >= 25) { joystick.Poll(); delay++; } // Ugly(?) but it works
            bool scan = true;
            while (scan == true)
            {
                joystick.Poll();
                var state = joystick.GetBufferedData().ToList();
                foreach(var s in state)
                {
                    if (s.Value <= 256 & scan==true)
                    {
                        controllerButton = s.Offset.ToString();
                        Console.WriteLine(controllerButton);
                        scan = false;
                    }
                }
                
            }

            //form.ChangeTextBox("Press a keyboard key");

            waitingForKey = true;
            while (waitingForKey == true)
            {
            }
            keyboardKey = lastKey;

            binds[controllerButton] = keyboardKey;
            //this.updateBindListDelegate(this);
        }

        public void KeyDown(KeyEventArgs key)
        {
            this.lastKey = key;
            waitingForKey = false;
        }

        public void runEmulation()
        {
            const uint WM_KEYDOWN = 0x0100;
            const uint WM_KEYUP = 0x0101;

            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
            static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

            while (true)
            {
                joystick.Poll();
                foreach(var state in joystick.GetBufferedData())
                {
                    if (binds.Keys.Contains(state.Offset.ToString()))
                    {
                        var k = binds[state.Offset.ToString()];
                        if (state.Value == 128)
                        {
                            PostMessage(GetForegroundWindow(), WM_KEYDOWN, k.KeyValue,0);
                            // hWnd - Window handler (can be getted by using GetForegroundWindow/FindWindow methods)
                            // msg - Key up/down message (WM_KEYUP / WM_KEYDOWN)
                            // wParam - Virual key code you need to pass to the window
                            // lParam - Additional parameter for set up key message behaviour.
                        }else if(state.Value == 0){
                            PostMessage(GetForegroundWindow(), WM_KEYUP, k.KeyValue,0);
                        }

                    }
                }
            }
        }

    }
}
