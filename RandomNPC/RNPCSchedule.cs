﻿using StardewValley;
using System;

namespace RandomNPC
{
    public class RNPCSchedule
    {
        public string morningLoc;
        public string afternoonLoc;
        public string morningEarliest;
        public string afternoonEarliest;
        private string mTime;
        private string aTime;
        public readonly RNPC npc;
        private int startM;

        public RNPCSchedule(RNPC npc)
        {
            this.npc = npc;
        }

        public string ID { get; internal set; }

        public string MakeString()
        {
            string str = "";
            int mH;
            int mM;
            if(morningEarliest != "any")
            {
                var mHour = int.Parse(morningEarliest.Substring(0,morningEarliest.Length == 4?2:1));
                mM = (int.Parse(morningEarliest) % 100) / 10;
                mH = Game1.random.Next(mHour, Math.Max(7, Math.Min(mHour,9)));
                mM = Game1.random.Next(mH == mHour?mM:0, 5);
            }
            else
            {
                mH = Game1.random.Next(7, 9);
                mM = Game1.random.Next(0, 5);
            }
            mTime = mH.ToString() + mM + "0";

            int aH;
            int aM;
            if(afternoonEarliest != "any" && int.Parse(afternoonEarliest) > 1200)
            {
                var aHour = (int)Math.Round(double.Parse(afternoonEarliest)/100);
                aM = int.Parse(afternoonEarliest) % 100 / 10;
                aH = Game1.random.Next(aHour, Math.Min(aHour, 16));
                aM = Game1.random.Next(aH == aHour?aM:0, 5);
            }
            else
            {
                aH = Game1.random.Next(12, 16);
                aM = Game1.random.Next(0, 5);
            }
            aTime = aH.ToString() + aM + "0";

            // create starting location to go to

            int startX = Game1.random.Next(25, 35);
            int startY = Game1.random.Next(63, 72);
            int startFace = 0;
            if(startY < 66)
            {
                startFace = 2;
            }
            else if (startY < 68)
            {
                startFace = startX < 30 ? 1 : 3;
            }

            startM = Game1.random.Next(1, 5);

            str += "6"+startM+"0 Town "+startX+" "+startY+" "+startFace+"/"+ mTime + " " + morningLoc + "/" + aTime + " " + afternoonLoc+ "/"+ModEntry.Config.LeaveTime+ " BusStop 12 9 0";
            return str;
        }
    }
}