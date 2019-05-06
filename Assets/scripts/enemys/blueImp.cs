using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueImp : MonoBehaviour
{
   public class BIMP 
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
        public string pathSprite = "Sprites/walk_vanilla_BIMP";
        private string pathAudio1 = "audio/mob2";
        private string pathAudio2 = "audio/mob2die";
        public string anim= "Animations/blueImpAnim";

        public BIMP(int darab)
        {
            name = "Blue Imp";
            sortName = "BImp";
            db = darab;
            healt = 4*darab;
            ahealt = 4;
            move = 4;
            dmg = 3*darab;
            admg = 3;
            aud1 = Resources.Load<AudioClip>(pathAudio1);
            aud2 = Resources.Load<AudioClip>(pathAudio2);
        }

    }
}
