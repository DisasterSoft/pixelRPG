using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Fungus;
public class knightScripts1 : MonoBehaviour
{
    public class knight1
    {
        public int healt;
        public int ahealt;
        public int move;
        public int dmg;
        public int admg;
        public string name;
        public int db;
        public AudioClip aud1;
        public AudioClip aud2;
        public AudioClip aud3;
        public string pathSprite = "Sprites/Knight1Sheet";
        private string pathAudio1 = "audio/On_My_Way_Knight1";
        private string pathAudio2 = "audio/Death_Knight1";
        private string pathAudio3 = "audio/YesKnight1";
        public string anim = "Animations/knight1";
        public knight1(int darab)
        {
            name = "Knight";
            db = darab;
            healt = 3 * darab;
            ahealt = 3;
            move = 3;
            dmg = 4 * darab;
            admg = 4;
            aud1 = Resources.Load<AudioClip>(pathAudio1);
            aud2 = Resources.Load<AudioClip>(pathAudio2);
            aud3 = Resources.Load<AudioClip>(pathAudio3);
        }
        
    }
   


}

