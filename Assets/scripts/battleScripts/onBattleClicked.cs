using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onBattleClicked : MonoBehaviour
{
    public bool attack = false;
   // public bool notInfo = false;//ez azért kell hogy mikor rákattintunk a lényre ne váltogassa a köröket
    private void OnMouseUp()
    {

        if (this.name == "Knight")
        {
                GameObject.Find("Knight").GetComponent<AudioSource>().enabled = false;
                GameObject.Find("Knight").GetComponent<AudioSource>().clip = battleScript.leny[0].aud3;
                GameObject.Find("Knight").GetComponent<AudioSource>().enabled = true;
                GameObject.Find("youStat").GetComponent<Text>().text =
                battleScript.leny[0].name + "(" + globalSlots.slot1I + ")\n HP: " + battleScript.leny[0].ahealt + " (" + battleScript.leny[0].ahealt* globalSlots.slot1I + ")\n" + "DMG: " + battleScript.leny[0].admg + " (" + battleScript.leny[0].admg * globalSlots.slot1I + ")";

                if (battleScript.round == 1)
                {
                    getLepes(globalSlots.slot1T,battleScript.leny[0].move);
                    battleScript.painted = false;
                    globalSlots.oneSelected = true;
                    battleScript.notInfo = true;
                }
            
        }
        if (this.name=="Archer")
        {
           
                GameObject.Find("Archer").GetComponent<AudioSource>().enabled=false;
                GameObject.Find("Archer").GetComponent<AudioSource>().clip = battleScript.leny[1].aud3;
                GameObject.Find("Archer").GetComponent<AudioSource>().enabled = true;
                GameObject.Find("youStat").GetComponent<Text>().text=
               battleScript.leny[1].name+"("+globalSlots.slot2I+")\n HP: "+ battleScript.leny[1].ahealt+" ("+ battleScript.leny[1].ahealt* globalSlots.slot2I + ")\n"+"DMG: "+ battleScript.leny[1].admg+" ("+ battleScript.leny[1].admg* globalSlots.slot2I + ")";
                if (battleScript.round == 2)
                {
                    getLepes(globalSlots.slot2T, battleScript.leny[1].move);
                    battleScript.painted = false;
                    globalSlots.twoSelected = true;
                    battleScript.notInfo = true;
                }
        }
        if (this.name=="enemy1")
        {
            
                GameObject.Find("enemyStat").GetComponent<Text>().text=
                battleScript.leny[6].name+"("+globalSlots.slot7I+")\n HP: "+ battleScript.leny[6].ahealt+" ("+ battleScript.leny[6].ahealt * battleScript.leny[6].db + ")\n"+"DMG: "+ battleScript.leny[6].admg+" ("+ battleScript.leny[6].admg * battleScript.leny[6].db + ")";
                if (battleScript.notInfo)
                {
                    attackLeny(battleScript.leny[6].name, battleScript.leny[6].ahealt, globalSlots.slot7I, "8");
                }
            
        }
        if (this.name=="enemy2")
        {
           
                
                GameObject.Find("enemyStat").GetComponent<Text>().text=
                battleScript.leny[7].name+"("+globalSlots.slot8I+")\n HP: "+ battleScript.leny[7].ahealt+" ("+ battleScript.leny[7].ahealt* battleScript.leny[7].db + ")\n"+"DMG: "+ battleScript.leny[7].admg+" ("+ battleScript.leny[7].admg * battleScript.leny[7].db + ")";
                if (battleScript.notInfo)
                {
                    attackLeny(battleScript.leny[7].name, battleScript.leny[7].ahealt, globalSlots.slot8I, "9");
                }
            
        }
        if (this.name=="enemy3")
        {
           
                GameObject.Find("enemyStat").GetComponent<Text>().text=
                battleScript.leny[8].name+"("+globalSlots.slot9I+")\n HP: "+ battleScript.leny[8].ahealt+" ("+ battleScript.leny[8].ahealt * battleScript.leny[8].db + ")\n"+"DMG: "+ battleScript.leny[8].admg+" ("+ battleScript.leny[8].admg* battleScript.leny[8].db + ")";
                if (battleScript.notInfo)
                {
                    attackLeny(battleScript.leny[8].name, battleScript.leny[8].ahealt, globalSlots.slot9I, "10");
                }
            
        }
    }
    public void getLepes(string mit, int move)
    {
        int oszlop = 0;
        int sor = 0;
        if (mit == "k")
        {
            oszlop = globalSlots.slot1y;
            sor = globalSlots.slot1x;
        }
        if (mit == "ar")
        {
            oszlop = globalSlots.slot2y;
            sor = globalSlots.slot2x;
            for (int i = 0; i < 64; i++)
            {
                if (int.Parse(battleScript.tileS[i]) > 7)
                {
                    battleScript.tileSLocal[i] = "20";
                }
            }
        }

        for (int a = 0; a < (move + 1); a++)
        {
            for (int b = 0; b < (move - a); b++)
            {
                if (((oszlop + b) < 8) && ((sor + a) < 8))
                {

                    if (battleScript.tileS[(sor + a) + ((oszlop + b) * 8)] == "0")
                    {
                        battleScript.tileS[(sor + a) + ((oszlop + b) * 8)] = "1";
                    }
                    if (int.Parse(battleScript.tileS[(sor + a) + ((oszlop + b) * 8)]) > 7 && int.Parse(battleScript.tileS[(sor + a) + ((oszlop + b) * 8)]) < 20)
                    {

                        battleScript.tileSLocal[(sor + a) + ((oszlop + b) * 8)] = "20";
                    }

                }
                if (((oszlop + b) < 8) && ((sor - a) > -1))
                {

                    if (battleScript.tileS[(sor - a) + ((oszlop + b) * 8)] == "0")
                    {
                        battleScript.tileS[(sor - a) + ((oszlop + b) * 8)] = "1";
                    }
                    if (int.Parse(battleScript.tileS[(sor - a) + ((oszlop + b) * 8)]) > 7 && int.Parse(battleScript.tileS[(sor - a) + ((oszlop + b) * 8)]) < 20)
                    {

                        battleScript.tileSLocal[(sor - a) + ((oszlop + b) * 8)] = "20";
                    }
                }
                if (((oszlop - b) > -1) && ((sor + a) < 8))
                {

                    if (battleScript.tileS[(sor + a) + ((oszlop - b) * 8)] == "0")
                    {
                        battleScript.tileS[(sor + a) + ((oszlop - b) * 8)] = "1";
                    }
                    if (int.Parse(battleScript.tileS[(sor + a) + ((oszlop - b) * 8)]) > 7 && int.Parse(battleScript.tileS[(sor + a) + ((oszlop - b) * 8)]) < 20)
                    {

                        battleScript.tileSLocal[(sor + a) + ((oszlop - b) * 8)] = "20";
                    }
                }
                if (((oszlop - b) > -1) && ((sor - a) > -1))
                {

                    if (battleScript.tileS[(sor - a) + ((oszlop - b) * 8)] == "0")
                    {
                        battleScript.tileS[(sor - a) + ((oszlop - b) * 8)] = "1";
                    }
                    if (int.Parse(battleScript.tileS[(sor - a) + ((oszlop - b) * 8)]) > 7 && int.Parse(battleScript.tileS[(sor - a) + ((oszlop - b) * 8)]) < 20)
                    {

                        battleScript.tileSLocal[(sor - a) + ((oszlop - b) * 8)] = "20";
                    }

                }
            }
        } 
    }
    public void attackLeny(string name, int healt, int db,string slot)
    {
        if (!attack)
        {
            attack = true;
            bool die = false ;
            battleScript.notInfo = false;
            int dmg = 0;
            int admg = 0;
            bool critical = false;
            int ahealt = healt * db;
            healt = ahealt;
            ahealt = healt / db;
            if (globalSlots.oneSelected)
            {
                    dmg = battleScript.leny[0].admg* battleScript.leny[0].db;
            }
            if (globalSlots.twoSelected)
            {
                dmg = battleScript.leny[1].admg * battleScript.leny[1].db;  
            }
            //it is critick?    
            int crit = Random.Range(1, 10);
            //calculate dmg
            if (crit % 7 == 0)
            {
                critical = true;
                admg = Random.Range(dmg, (dmg * 2));
            }
            else
            {
                admg = Random.Range(1, dmg);
            }
            //if survived
            if ((healt - admg) > 0)
            {
                int remaining = 0;
                //we calculate how many creatur survived the attack
                if (((healt - admg) % ahealt) > 0)
                {
                    remaining = ((healt - admg) / ahealt) + 1;

                }
                else
                {
                    remaining = ((healt - admg) / ahealt) + 1;
                }
                if (slot == "8")
                {
                    globalSlots.slot7I = remaining;
                    battleScript.leny[6].db = remaining;
                }
                if (slot == "9")
                {
                    globalSlots.slot8I = remaining;
                    battleScript.leny[7].db = remaining;
                }
                if (slot == "10")
                {
                    globalSlots.slot9I = remaining;
                    battleScript.leny[8].db = remaining;
                }
                if (slot == "11")
                {
                    globalSlots.slot10I = remaining;
                    battleScript.leny[9].db = remaining;
                }
                if (slot == "12")
                {
                    globalSlots.slot11I = remaining;
                    battleScript.leny[10].db = remaining;
                }
                if (slot == "13")
                {
                    globalSlots.slot12I = remaining;
                    battleScript.leny[11].db = remaining;
                }
                string critS = "";
                if (critical)
                {
                    critS = "critical";
                }
                GameObject.Find("youStat").GetComponent<Text>().text = "You make " + admg + " " + critS + " dmg to " + name + "\n and " + (db - remaining) + " died";
            }
            else
            {
                die = true;
                if (slot == "8")
                {
                    GameObject.Find("enemy1").GetComponent<Animator>().SetBool("Live", false);
                    globalSlots.slot7I = 0;
                }
                if (slot == "9")
                {
                    GameObject.Find("enemy2").GetComponent<Animator>().SetBool("Live", false);
                    globalSlots.slot8I = 0;
                }
                if (slot == "10")
                {
                    GameObject.Find("enemy3").GetComponent<Animator>().SetBool("Live", false);
                    globalSlots.slot9I = 0;
                }
                if (slot == "11")
                {
                    GameObject.Find("enemy4").SetActive(false);
                    globalSlots.slot10I = 0;
                }
                if (slot == "12")
                {
                    GameObject.Find("enemy5").SetActive(false);
                    globalSlots.slot11I = 0;
                }
                if (slot == "13")
                {
                    GameObject.Find("enemy6").SetActive(false);
                    globalSlots.slot12I = 0;
                }
                GameObject.Find("youStat").GetComponent<Text>().text = "You make " + admg + " and killed the " + name;
            }
            goThere(slot,die);
        }
        
    }
    //goThere  param string what creature near we go
    //if the crature die param die=true param where=8,9,10,11,12,13
    public void goThere(string where,bool die)
    {
        //search for creature 
        int posi = 0;
            for (int i = 0; i < 64; i++)
            {
                if (battleScript.tileS[i] == where)
                {
                    posi = i;
                    break;
                }
            }
        if (die)
        {
            StartCoroutine(dieCreature(where));
            battleScript.numberOfEnemy--;
            battleScript.tileS[posi] = "0";
            battleScript.tileSLocal[posi] = "0";
            battleScript.GameModel[posi / 8, posi % 8] = "0";
        }

        bool stop = false;
      
        //search free tile to go
        if(globalSlots.oneSelected)
        {
        
            if((posi-1)>-1 && battleScript.tileS[(posi - 1)]=="1" && !stop &&(posi/8)==((posi-1)/8))
            {
                battleScript.whereTogo = "simpleTile" + (posi - 1);
                stop = true;
            }
            if ((posi + 1) < 64 && battleScript.tileS[(posi + 1)] == "1" && !stop && (posi / 8) == ((posi + 1) / 8))
            {
                battleScript.whereTogo = "simpleTile" + (posi + 1);
                stop = true;
            }
            if ((posi - 8) > -1 && battleScript.tileS[(posi - 8)] == "1" && !stop)
            {
                battleScript.whereTogo = "simpleTile" + (posi - 8);
                stop = true;
            }
            if ((posi + 8) <64 && battleScript.tileS[(posi + 8)] == "1" && !stop)
            {
                battleScript.whereTogo = "simpleTile" + (posi + 8);
                stop = true;
            }
           
        }
        if(globalSlots.twoSelected)
        {

           for(int i=0;i<64;i++)
            {
                if(battleScript.tileS[i]=="3")
                {
                    battleScript.whereTogo = "simpleTile" + (i);
                    break;
                }
            }

        }
        battleScript.painted = false;
        battleScript.moved = true;
        attack = false;
    }
    IEnumerator dieCreature(string where) {
        yield return new WaitForSeconds(1.5f);
            if (where == "8")
        {
            GameObject.Find("enemy1").SetActive(false);
            GameObject.Find("enemy1").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("enemy1").GetComponent<AudioSource>().clip = battleScript.leny[6].aud2;
            GameObject.Find("enemy1").GetComponent<AudioSource>().enabled = true;


        }
        if (where == "9")
        {
            GameObject.Find("enemy2").SetActive(false);
            GameObject.Find("enemy2").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("enemy2").GetComponent<AudioSource>().clip = battleScript.leny[7].aud2;
            GameObject.Find("enemy2").GetComponent<AudioSource>().enabled = true;

        }
        if (where == "10")
        {
            GameObject.Find("enemy3").SetActive(false);
            GameObject.Find("enemy3").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("enemy3").GetComponent<AudioSource>().clip = battleScript.leny[8].aud2;
            GameObject.Find("enemy3").GetComponent<AudioSource>().enabled = true;
        }
    }
    
}
  

