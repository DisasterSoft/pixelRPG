using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redImp : MonoBehaviour
{
   public class RIMP 
    {
        public int healt;
        public int ahealt;
        public int move;
        public int dmg;
        public int admg;
        public string name;
        public string sortName;
        public int db;
        public AudioClip aud1;
        public AudioClip aud2;
        public string pathSprite = "Sprites/walk-vanilla_RIMP";
        private string pathAudio1 = "audio/mob3";
        private string pathAudio2 = "audio/mob3die";
        public string anim= "Animations/redImpAnim";

        public RIMP(int darab)
        {
            name = "Red Imp";
            sortName = "RImp";
            db = darab;
            healt = 5*darab;
            ahealt = 5;
            move = 5;
            dmg = 4*darab;
            admg = 4;
            aud1 = Resources.Load<AudioClip>(pathAudio1);
            aud2 = Resources.Load<AudioClip>(pathAudio2);
        }

    }
}
