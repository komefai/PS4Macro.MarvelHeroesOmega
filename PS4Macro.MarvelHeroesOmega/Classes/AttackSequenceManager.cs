// PS4Macro.MarvelHeroesOmega (File: Classes/AttackSequenceManager.cs)
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
using System.Linq;
using System.Text;
using PS4MacroAPI;

namespace PS4Macro.MarvelHeroesOmega
{
    public class ButtonsToState
    {
        public string[] Properties { get; set; }
        public DualShockState State { get; set; }

        public ButtonsToState()
        {

        }

        public ButtonsToState(string[] properties, DualShockState state)
        {
            Properties = properties;
            State = state;
        }
    }

    public class ButtonsWrapper
    {
        public string Name { get; set; }

        public ButtonsWrapper()
        {
            
        }

        public ButtonsWrapper(string name)
        {
            Name = name;
        }
    }

    public class AttackSequenceManager
    {
        #region Singleton
        private static AttackSequenceManager instance;
        public static AttackSequenceManager Instance => instance ?? (instance = new AttackSequenceManager());
        #endregion

        public Dictionary<string, ButtonsToState> ButtonsDictionary { get; private set; }
        public int CurrentIndex { get; set; }
        public DateTime LastButtonTime { get; set; }


        private AttackSequenceManager()
        {
            ButtonsDictionary = new Dictionary<string, ButtonsToState>()
            {
                { "Triangle",  new ButtonsToState(new [] { "Triangle" }, new DualShockState() { Triangle = true }) },
                { "Circle",  new ButtonsToState(new [] { "Circle" }, new DualShockState() { Circle = true }) },
                { "Cross",  new ButtonsToState(new [] { "Cross" }, new DualShockState() { Cross = true }) },
                { "Square",  new ButtonsToState(new [] { "Square" }, new DualShockState() { Square = true }) },
                { "L2 + Triangle",  new ButtonsToState(new [] { "L2", "Triangle" }, new DualShockState() { L2 = 255, Triangle = true }) },
                { "L2 + Circle",  new ButtonsToState(new [] { "L2", "Circle" }, new DualShockState() { L2 = 255, Circle = true }) },
                { "L2 + Cross",  new ButtonsToState(new [] { "L2", "Cross" }, new DualShockState() { L2 = 255, Cross = true }) },
                { "L2 + Square",  new ButtonsToState(new [] { "L2", "Square" }, new DualShockState() { L2 = 255, Square = true }) },
            };

            Reset();
        }

        public void Reset()
        {
            CurrentIndex = -1;
            LastButtonTime = DateTime.MinValue;
        }

        public ButtonsToState GetNextState()
        {
            if (Settings.Instance.Data.AttackSequence == null)
                return null;

            if (Settings.Instance.Data.AttackSequence.Count <= 0)
                return null;

            if ((DateTime.Now - LastButtonTime).TotalMilliseconds < Settings.Instance.Data.AttackSequenceDelay)
                return null;

            // Update index
            if (CurrentIndex >= Settings.Instance.Data.AttackSequence.Count - 1 || CurrentIndex < 0)
                CurrentIndex = 0;
            else
                CurrentIndex++;

            // Store time
            LastButtonTime = DateTime.Now;

            return ButtonsDictionary[Settings.Instance.Data.AttackSequence[CurrentIndex].Name];
        }
    }
}
