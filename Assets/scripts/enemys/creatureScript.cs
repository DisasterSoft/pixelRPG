using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureScript : MonoBehaviour
{
    public class CREATURE
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
        public AudioClip aud3;
        public string pathSprite ;
        private string pathAudio1;
        private string pathAudio2;
        private string pathAudio3;
        public string anim ;

        public CREATURE(int ahealt, int move,int admg, string name, string sortName, int db, string pathSprite, string pathAudio1,string pathAudio2, string anim , string pathAudio3)
        {
            this.name = name;
            this.sortName = sortName;
            this.db = db;
            this.ahealt = ahealt;
            healt = ahealt * db;
            this.move = move;
            this.admg = admg;
            this.dmg = admg * db;
            this.pathAudio1 = pathAudio1;
            this.pathAudio2 = pathAudio2;
            this.anim = anim;
            this.pathSprite = pathSprite;
            aud1 = Resources.Load<AudioClip>(pathAudio1);
            aud2 = Resources.Load<AudioClip>(pathAudio2);
            aud3 = Resources.Load<AudioClip>(pathAudio3);
        }

    }
   

    }

