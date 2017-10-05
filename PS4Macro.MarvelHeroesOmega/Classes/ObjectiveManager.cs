// PS4Macro.MarvelHeroesOmega (File: Classes/ObjectiveManager.cs)
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

namespace PS4Macro.MarvelHeroesOmega
{
    public class ObjectiveItem
    {
        public string Objective { get; set; }
        public string Parameters { get; set; }

        public ObjectiveItem()
        {
            
        }
    }

    public class ObjectiveManager
    {
        #region Singleton
        private static ObjectiveManager instance;
        public static ObjectiveManager Instance => instance ?? (instance = new ObjectiveManager());
        #endregion

        public const string KEY_PLAY_MACRO = "PlayMacro";
        public const string KEY_FIGHT_WAVE = "FightWave";
        public const string KEY_GOTO_INDEX = "GoToIndex";
        public const string KEY_WAIT = "Wait";

        public int CurrentIndex { get; set; }
        public bool ShouldUpdate { get; set; }

        public bool FoundEnemy { get; set; }

        private ObjectiveManager()
        {
            Reset();
        }

        private ObjectiveItem GetCurrentObjective(Script script)
        {
            return Settings.Instance.Data.ObjectiveList[CurrentIndex];
        }


        public void Reset()
        {
            CurrentIndex = -1;
            ShouldUpdate = true;
            FoundEnemy = false;
        }

        public void Update(Script script)
        {
            if (!ShouldUpdate)
                return;

            if (Settings.Instance.Data.ObjectiveList == null)
                return;

            if (Settings.Instance.Data.ObjectiveList.Count <= 0)
                return;

            // Reset update
            ShouldUpdate = false;

            // Update index
            if (CurrentIndex >= Settings.Instance.Data.ObjectiveList.Count - 1 || CurrentIndex < 0)
                CurrentIndex = 0;
            else
                CurrentIndex++;

            // Update UI
            script.MainForm.SetCurrentObjectiveIndex(CurrentIndex);

            // Get current objective
            var objective = GetCurrentObjective(script);

            // Execute objective
            switch (objective.Objective)
            {
                case KEY_PLAY_MACRO:
                {
                    var path = objective.Parameters;
                    if (!path.EndsWith(".xml")) path += ".xml";
                    script.PlayMacro(Helper.GetScriptFolder() + @"\macros\" + path);
                    break;
                }

                case KEY_FIGHT_WAVE:
                {
                    script.EnableLoop = true;
                    break;
                }

                case KEY_GOTO_INDEX:
                {
                    CurrentIndex = int.Parse(objective.Parameters) - 2;
                    ShouldUpdate = true;
                    break;
                }

                case KEY_WAIT:
                {
                    var delay = int.Parse(objective.Parameters);
                    script.Sleep(delay);
                    ShouldUpdate = true;
                    break;
                }
            }
        }
    }
}
