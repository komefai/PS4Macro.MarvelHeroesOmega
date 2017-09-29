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
        private LootSystem m_LootSystem;

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


            CurrentQueueState = new DualShockState();
            ReleaseQueueState = new List<KeyValuePair<string[], DateTime>>();
        }

        // Called when the user pressed play
        public override void Start()
        {
            base.Start();

            //Test.Start();

            //Test.EternitySplinterDetect();

            // Initialize instances
            m_PlayerStatus = new PlayerStatus();
            m_PlayerMovement = new PlayerMovement();
            m_CombatSystem = new CombatSystem();
            m_LootSystem = new LootSystem();
        }

        // Called every interval set by LoopDelay
        public override void Update()
        {
            // Capture screenshot
            CaptureFrame();

            // Release buttons
            ReleaseQueue();

            // Detect health
            HealthPercent = m_PlayerStatus.DetectHealth(this);
            MainForm.SetHealth(HealthPercent);

            // Detect spirit
            SpiritPercent = m_PlayerStatus.DetectSpirit(this);
            MainForm.SetSpirit(SpiritPercent);

            // Detect rotation
            PlayerRotation = m_PlayerMovement.DetectRotation(this);

            // Walk direction
            var walkInfo = m_PlayerMovement.FindWalkDirection(this);
            WalkDirection = walkInfo.Key;
            WalkDistance = walkInfo.Value;

            // TODO: Need refactoring and check
            //System.Diagnostics.Debug.WriteLine(" - - DIRECTION: {0}, Point: {1}", WalkDirection, Helper.DegreesToPoint(1.0f, WalkDirection));
            var playerAxis = Helper.DegreesToPoint(1.0f, WalkDirection - 90);
            playerAxis.Y *= -1;
            MainForm.SetPlayerAxis(playerAxis);

            // Detect loots
            var eternitySplinters = m_LootSystem.DetectEternitySplinters(this);
            System.Diagnostics.Debug.WriteLine("ETERNITY SPLINTER: {0} - ", eternitySplinters.Length);

            //if (eternitySplinters.Length > 0)
            //    PressQueue(new DualShockState() {Triangle = true}, "Triangle");

            // Combat system
            m_CombatSystem.Update(this);
        }

        public override void OnStopped()
        {
            ReleaseQueueState.Clear();
            ClearButtons();
        }

        public override void OnPaused()
        {
            ReleaseQueueState.Clear();
            ClearButtons();
        }

        public DualShockState CurrentQueueState { get; set; }
        public List<KeyValuePair<string[], DateTime>> ReleaseQueueState { get; set; }
        public void PressQueue(DualShockState state, string[] properties, int delay = 150)
        {
            if (properties == null)
                return;

            if (!Host.IsRunning || Host.IsPaused)
                return;

            CurrentQueueState.PatchState(state);
            ReleaseQueueState.Add(new KeyValuePair<string[], DateTime>(properties, DateTime.Now.AddMilliseconds(delay)));
            FlushQueue();
        }

        public void PressQueue(DualShockState state, string property, int delay = 150)
        {
            PressQueue(state, new string[] { property }, delay);
        }

        private void ReleaseQueue()
        {
            DateTime now = DateTime.Now;
            bool didChange = false;

            // Check the queue for releasing buttons
            foreach(var r in ReleaseQueueState)
            {
                if (now >= r.Value)
                {
                    CurrentQueueState.Release(r.Key);
                    didChange = true;
                }
            }

            // Flush queue if did change
            if (didChange)
            {
                FlushQueue();
            }
        }

        private void FlushQueue()
        {
            SetButtons(CurrentQueueState);
        }
    }
}
