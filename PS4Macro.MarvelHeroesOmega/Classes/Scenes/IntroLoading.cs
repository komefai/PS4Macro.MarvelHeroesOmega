﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PS4MacroAPI;

namespace PS4Macro.MarvelHeroesOmega.Scenes
{
    public class IntroLoading : Scene
    {
        public override string Name => "Intro Loading";

        // Marvel logo and title
        public static RectMap R_Title = new RectMap()
        {
            X = 0,
            Y = 98,
            Width = 867,
            Height = 449,
            Hash = 33114705313566
        };

        public override bool Match(ScriptBase script)
        {
            return script.MatchTemplate(R_Title, 99);
        }

        public override void OnMatched(ScriptBase script)
        {
            // Prevent infinite loop
            while (!script.Host.Worker.CancellationPending)
            {
                // Scene has changed
                if (!Match(script))
                    break;

                // Wait 1 second
                script.Sleep(1000);

                // Take screenshot
                script.CaptureFrame();
            }

            // Take screenshot
            script.CaptureFrame();

            // Wait 5 seconds
            script.Sleep(5000);
        }
    }
}
