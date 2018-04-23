using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace WindowsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            XtraReport1 r = new XtraReport1();
            r.CreateDocument();
            xtraUserControl11.printControl1.PrintingSystem = r.PrintingSystem;
        }

        private void button2_Click(object sender, EventArgs e) {
            
            RegistryKey rk1 = Registry.ClassesRoot.OpenSubKey(".prnx") == null ? Registry.ClassesRoot.CreateSubKey(".prnx") : Registry.ClassesRoot.OpenSubKey(".prnx",true);
            rk1.SetValue("", "prnxfile");
            RegistryKey rk2 = Registry.ClassesRoot.OpenSubKey("prnxfile") == null ? Registry.ClassesRoot.CreateSubKey("prnxfile") : Registry.ClassesRoot.OpenSubKey("prnxfile", true);
            rk2.SetValue("", "DevExpress Printing System Document");
            RegistryKey rk3 = rk2.OpenSubKey("DefaultIcon") == null ? rk2.CreateSubKey("DefaultIcon") : rk2.OpenSubKey("DefaultIcon", true);
            rk3.SetValue("", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\App.ico" );
            RegistryKey rk4 = rk2.OpenSubKey("shell") == null ? rk2.CreateSubKey("shell") : rk2.OpenSubKey("shell");

            RegistryKey rk5 = rk4.OpenSubKey("open") == null ? rk4.CreateSubKey("open") : rk4.OpenSubKey("open");
            RegistryKey rk6 = rk5.OpenSubKey("command") == null ? rk5.CreateSubKey("command") : rk5.OpenSubKey("command", true);
            rk6.SetValue("", "\"" + Assembly.GetExecutingAssembly().Location + "\" \"%1\"");   

        }

        private void button3_Click(object sender, EventArgs e) {
            xtraUserControl11.printControl1.PrintingSystem.ClearContent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            if(WindowsApplication1.Program.FileToOpen != null) {
                xtraUserControl11.printControl1.PrintingSystem = new DevExpress.XtraPrinting.PrintingSystem();
                xtraUserControl11.printControl1.PrintingSystem.LoadDocument(WindowsApplication1.Program.FileToOpen);
            }

        }
    }
}