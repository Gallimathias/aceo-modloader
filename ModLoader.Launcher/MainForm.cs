using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModLoader.Launcher
{
    public partial class MainForm : Form
    {
        private readonly Loader loader;

        public MainForm()
        {
            InitializeComponent();
            loader = new Loader(@"D:\Program Files (x86)\Steam\SteamApps\common\Airport CEO");
        }

        private void Button1Click(object sender, EventArgs e)
        {
            loader.Load();
            loader.Patch();
        }
    }
}
