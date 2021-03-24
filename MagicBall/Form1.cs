using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicBall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void bPredict_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                for (int i = 1; i < 100; i++)
                {
                    Invoke(new Action(() =>
                    {
                        UpdateProgressBar(i);
                    }));
                    Thread.Sleep(50);
                }
            });

            MessageBox.Show("message");
        }

        private void UpdateProgressBar(int i)
        {
            if (i == progressBar1.Maximum)
            {
                progressBar1.Maximum = i + 1;
                progressBar1.Value = i + 1;
                progressBar1.Maximum = i + 1;
            }
            else
            {
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = i;
        }
    }
}
