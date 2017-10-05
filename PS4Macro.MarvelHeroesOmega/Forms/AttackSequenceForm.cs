// PS4Macro.MarvelHeroesOmega (File: Forms/AttackSequenceForm.cs)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PS4MacroAPI;

namespace PS4Macro.MarvelHeroesOmega
{
    public partial class AttackSequenceForm : Form
    {
        public Dictionary<string, ButtonsToState> ButtonsDictionary { get; set; }
        public AttackSequenceForm()
        {
            InitializeComponent();
        }

        private void BindDataGrid()
        {
            if (Settings.Instance.Data.AttackSequence == null) return;

            dataGridView.AutoGenerateColumns = false;

            var bindingList = new BindingList<ButtonsWrapper>(Settings.Instance.Data.AttackSequence);
            dataGridView.DataSource = bindingList;
        }

        private void AttackSequenceForm_Load(object sender, EventArgs e)
        {
            delayNumericUpDown.Value = Settings.Instance.Data.AttackSequenceDelay;

            BindDataGrid();
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGridView = sender as DataGridView;

            if (dataGridView == null)
                return;

            if (e.RowIndex < 0 || e.RowIndex == dataGridView.NewRowIndex)
                return;

            if (e.ColumnIndex == dataGridView.Columns["Index"].Index)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void delayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var numericUpDown = sender as NumericUpDown;

            if (numericUpDown == null)
                return;

            Settings.Instance.Data.AttackSequenceDelay = (int)numericUpDown.Value;
        }
    }
}
