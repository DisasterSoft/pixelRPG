using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Fungus;
public class assasinScript1 : MonoBehaviour
{
    public class assasin1
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
        public string pathSprite = "Sprites/assasin1";
        private string pathAudio1 = "audio/archersound1_OK";
        private string pathAudio2 = "audio/archersound1_DIE";
        private string pathAudio3 = "audio/archersound1_KATT";
        public string anim = "Animations/assasin";
        public assasin1(int darab)
        {
            name = "Assasin";
            db = darab;
            healt = 2 * darab;
            ahealt = 2;
            move = 6;
            dmg = 3 * darab;
            admg = 3;
            aud1 = Resources.Load<AudioClip>(pathAudio1);
            aud2 = Resources.Load<AudioClip>(pathAudio2);
            aud3 = Resources.Load<AudioClip>(pathAudio3);
        }
        
    }
   


}

