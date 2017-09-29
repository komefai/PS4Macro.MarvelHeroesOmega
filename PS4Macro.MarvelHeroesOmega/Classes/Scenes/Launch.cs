using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PS4MacroAPI;

namespace PS4Macro.MarvelHeroesOmega.Scenes
{
    public class Launch : Scene
    {
        public override string Name => "Launch";

        // Marvel logo and title
        public static RectMap R_Title = new RectMap()
        {
            X = 378,
            Y = 124,
            Width = 251,
            Height = 123,
            Hash = 17519885630258750
        };

        // Rating
        public static PixelMap P_Rating = new PixelMap()
        {
            X = 905,
            Y = 548,
            Color = 0xFFFFFF
        };

        public override bool Match(ScriptBase script)
        {
            return script.MatchTemplate(R_Title, 98) && script.MatchTemplate(P_Rating, 3);
        }

        public override void OnMatched(ScriptBase script)
        {
            // Press play
            script.Press(new DualShockState() { Cross = true });
            // Wait 10 seconds
            script.Sleep(10000);
        }
    }
}
