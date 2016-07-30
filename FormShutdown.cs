using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLIB.Misc;

namespace MyDownloader
{
    public partial class FormShutdown : Form
    {
        public FormShutdown()
        {
            InitializeComponent();
        }

        private int CountDown = 9;
        private bool Canceled = false;

        private void FormShutdown_Load(object sender, EventArgs e)
        {
            CountDown = 20;
            lbCount.Text = CountDown.ToString();
            timer1.Enabled = true;
        }

        public void DoShutdown()
        {
            timer1.Stop();
            this.Close();
            Application.Exit();
            Utils.Shutdown();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Canceled) return;
            CountDown--;
            if(CountDown >= 0)
            {
                lbCount.Text = CountDown.ToString();
            }
            else
            {
                DoShutdown();
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DoShutdown();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Canceled = true;
            timer1.Stop();
            this.Close();
        }
    }
}
