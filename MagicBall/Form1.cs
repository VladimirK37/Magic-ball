using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicBall
{
    public partial class Form1 : Form
    {
        private const string APP_Name = "MAGIC_BALL";
        private readonly string PREDICTIONS_CONFIG_PATH = $"{Environment.CurrentDirectory}\\PredictionsConfig.json";
        public Form1()
        {
            InitializeComponent();
        }

        private async void bPredict_Click(object sender, EventArgs e)
        {
            bPredict.Enabled = false;//отключение кнопки GO
            await Task.Run(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    Invoke(new Action(() =>
                    {
                        UpdateProgressBar(i);
                        Text = $"{i}%";
                    }));
                    Thread.Sleep(50);
                }
            });

            MessageBox.Show("message");

            progressBar1.Value = 0;

            Text = APP_Name;
            bPredict.Enabled = true;//использование повторно кнопки GO
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = APP_Name;

            try
            {
                var date = File.ReadAllText(PREDICTIONS_CONFIG_PATH);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }
}
