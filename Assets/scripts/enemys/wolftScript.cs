using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class wolftScript : MonoBehaviour
{
    public AudioSource _as;
    Animator anim;
    public static bool selected = false;
    public Flowchart flowchart;
    public GameObject stats,knight,wolf1,wolf2;
    public static bool wolf1Go = false;
    public static bool wolf2Go = false;
    public static bool wolf1Live = true;
    public static bool wolf2Live = true;
    public float speed=1f;
    int lepes = 3;
    public int w1Position = 0;
    public int w2Position = 0;
    public int k1Position = 0;
    public int Rround = 0;
    public string k1String ;
    public bool attack = false;
    public string[] k1posArray = new string[2];
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("wolt1", true);

    }
   
    // Update is called once per frame
    void Update()
    {
        Rround = tileScript.round;

        if (tileScript.round == 1)
        {
           
            wolf1Go = false;
            wolf2Go = false;
            attack = false;
            k1posArray = tileScript.slot1Coord.Split(',');
            k1Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
           
        }
        if(tileScript.round==2)
        {
            
           
            stats.GetComponent<Text>().text = "";
            if (wolftScript.wolf1Live)
            {
                if (!wolf1Go)
                {
                    Debug.Log("bejött round2 " + tileScript.round);
                    wolftScript.wolf1Go = true;
                    StartCoroutine(wolf1Move());
                    
                }

            }
            else
            {
                wolf1.SetActive(false);
                tileScript.round = 3;
            }
        }
        if (tileScript.round == 3)
        {
            attack = false;
            if (wolftScript.wolf2Live)
            {

                if (wolf2Go==false)
                {
                    Debug.Log("bejött round3 " + tileScript.round);
                    wolftScript.wolf2Go = true;
                    StartCoroutine(wolf2Move());
                    
                }
            }
            else
            {
                wolf2.SetActive (false);
                tileScript.round = 1;
            }

           
        }

        if(!wolftScript.wolf1Live && !wolftScript.wolf2Live)
        {
            tileScript.win = true;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        globalVariable.addObjectToList("wolfenemy1");
        globalVariable.setPlayerCoord();
        flowchart.SendFungusMessage("wolf1");
       
    }
    private void OnMouseUp()
    {
      
        if (this.name=="enemy1")
        {
            stats.GetComponent<Text>().text = "";
            stats.GetComponent<Text>().text = stats.GetComponent<Text>().text + "\nWolf1("+ globalSlots.slot8I + ")\nHP: (1)" + globalSlots.slot8I + "\nDMG: (1) " + globalSlots.slot8I + "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tileScript.gameModel[i, j] == "w1" && tileScript.tileS[((i * 8) + j)]== "aa")
                    {
                        knightScripts.attackKnight(((i * 8) + j),"w1");
                    }
                }
            }
        }
        if (this.name=="enemy2")
        {
            stats.GetComponent<Text>().text = "";
            stats.GetComponent<Text>().text = stats.GetComponent<Text>().text + "\nWolf2(" + globalSlots.slot9I + ")\nHP: (1) " + globalSlots.slot9I + "\nDMG: (1) " + globalSlots.slot9I + "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tileScript.gameModel[i, j] == "w2" && tileScript.tileS[((i * 8) + j)] == "aa")
                    {
                        knightScripts.attackKnight(((i * 8) + j), "w2");
                    }
                }
            }
        }
    }
    IEnumerator wolf1Move()
    {
        yield return new WaitForSeconds(1);
        wolf1Go = true;
       
            k1posArray = tileScript.slot8Coord.Split(',');
            w1Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
            k1posArray = tileScript.slot1Coord.Split(',');
            k1Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
       
        for (int i = 0; i < (lepes + 1); i++)
            {//megnézzük a közelben van e valaki.
                for (int j = 0; j < (lepes - i); j++)
                {
                
                if (((w1Position + j) + (i * 8)) == k1Position)
                    {
                   
                        attack = true;
                        break;
                    }
                    else if (((w1Position + j) - (i * 8)) == k1Position)
                    {
                   
                    attack = true;
                        break;
                    }
                    else if (((w1Position - j) + (i * 8)) == k1Position)
                    {
                   
                    attack = true;
                        break;
                    }
                    else if (((w1Position - j) - (i * 8)) == k1Position)
                    {
                   
                    attack = true;
                        break;
                    }
                    else
                    {
                        attack = false;
                    }

                }
            if (attack)
                break;
            }
            if (attack && wolf1Go)
            {
            //Támadás
            k1posArray = tileScript.slot8Coord.Split(',');
            w2Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
            int dmg = Random.Range(1, (1 * globalSlots.slot8I));
            int alive = 0;
            _as.Play();
            if (((globalSlots.slot1I)*3)>dmg)
            {
                //ha a hpj -dmg ben maradékos osztással pont 0 tehát pont kerek számút öltek meg
                if (((globalSlots.slot1I * 3) - dmg) % 3 == 0)
                {
                    alive = ((globalSlots.slot1I * 3) - dmg) / 3;
                }
                else
                {
                    alive = (((globalSlots.slot1I * 3) - dmg) / 3) + 1;
                }
                stats.GetComponent<Text>().text = stats.GetComponent<Text>().text + "\nwolf1 Attack you and do " + (dmg) + " dmg\n and " + (globalSlots.slot1I - alive) + " die";
                globalSlots.slot1I = alive;
            }
            else
            {
                stats.GetComponent<Text>().text = "\nWolf1 attack you and do " + dmg + " dmg  \n and kill all of them";
                tileScript.lose = true;
            }
        
        attack = false;
            tileScript.round = 3;
             }
            else if(!attack && wolf1Go)
            {
            //mozgás
            
            string coorda = Mathf.Round(Random.Range(1f, lepes)).ToString();
            string coordb = Mathf.Round(Random.Range(1f, (lepes-int.Parse(coorda)))).ToString();
            k1posArray = tileScript.slot9Coord.Split(',');
            w2Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
            int newW1Position = (int.Parse(coorda) * 8) + (int.Parse(coordb));
            while (newW1Position == w2Position || newW1Position==k1Position)//nem e a másikra akar rámászni
            {
                coorda = Mathf.Round(Random.Range(1f, lepes)).ToString();
                coordb = Mathf.Round(Random.Range(1f, lepes)).ToString();
                newW1Position = (int.Parse(coorda) * 8) + (int.Parse(coordb));
            }
            k1posArray = tileScript.slot8Coord.Split(',');
            tileScript.slot8Coord = coorda + "," + coordb;
            //elindulunk valamerre
            stats.GetComponent<Text>().text = stats.GetComponent<Text>().text + "\nWolf1 moved to " + coorda + "," + coordb;
            wolf1.transform.position=tileScript.tiles[newW1Position].transform.position-new Vector3(0,0,0.34f);
            //ha oda értünk
            Debug.Log(tileScript.tiles[newW1Position].name + "tiles");
            tileScript.tileS[w1Position] = "0";
            tileScript.gameModel[int.Parse(k1posArray[0]), int.Parse(k1posArray[1])] = "0";
            k1posArray = tileScript.slot8Coord.Split(',');
            tileScript.gameModel[int.Parse(k1posArray[0]), int.Parse(k1posArray[1])] = "w1";
            tileScript.tileS[newW1Position] = "3";
            tileScript.round = 3;
           
        }
        
    }
    IEnumerator wolf2Move()
    {
        yield return new WaitForSeconds(1f);
        wolf2Go = true;
        k1posArray = tileScript.slot9Coord.Split(',');
        w2Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
        k1posArray = tileScript.slot1Coord.Split(',');
        int k1Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
        for (int i = 0; i < (lepes + 1); i++)
        {//megnézzük a közelben van e valaki.
            for (int j = 0; j < (lepes - i); j++)
            {
                if (((w2Position + j) + (i * 8)) == k1Position)
                {
                    
                    attack = true;
                    break;
                }
                else if (((w2Position + j) - (i * 8)) == k1Position)
                {
                   
                    attack = true;
                    break;
                }
                else if (((w2Position - j) + (i * 8)) == k1Position)
                {
                   
                    attack = true;
                    break;
                }
                else if (((w2Position - j) - (i * 8)) == k1Position)
                {
                  
                    attack = true;
                    break;
                }
                else
                {
                    attack = false;
                } 
            }
            if (attack)
                break;
        }
        if (attack && wolf2Go)
        {
            _as.Play();
            //Támadás
            k1posArray = tileScript.slot9Coord.Split(',');
            w2Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
            int dmg = Random.Range(1, (1 * globalSlots.slot9I));
            int alive = 0;
            
            if (((globalSlots.slot1I) * 3) > dmg)
            {
                //ha a hpj -dmg ben maradékos osztással pont 0 tehát pont kerek számút öltek meg
                if (((globalSlots.slot1I * 3) - dmg) % 3 == 0)
                {
                    alive = ((globalSlots.slot1I * 3) - dmg) / 3;
                }
                else
                {
                    alive = (((globalSlots.slot1I * 3) - dmg) / 3) + 1;
                }
                stats.GetComponent<Text>().text = stats.GetComponent<Text>().text + "\nwolf2 Attack you and do " + (dmg) + " dmg\n and " + (globalSlots.slot1I - alive) + " die";
                globalSlots.slot1I = alive;
            }
            else
            {
                stats.GetComponent<Text>().text = "\nWolf2 attack you and do " + dmg + " dmg  \n and kill all of them";
                tileScript.lose = true;
            }
            tileScript.round = 1;
            attack = false;
        }
        else if (!attack && wolf2Go)
        {
            //mozgás

            string coorda = Mathf.Round(Random.Range(1f, lepes)).ToString();
            string coordb = Mathf.Round(Random.Range(1f, (lepes - int.Parse(coorda)))).ToString();
            k1posArray = tileScript.slot8Coord.Split(',');
            w1Position = (int.Parse(k1posArray[0]) * 8) + int.Parse(k1posArray[1]);
            
            int newW2Position = (int.Parse(coorda) * 8) + (int.Parse(coordb));
            while(newW2Position == w1Position || newW2Position == k1Position)//nem e a másikra akar rámászni
            {
                coorda = Mathf.Round(Random.Range(1f, lepes)).ToString();
                coordb = Mathf.Round(Random.Range(1f, lepes)).ToString();
                newW2Position = (int.Parse(coorda) * 8) + (int.Parse(coordb));
            }
            k1posArray = tileScript.slot9Coord.Split(',');
            tileScript.slot9Coord = coorda + "," + coordb;
            //elindulunk valamerre
            stats.GetComponent<Text>().text = stats.GetComponent<Text>().text + "\nWolf2 moved to " + coorda + "," + coordb;
            
            wolf2.transform.position = tileScript.tiles[newW2Position].transform.position - new Vector3(0, 0, 0.34f);
            //ha oda értünk
            tileScript.tileS[w2Position] = "0";
            tileScript.gameModel[int.Parse(k1posArray[0]), int.Parse(k1posArray[1])] = "0";
            k1posArray = tileScript.slot9Coord.Split(',');
            tileScript.gameModel[int.Parse(k1posArray[0]), int.Parse(k1posArray[1])] = "w2";
            tileScript.tileS[newW2Position] = "4";
            tileScript.round = 1;
        }
    }

    }
