// PS4Macro.MarvelHeroesOmega (File: Classes/ExtensionMethods.cs)
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
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PS4Macro.MarvelHeroesOmega
{
    public static class ExtensionMethods
    {
        #region int
        public static Color ToColor(this int argb)
        {
            return Color.FromArgb((byte)((argb & -16777216) >> 0x18),
                                  (byte)((argb & 0xff0000) >> 0x10),
                                  (byte)((argb & 0xff00) >> 8),
                                  (byte)(argb & 0xff));
        }

        public static Color ToColorOpaque(this int argb)
        {
            return Color.FromArgb((byte)255,
                                  (byte)((argb & 0xff0000) >> 0x10),
                                  (byte)((argb & 0xff00) >> 8),
                                  (byte)(argb & 0xff));
        }
        #endregion

        #region ProgressBar
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
        #endregion

        #region DualShockState
        private static DualShockState defaultState = new DualShockState();

        public static void PatchState(this DualShockState state, DualShockState withState)
        {
            if (withState.LX != defaultState.LX) state.LX = withState.LX;
            if (withState.LY != defaultState.LY) state.LY = withState.LY;
            if (withState.RX != defaultState.RX) state.RX = withState.RX;
            if (withState.RY != defaultState.RY) state.RY = withState.RY;
            if (withState.L2 != defaultState.L2) state.L2 = withState.L2;
            if (withState.R2 != defaultState.R2) state.R2 = withState.R2;
            if (withState.Triangle != defaultState.Triangle) state.Triangle = withState.Triangle;
            if (withState.Circle != defaultState.Circle) state.Circle = withState.Circle;
            if (withState.Cross != defaultState.Cross) state.Cross = withState.Cross;
            if (withState.Square != defaultState.Square) state.Square = withState.Square;
            if (withState.DPad_Up != defaultState.DPad_Up) state.DPad_Up = withState.DPad_Up;
            if (withState.DPad_Down != defaultState.DPad_Down) state.DPad_Down = withState.DPad_Down;
            if (withState.DPad_Left != defaultState.DPad_Left) state.DPad_Left = withState.DPad_Left;
            if (withState.DPad_Right != defaultState.DPad_Right) state.DPad_Right = withState.DPad_Right;
            if (withState.L1 != defaultState.L1) state.L1 = withState.L1;
            if (withState.R3 != defaultState.R3) state.R3 = withState.R3;
            if (withState.Share != defaultState.Share) state.Share = withState.Share;
            if (withState.Options != defaultState.Options) state.Options = withState.Options;
            if (withState.R1 != defaultState.R1) state.R1 = withState.R1;
            if (withState.L3 != defaultState.L3) state.L3 = withState.L3;
            if (withState.PS != defaultState.PS) state.PS = withState.PS;
            if (withState.TouchButton != defaultState.TouchButton) state.TouchButton = withState.TouchButton;
        }

        public static void Release(this DualShockState state, string[] properties)
        {
            foreach (var p in properties)
            {
                state.SetProperty(p, defaultState.GetProperty(p));
            }
        }

        private static object GetProperty(this DualShockState state, string property)
        {
            return state.GetType().InvokeMember(property,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty,
                Type.DefaultBinder, state, null);
        }

        private static void SetProperty(this DualShockState state, string property, object value)
        {
            state.GetType().InvokeMember(property,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                Type.DefaultBinder, state, new object[] { value });
        }
        #endregion
    }
}
