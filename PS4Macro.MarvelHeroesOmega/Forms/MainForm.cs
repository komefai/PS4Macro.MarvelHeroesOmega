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
using System.Reflection;
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

        public void SetCurrentScene(string name)
        {
            BeginInvoke(new Action(() =>
            {
                string text = name ?? "-";
                currentSceneLabel.Text = $"Scene: {text}";
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

        public ControlComboBoxItem GetDashControl()
        {
            if (dashComboBox.InvokeRequired)
            {
                return dashComboBox.Invoke(new Func<ControlComboBoxItem>(GetDashControl)) as ControlComboBoxItem;
            }
            else
            {
                return dashComboBox.SelectedItem as ControlComboBoxItem;
            }
        }

        public ControlComboBoxItem GetAttackControl()
        {
            if (attackComboBox.InvokeRequired)
            {
                return attackComboBox.Invoke(new Func<ControlComboBoxItem>(GetAttackControl)) as ControlComboBoxItem;
            }
            else
            {
                return attackComboBox.SelectedItem as ControlComboBoxItem;
            }
        }

        private List<ControlComboBoxItem> CreateControlComboBoxCollection()
        {
            return new List<ControlComboBoxItem>()
            {
                new ControlComboBoxItem("Triangle", new string[] { "Triangle" }, new DualShockState() { Triangle = true }),
                new ControlComboBoxItem("Circle", new string[] { "Circle" }, new DualShockState() { Circle = true }),
                new ControlComboBoxItem("Cross", new string[] { "Cross" }, new DualShockState() { Cross = true }),
                new ControlComboBoxItem("Square", new string[] { "Square" }, new DualShockState() { Square = true }),
                new ControlComboBoxItem("L2 + Triangle", new string[] { "L2", "Triangle" }, new DualShockState() { L2 = 255, Triangle = true }),
                new ControlComboBoxItem("L2 + Circle", new string[] { "L2", "Circle" }, new DualShockState() { L2 = 255, Circle = true }),
                new ControlComboBoxItem("L2 + Cross", new string[] { "L2", "Cross" }, new DualShockState() { L2 = 255, Cross = true }),
                new ControlComboBoxItem("L2 + Square", new string[] { "L2", "Square" }, new DualShockState() { L2 = 255, Square = true }),
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
            var controlCollection = CreateControlComboBoxCollection();

            // Dash comboBox
            BindControlComboBox(dashComboBox, controlCollection);
            dashComboBox.SelectedIndex = 1;

            // Attack comboBox
            BindControlComboBox(attackComboBox, controlCollection);
            attackComboBox.SelectedIndex = 2;

            // Startup macro
            startupMacroButton.Tag = MacroManager.KEY_STARTUP;
            // Prepare Combat macro
            prepareCombatMacroButton.Tag = MacroManager.KEY_PREPARE_COMBAT;
        }

        #region Macros
        private void macroButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tag = button.Tag.ToString();

            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Assembly.GetEntryAssembly().Location;
            openFileDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*"; ;
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load
                MacroManager.Instance.PathDictionary[tag] = openFileDialog.FileName;
                button.Text = "OK";
            }
        }
        #endregion

        #region Debug
        private void lootDebugButton_Click(object sender, EventArgs e)
        {
            new DebugLootForm().Show(this);
        }
        #endregion
    }





    public class ControlComboBoxItem
    {
        public string Name { get; set; }
        public string[] Properties { get; set; }
        public DualShockState State { get; set; }

        public ControlComboBoxItem(string name, string[] properties, DualShockState state)
        {
            Name = name;
            Properties = properties;
            State = state;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
