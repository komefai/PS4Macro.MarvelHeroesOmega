// PS4Macro.MarvelHeroesOmega (File: Classes/Settings.cs)
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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PS4Macro.MarvelHeroesOmega
{
    public class SettingsData
    {
        public int HealPercent { get; set; }
        public int DashControlIndex { get; set; }
        public List<ButtonsWrapper> AttackSequence { get; private set; }
        public int AttackSequenceDelay { get; set; }
        public List<ObjectiveItem> ObjectiveList { get; private set; }

        public SettingsData()
        {
            Init();
        }

        public void Init()
        {
            HealPercent = 90;
            DashControlIndex = 1;
            AttackSequence = new List<ButtonsWrapper>() { /*new ButtonsWrapper("Cross")*/ };
            AttackSequenceDelay = 500;
            ObjectiveList = new List<ObjectiveItem>() { /*new ObjectiveItem() { Objective = ObjectiveManager.KEY_FIGHT_WAVE, Parameters = null }*/ };
        }

        public static void Serialize(string path, SettingsData data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsData));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, data);
            }
        }

        public static SettingsData Deserialize(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(SettingsData));
            using (TextReader reader = new StreamReader(path))
            {
                object obj = deserializer.Deserialize(reader);
                SettingsData data = obj as SettingsData;
                return data;
            }
        }
    }

    public class Settings
    {
        #region Singleton
        private static Settings instance;
        public static Settings Instance => instance ?? (instance = new Settings());
        #endregion


        public SettingsData Data { get; set; }

        private Settings()
        {
            Data = new SettingsData();
        }

        public void InitData()
        {
            if (Data == null) return;
            Data.Init();
        }

        public void Load(string path)
        {
            Data = SettingsData.Deserialize(path);
        }

        public void Save(string path)
        {
            SettingsData.Serialize(path, Data);
        }
    }
}
