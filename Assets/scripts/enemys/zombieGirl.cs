using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieGirl : MonoBehaviour
{
    public class ZombieGirl
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
        public string pathSprite = "Sprites/zombieGirl";
        private string pathAudio1 = "audio/mob2";
        private string pathAudio2 = "audio/mob2die";
        public string anim = "Animations/zombie2";

        public ZombieGirl(int darab)
        {
            name = "Zombie Girl";
            sortName = "z2";
            db = darab;
            healt = 3 * darab;
            ahealt = 3;
            move = 3;
            dmg = 7 * darab;
            admg = 7;
            aud1 = Resources.Load<AudioClip>(pathAudio1);
            aud2 = Resources.Load<AudioClip>(pathAudio2);
        }

    }
}
