namespace RandomNPC
{
    public class RNPC
    {
        public string nameID;
        public string npcString;
        public string birthday;
        public string startLoc;
        public string name;
        public string skinColour;
        public string hairStyle;
        public string hairColour;
        public string eyeColour;
        public int npcID;
        public string age;
        public string manner;
        public string anxiety;
        public string optimism;
        public string gender;
        public string datable;
        public string[] traits;
        public string[] giftTaste;
        public string bodyType;
        public bool visiting;
        public string[] clothes = null;
        public string[] topRandomColour = null;
        public RNPCSchedule schedule;
        public bool inTown = false;
        public int questItem;

        public RNPC(string npcString, int npcID)
        {
            this.npcString = npcString;
            var npca = npcString.Split('/');
            var i = 0;
            age = npca[i++];
            manner = npca[i++];
            anxiety = npca[i++];
            optimism = npca[i++];
            gender = npca[i++];
            datable = npca[i++];
            traits = npca[i++].Split('|');
            birthday = npca[i++];
            name = npca[i++];
            giftTaste = npca[i++].Split('^');
            bodyType = npca[i++];
            skinColour = npca[i++];
            hairStyle = npca[i++];
            hairColour = npca[i++];
            // ReSharper disable once RedundantAssignment
            eyeColour = npca[i++];

            this.npcID = npcID;
            nameID = $"RNPC{npcID}_{name}";
            startLoc = "BusStop 10000 10000";

        }

        internal string MakeDisposition(int idx)
        {
            if(idx < ModEntry.Config.RNPCMaxVisitors)
            {
                startLoc = "BusStop " + (13 + (idx % 6)) + " " + (11 + idx / 6);
                visiting = true;
            }
            else
            {
                startLoc = "BusStop 10000 10000";
                visiting = false;
            }
            return age + "/" + manner + "/" + anxiety + "/" + optimism + "/" + gender + "/" + datable + "//Other/" + birthday + "//" +startLoc+ "/" + name;
        }
    }
}