using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public class Zombie
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
        public string pathSprite = "Sprites/zombie";
        private string pathAudio1 = "audio/mob2";
        private string pathAudio2 = "audio/mob2die";
        public string anim = "Animations/zombie1";

        public Zombie(int darab)
        {
            name = "Zombie";
            sortName = "z1";
            db = darab;
            healt = 2 * darab;
            ahealt = 2;
            move = 3;
            dmg = 6 * darab;
            admg = 6;
            aud1 = Resources.Load<AudioClip>(pathAudio1);
            aud2 = Resources.Load<AudioClip>(pathAudio2);
        }

    }
}
