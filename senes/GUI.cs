using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokanNet;

namespace senes
{
    public partial class GUI : Form
    {
        private Task task;

        public GUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mount_Click(object sender, EventArgs e)
        {
            task = Task.Factory.StartNew(() =>
            {
                SenesFS senesfs = new SenesFS();
                senesfs.Mount("k", DokanOptions.DebugMode | DokanOptions.StderrOutput);
            });
        }

        private void unmount_Click(object sender, EventArgs e)
        {
            Dokan.RemoveMountPoint("k");
        }
    }
}
