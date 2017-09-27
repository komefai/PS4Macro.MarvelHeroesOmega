// PS4Macro.MarvelHeroesOmega (File: Classes/Workaround.cs)
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
using PS4MacroAPI.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace PS4Macro.MarvelHeroesOmega
{
    public class Workaround
    {
        #region PressScriptButtonOnHost
        private const uint WM_LBUTTONDOWN = 0x0201;
        private const int WM_COMMAND = 0x0111;
        private const int BN_CLICKED = 0;

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void GetWindowText(IntPtr handle, StringBuilder resultWindowText, int maxTextCapacity);
        public delegate bool EnumChildCallback(IntPtr hwnd, ref IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hwnd, EnumChildCallback Proc, int lParam);

        private static void ClickButton(IntPtr handle, IntPtr hWndButton, int buttonId)
        {
            int wParam = (BN_CLICKED << 16) | (buttonId & 0xffff);
            SendMessage(handle, WM_COMMAND, wParam, hWndButton);
        }

        public static void PressScriptButtonOnHost()
        {
            Process p = ScriptUtility.FindProcess();
            if (p == null) return;

            EnumChildWindows(p.MainWindowHandle, (IntPtr hwndChild, ref IntPtr lParam) =>
            {
                var sb = new StringBuilder(50);
                GetWindowText(hwndChild, sb, 50);

                var str = sb.ToString();
                if (!string.IsNullOrWhiteSpace(str) && str == "Script")
                {
                    ClickButton(p.MainWindowHandle, hwndChild, hwndChild.ToInt32());
                    return false;
                }

                return true;
            }, 0);
        }
        #endregion
    }
}
