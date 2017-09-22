// PS4Macro.MarvelHeroesOmega (File: Classes/Script.cs)
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
using System.Linq;
using System.Text;

namespace PS4Macro.MarvelHeroesOmega
{
    public class Script : ScriptBase
    {
        private MainForm m_MainForm;
        private PlayerStatus m_PlayerStatus;
        private EnemyRadar m_EnemyRadar;

        /* Constructor */
        public Script()
        {
            Config.Name = "Marvel Heroes Omega";
            Config.LoopDelay = 500;

            ScriptForm = m_MainForm = new MainForm();
        }

        // Called when the user pressed play
        public override void Start()
        {
            base.Start();

            //Test.Start();

            if (!m_MainForm.IsHandleCreated)
            {
                System.Windows.Forms.MessageBox.Show("Press the 'Script' button and try again");
                System.Windows.Forms.Application.Exit();
            }

            // Initialize instances
            m_PlayerStatus = new PlayerStatus();
            m_EnemyRadar = new EnemyRadar();
        }

        // Called every interval set by LoopDelay
        public override void Update()
        {
            // Capture screenshot
            CaptureFrame();

            // Detect health
            int healthPercent = m_PlayerStatus.DetectHealth(this);
            m_MainForm.SetHealth(healthPercent);

            // Use med kit
            if (healthPercent <= m_MainForm.GetUseMedKidBelowValue())
            {
                Press(new DualShockState() { L1 = true });
            }

            // Detect spirit
            int spiritPercent = m_PlayerStatus.DetectSpirit(this);
            m_MainForm.SetSpirit(spiritPercent);

            // Detect enemy
            EnemyInfo enemy = m_EnemyRadar.DetectEnemy(this);

            // Attack
            if (enemy != null)
            {
                Press(new DualShockState() { Cross = true });
            }
        }
    }
}
