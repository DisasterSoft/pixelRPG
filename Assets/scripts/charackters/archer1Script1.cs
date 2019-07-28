using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class archer1Script1 : MonoBehaviour
{
    public Flowchart flowchart;
    public class archer1
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
        public string pathSprite = "Sprites/amazonArcher";
        private string pathAudio1 = "audio/archersound1_OK";
        private string pathAudio2 = "audio/archersound1_DIE";
        private string pathAudio3 = "audio/archersound1_KATT";
        public string anim = "Animations/archer1";
        public archer1(int darab)
        {
            name = "Amazon Archer";
            db = darab;
            healt = 2 * darab;
            ahealt = 2;
            move = 3;
            dmg = 7 * darab;
            admg = 7;
            aud1 = Resources.Load<AudioClip>(pathAudio1);
            aud2 = Resources.Load<AudioClip>(pathAudio2);
            aud3 = Resources.Load<AudioClip>(pathAudio3);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        flowchart.SendFungusMessage("Archer1");
       
    }
    
    public void checkMoney(int amount)
    {
        if ((globalMoney.moneyI - amount) > -1)
        {
            globalMoney.giveMoney1(amount);
            flowchart.SetBooleanVariable("Archerpayed",true);
            globalVariable.addObjectToList("archer1");
           globalSlots.setSlot2(30);
            globalSlots.setSlot2Type("ar");
        }
        else
        {
            flowchart.SendFungusMessage("noMoney");
        }
    }
}
