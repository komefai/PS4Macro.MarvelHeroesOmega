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
        private PlayerStatus m_PlayerStatus;
        private PlayerMovement m_PlayerMovement;
        private CombatSystem m_CombatSystem;

        public MainForm MainForm { get; private set; }
        public int HealthPercent { get; private set; }
        public int SpiritPercent { get; private set; }
        public double PlayerRotation { get; private set; }
        public double WalkDirection { get; private set; }
        public double WalkDistance { get; private set; }

        /* Constructor */
        public Script()
        {
            Config.Name = "Marvel Heroes Omega";
            Config.LoopDelay = 100;

            ScriptForm = MainForm = new MainForm();
        }

        // Called when the user pressed play
        public override void Start()
        {
            base.Start();

            //Test.Start();

            // Workaround
            if (!MainForm.IsHandleCreated)
            {
                Workaround.PressScriptButtonOnHost();
                if (!MainForm.IsHandleCreated)
                {
                    System.Windows.Forms.MessageBox.Show("Press the 'Script' button and try again");
                    System.Windows.Forms.Application.Exit();
                }
            }

            // Initialize instances
            m_PlayerStatus = new PlayerStatus();
            m_PlayerMovement = new PlayerMovement();
            m_CombatSystem = new CombatSystem();
        }

        // Called every interval set by LoopDelay
        public override void Update()
        {
            // Capture screenshot
            CaptureFrame();

            // Detect health
            HealthPercent = m_PlayerStatus.DetectHealth(this);
            MainForm.SetHealth(HealthPercent);

            // Detect spirit
            SpiritPercent = m_PlayerStatus.DetectSpirit(this);
            MainForm.SetSpirit(SpiritPercent);

            // Detect rotation
            PlayerRotation = m_PlayerMovement.DetectRotation(this);

            // Walk
            var walkInfo = m_PlayerMovement.FindWalkDirection(this);
            WalkDirection = walkInfo.Key;
            WalkDistance = walkInfo.Value;

            // TODO: Need refactoring and check
            //System.Diagnostics.Debug.WriteLine(" - - DIRECTION: {0}, Point: {1}", WalkDirection, Helper.DegreesToPoint(1.0f, WalkDirection));
            var playerAxis = Helper.DegreesToPoint(1.0f, WalkDirection - 90);
            playerAxis.Y *= -1;
            MainForm.SetPlayerAxis(playerAxis);

            // Combat system
            m_CombatSystem.Update(this);
        }
    }
}
