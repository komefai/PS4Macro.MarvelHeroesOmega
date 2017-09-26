// PS4Macro.MarvelHeroesOmega (File: Forms/MainForm.cs)
//
// Copyright (c) 2017 Komefai
//
// Visit http://komefai.com for more information
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using PS4MacroAPI;
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

        public void SetPlayerAxis(PointF point)
        {
            BeginInvoke(new Action(() =>
            {
                playerAxisDisplay.Value = point;
                playerAxisDisplay.Invalidate();
            }));
        }

        public void SetEnemyInfo(EnemyInfo enemyInfo)
        {
            BeginInvoke(new Action(() =>
            {
                int healthPercent = 0;

                if (enemyInfo == null)
                {
                    enemyLabel.Text = "-";
                }
                else
                {
                    enemyLabel.Text = "ENEMY";
                    healthPercent = enemyInfo.Health;
                }
                
                enemyHealthLabel.Text = string.Format("Health ({0}%)", healthPercent);
                enemyHealthProgressBar.Value = healthPercent;
            }));
        }

        public int GetUseMedKidBelowValue()
        {
            return (int)useMedKitNumericUpDown.Value;
        }

        public DualShockState GetDashControl()
        {
            if (dashComboBox.InvokeRequired)
            {
                return dashComboBox.Invoke(new Func<DualShockState>(GetDashControl)) as DualShockState;
            }
            else
            {
                var item = dashComboBox.SelectedItem as ControlComboBoxItem;
                if (item != null) return item.State;
                return null;
            }
        }

        public DualShockState GetAttackControl()
        {
            if (attackComboBox.InvokeRequired)
            {
                return attackComboBox.Invoke(new Func<DualShockState>(GetAttackControl)) as DualShockState;
            }
            else
            {
                var item = attackComboBox.SelectedItem as ControlComboBoxItem;
                if (item != null) return item.State;
                return null;
            }
        }

        private List<ControlComboBoxItem> CreateControlComboBoxCollection()
        {
            return new List<ControlComboBoxItem>()
            {
                new ControlComboBoxItem("Triangle", new DualShockState() { Triangle = true }),
                new ControlComboBoxItem("Circle", new DualShockState() { Circle = true }),
                new ControlComboBoxItem("Cross", new DualShockState() { Cross = true }),
                new ControlComboBoxItem("Square", new DualShockState() { Square = true }),
                new ControlComboBoxItem("L2 + Triangle", new DualShockState() { L2 = 255, Triangle = true }),
                new ControlComboBoxItem("L2 + Circle", new DualShockState() { L2 = 255, Circle = true }),
                new ControlComboBoxItem("L2 + Cross", new DualShockState() { L2 = 255, Cross = true }),
                new ControlComboBoxItem("L2 + Square", new DualShockState() { L2 = 255, Square = true }),
            };
        }

        private void BindControlComboBox(ComboBox comboBox, List<ControlComboBoxItem> collection)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = collection;
            comboBox.ValueMember = "State";
            comboBox.DisplayMember = "Name";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //healthProgressBar.SetState(2);
            //spiritProgressBar.SetState(3);

            var controlCollection = CreateControlComboBoxCollection();

            BindControlComboBox(dashComboBox, controlCollection);
            dashComboBox.SelectedIndex = 1;

            BindControlComboBox(attackComboBox, controlCollection);
            attackComboBox.SelectedIndex = 2;
        }
    }





    class ControlComboBoxItem
    {
        public string Name { get; set; }
        public DualShockState State { get; set; }

        public ControlComboBoxItem(string name, DualShockState state)
        {
            Name = name;
            State = state;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
