using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNPC
{
    internal class RNPCDialogue
    {
        public string gender;
        public string situation;
        public string mood;
        public string friendship;
        public string personality;
        public string age;
        public string manners;
        public string anxiety;
        public string optimism;

        public RNPCDialogue(string dialogueString)
        {
            string[] dialogueArray = dialogueString.Split('/');
            age = dialogueArray[0];
            manners = dialogueArray[1];
            anxiety = dialogueArray[2];
            optimism = dialogueArray[3];
            gender = dialogueArray[4];
            mood = dialogueArray[5];
            friendship = dialogueArray[5];
        }

    }
}