using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PS4Macro.MarvelHeroesOmega
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void SetHealth(int healthPercent)
        {
            if (healthPercent < 0)
                return;

            BeginInvoke(new Action(() =>
            {
                healthLabel.Text = string.Format("Health ({0}%)", healthPercent);
                healthProgressBar.Value = healthPercent;
            }));
        }

        public void SetSpirit(int spiritPercent)
        {
            if (spiritPercent < 0)
                return;

            BeginInvoke(new Action(() =>
            {
                spiritLabel.Text = string.Format("Spirit ({0}%)", spiritPercent);
                spiritProgressBar.Value = spiritPercent;
            }));
        }

        public int GetUseMedKidBelowValue()
        {
            return (int)useMedKitNumericUpDown.Value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //healthProgressBar.SetState(2);
            //spiritProgressBar.SetState(3);
        }
    }
}
