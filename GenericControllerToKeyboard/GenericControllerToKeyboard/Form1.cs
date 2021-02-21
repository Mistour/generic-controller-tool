using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace GenericControllerToKeyboard
{
    public partial class Form1 : Form
    {
        bool isRunning;
        List<ControllerManager> controllers = new List<ControllerManager>();
        Thread emulationThread;

        public Form1()
        {
            isRunning = false;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            InitializeComponent();
        }

        public List<ControllerManager> GetControllers()
        {
            //var gamepadGuid = Guid.Empty;
            var directInput = new DirectInput();
            //var gamepadInstance = new DeviceInstance();
            List<ControllerManager> gamepadList = new List<ControllerManager>();
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                gamepadList.Add(new ControllerManager(deviceInstance.ProductName, deviceInstance, this));
            }
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
            {
                gamepadList.Add(new ControllerManager(deviceInstance.ProductName, deviceInstance, this));
            }
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Driving, DeviceEnumerationFlags.AllDevices))
            {
                gamepadList.Add(new ControllerManager(deviceInstance.ProductName, deviceInstance, this));
            }
            if (gamepadList.Count != 0)
            {
                return gamepadList;
            }
            else return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controllers = GetControllers(); // get the list of connected controllers
            foreach(var controller in controllers)
            {
                controllerListBox.Items.Add(controller.name);
            }
            
        }

        private void button1_Click(object sender, EventArgs e) // Add button, to add a bind
        {
            Thread thread1 = new Thread(controllers[controllerListBox.SelectedIndex].AddBind);
            thread1.Start();
            ChangeTextBox("Press a controller button then a keyboard key to bind them");
        }

        private void button2_Click(object sender, EventArgs e) // Refresh button, to refresh the controller list
        {
            controllerListBox.Items.Clear();
            controllers = GetControllers(); // get the list of connected controllers
            foreach (var controller in controllers)
            {
                controllerListBox.Items.Add(controller.name);
            }
        }
        public void ChangeTextBox(string txt)
        {
            textBox1.Text = txt;
        }
        
        public void GetKeyboardKey(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach(var controller in controllers)
            {
                controller.KeyDown(e);
            }
            e.Handled = false;
        }

        private void removeSelected_Click(object sender, EventArgs e)
        {
            updateBindList(controllers[controllerListBox.SelectedIndex]);
            //controllers[controllerListBox.SelectedIndex].Remove(..);
        }

        public void updateBindList(ControllerManager controller) // Used to update the bind list using the dictionnary from ControllerManager class (spaghetti coding ??)
        {
            listBox1.Items.Clear();
            foreach(KeyValuePair<string,KeyEventArgs> pair in controller.binds)
            {
                listBox1.Items.Add( pair.Key + " -> " + pair.Value.KeyCode.ToString() );
            }
        }

        private void controllerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBindList(controllers[controllerListBox.SelectedIndex]);
        }

        private void runEmulationButton_Click(object sender, EventArgs e)
        {
            if (isRunning == false)
            {
                emulationThread = new Thread(controllers[controllerListBox.SelectedIndex].runEmulation);
                emulationThread.Start();
                ChangeTextBox("Emulation running !");
                isRunning = true;
            }
            else
            {
                emulationThread.Abort();
                isRunning = false;
                ChangeTextBox("Emulation stopped !");
            }
            
        }
    }
}