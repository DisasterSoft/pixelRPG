using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class battleScript : MonoBehaviour
{
    public static string[,] GameModel=new string[8,8];
    public static GameObject[] TileModel=new GameObject[64];
    public  GameObject[] solders=new GameObject[6];
    public  GameObject[] enemys=new GameObject[6];
    public Material[] mat;
    public Flowchart flowchart;
    public static int round=1;
    public static int numberOfEnemy = 0;
    public static int numberOfTeam = 0;
    public bool searched=false;
    public static bool painted=false;
    public static bool moved=false;
    public static bool notInfo=false;
    public  bool caled=false;
    public  int round1=1;
    public static string whereTogo = "";
    public  string whereTogo1 = "";
    public static string[] tileS = new string[64];
    public  string[] tileSS = new string[64];
    public static string[] tileSLocal = new string[64];
    public static  creatureScript.CREATURE[] leny=new creatureScript.CREATURE[12];
    
    // Start is called before the first frame update
    void Start()
    {
        globalSlots.slot1I = 40;
        globalSlots.slot1T = "k";
        globalSlots.slot2T = "ar";
        globalSlots.slot2I = 40;

        globalSlots.slot7T = "BImp";
        globalSlots.slot9T = "BImp";
        globalSlots.slot8T = "RImp";
        globalSlots.slot7I = 40;
        globalSlots.slot9I = 35;
        globalSlots.slot8I = 20;
        for (int i = 0; i < 64; i++)
        {
            TileModel[i] = GameObject.Find("simpleTile" + i);
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameModel[i, j] = "0";
                tileS[j + (i * 8)]="0";
                tileSLocal[j + (i * 8)]="0";
                
                if (i == 0 && j == 7 && globalSlots.slot1I > 0)
                {
                    numberOfTeam++;
                    if (globalSlots.slot1T == "k")
                    {
                        leny[0] = new creatureScript.CREATURE(3, 3, 4, "Knight", "k", globalSlots.slot1I, "Sprites/Knight1Sheet", "audio/On_My_Way_Knight1", "audio/Death_Knight1", "Animations/knight1", "audio/YesKnight1");
                    }
                        solders[0].AddComponent<Animator>();
                        solders[0].AddComponent<AudioSource>();
                        solders[0].GetComponent<AudioSource>().volume = 0.15f;
                        solders[0].GetComponent<AudioSource>().enabled = false;
                      
                        RuntimeAnimatorController[] obj1 = Resources.LoadAll<RuntimeAnimatorController>(leny[0].anim);
                        solders[0].GetComponent<Animator>().runtimeAnimatorController = obj1[0];
                        Sprite[] obj = Resources.LoadAll<Sprite>(leny[0].pathSprite);
                        solders[0].GetComponent<SpriteRenderer>().sprite = obj[5];
                        solders[0].transform.position = (TileModel[j + (i * 8)].GetComponent<Renderer>().bounds.center)-new Vector3(0,0,0.1f);
                        solders[0].SetActive(true);
                        GameModel[i, j] = leny[0].sortName;
                        tileS[j + (i * 8)] = "2";
                        tileSLocal[j + (i * 8)] = "2";
                        globalSlots.slot1x = j;
                        globalSlots.slot1y = i;
                }
                if (i == 2 && j == 7 && globalSlots.slot2I > 0)
                {
                    numberOfTeam++;
                    if (globalSlots.slot2T == "ar")
                    {
                        leny[1] = new creatureScript.CREATURE(2, 2, 7, "Amazon Archer", "ar", globalSlots.slot2I, "Sprites/amazonArcher", "audio/archersound1_OK", "audio/archersound1_DIE", "Animations/archer1", "audio/archersound1_KATT");
                    }
                        solders[1].AddComponent<Animator>();
                        solders[1].AddComponent<AudioSource>();
                        solders[1].GetComponent<AudioSource>().volume = 0.15f;
                        solders[1].GetComponent<AudioSource>().enabled = false;
                        RuntimeAnimatorController[] obj1 = Resources.LoadAll<RuntimeAnimatorController>(leny[1].anim);
                        solders[1].GetComponent<Animator>().runtimeAnimatorController = obj1[0];
                        Sprite[] obj = Resources.LoadAll<Sprite>(leny[1].pathSprite);
                        solders[1].GetComponent<SpriteRenderer>().sprite = obj[5];
                        solders[1].transform.position = (TileModel[j + (i * 8)].GetComponent<Renderer>().bounds.center) - new Vector3(0, 0, 0.1f); ;
                        solders[1].SetActive(true);
                        GameModel[i, j] = leny[1].sortName;
                        tileS[j + (i * 8)] = "3";
                        tileSLocal[j + (i * 8)] = "3";
                        globalSlots.slot2x = j;
                        globalSlots.slot2y = i;
                }
                /* ide jön majd később a többi fajta ember ami a tied.
                arra figyelni hogy a tileS 2-7 ig fog menni, viszont a solders az legalább 0-17 ig attól föggően milyen helyen milyen erősségű knightok vannak.*/

                if (i == 0 && j == 0 && globalSlots.slot7I > 0)
                {
                    numberOfEnemy++;
                    if (globalSlots.slot7T == "BImp")
                    {
                        leny[6] = new creatureScript.CREATURE(4, 4, 3, "Blue Ipm", "BImp", globalSlots.slot7I, "Sprites/walk_vanilla_BIMP", "audio/mob2", "audio/mob2die", "Animations/blueImpAnim","");

                    }
                    if (globalSlots.slot7T == "RImp")
                    {
                        leny[6] = new creatureScript.CREATURE(5, 5, 4, "Red Ipm", "RImp", globalSlots.slot7I, "Sprites/walk_vanilla_RIMP", "audio/mob3", "audio/mob3die", "Animations/redImpAnim","");
                    }

                    enemys[0].AddComponent<Animator>();
                        RuntimeAnimatorController[] obj1 = Resources.LoadAll<RuntimeAnimatorController>(leny[6].anim);
                        enemys[0].GetComponent<Animator>().runtimeAnimatorController =obj1[0];
                        Sprite[] obj = Resources.LoadAll<Sprite>(leny[6].pathSprite);
                        enemys[0].GetComponent<SpriteRenderer>().sprite = obj[5];
                        enemys[0].transform.position = (TileModel[j + (i * 8)].GetComponent<Renderer>().bounds.center) - new Vector3(0, 0, 0.1f); ;
                        enemys[0].SetActive(true);
                        GameModel[i, j] = leny[6].sortName;
                        tileS[j + (i * 8)] = "8";
                        tileSLocal[j + (i * 8)] = "8";
                }
                if (i == 2 && j == 0 && globalSlots.slot8I > 0)
                {
                    numberOfEnemy++;
                    if (globalSlots.slot8T == "RImp")
                    {
                        leny[7] = new creatureScript.CREATURE(5, 5, 4, "Red Ipm", "RImp", globalSlots.slot8I, "Sprites/walk-vanilla_RIMP", "audio/mob3", "audio/mob3die", "Animations/redImpAnim","");
                    }
                    if (globalSlots.slot8T == "BImp")
                    {
                        leny[7] = new creatureScript.CREATURE(4, 4, 3, "Blue Ipm", "BImp", globalSlots.slot8I, "Sprites/walk_vanilla_BIMP", "audio/mob2", "audio/mob2die", "Animations/blueImpAnim","");

                    }
                    enemys[1].AddComponent<Animator>();
                       
                        RuntimeAnimatorController[] obj1 = Resources.LoadAll<RuntimeAnimatorController>(leny[7].anim);
                        enemys[1].GetComponent<Animator>().runtimeAnimatorController = obj1[0];
                        Sprite[] obj = Resources.LoadAll<Sprite>(leny[7].pathSprite);
                        enemys[1].GetComponent<SpriteRenderer>().sprite = obj[0];
                        enemys[1].transform.position = (TileModel[j + (i * 8)].GetComponent<Renderer>().bounds.center) - new Vector3(0, 0, 0.1f); ;
                        enemys[1].SetActive(true);
                        GameModel[i, j] = leny[7].sortName;
                        tileS[j + (i * 8)] = "9";
                        tileSLocal[j + (i * 8)] = "9";
                    
                }
                if (i == 4 && j == 0 && globalSlots.slot9I > 0)
                {
                    numberOfEnemy++;
                    if (globalSlots.slot9T == "BImp")
                    {
                        leny[8] = new creatureScript.CREATURE(4, 4, 3, "Blue Ipm", "BImp", globalSlots.slot9I, "Sprites/walk_vanilla_BIMP", "audio/mob2", "audio/mob2die", "Animations/blueImpAnim","");
                    }
                    if (globalSlots.slot9T == "RImp")
                    {
                        leny[8] = new creatureScript.CREATURE(5, 5, 4, "Red Ipm", "RImp", globalSlots.slot9I, "Sprites/walk_vanilla_RIMP", "audio/mob3", "audio/mob3die", "Animations/redImpAnim","");
                    }
                    enemys[2].AddComponent<Animator>();
                       
                       
                        RuntimeAnimatorController[] obj1 = Resources.LoadAll<RuntimeAnimatorController>(leny[8].anim);
                        enemys[2].GetComponent<Animator>().runtimeAnimatorController = obj1[0];
                        Sprite[] obj = Resources.LoadAll<Sprite>(leny[8].pathSprite);
                        enemys[2].GetComponent<SpriteRenderer>().sprite = obj[5];
                        enemys[2].transform.position = (TileModel[j + (i * 8)].GetComponent<Renderer>().bounds.center) - new Vector3(0, 0, 0.1f); ;
                        enemys[2].SetActive(true);
                        GameModel[i, j] = leny[8].sortName;
                        tileS[j + (i * 8)] = "10";
                        tileSLocal[j + (i * 8)] = "10";
                }
                }
        }
        //tileSLocal1 = tileS;
        kiirMap();
    }

    // Update is called once per frame
    void Update()
    {
        tileSS = tileS;
        if(numberOfTeam<1)
        {
          flowchart.SendFungusMessage("youLose");
        }
        if(numberOfEnemy<1)
        {
            flowchart.SendFungusMessage("youWin");
            globalVariable.isloaded = true;
        }
        whereTogo1 = whereTogo;
        if(painted==false)
        {
            
            for(int i=0;i<64;i++)
            {
                if (int.Parse(tileS[i]) > 1 && int.Parse(tileS[i]) < 20)
                {
                    TileModel[i].GetComponent<Renderer>().material = mat[0];
                }
                if (tileS[i]=="1")
                {
                TileModel[i].GetComponent<Renderer>().material = mat[1];
                }
                if (tileSLocal[i]=="20")
                { 
                TileModel[i].GetComponent<Renderer>().material = mat[3];
                }
                if (tileS[i] == "0")
                {
                    TileModel[i].GetComponent<Renderer>().material = mat[0];
                }
                
            }
            painted = true;
           
        }
       
        round1 = round;
        if(round==1)
        {
           
            int position = 0;
            if (searched == false)
            {
                kiirMap();
                position = getLeny("2");
                
                if (position == 100)
                {
                    round++;
                    searched = false;
                }
                else
                {
                    searched = true;
                    TileModel[position].GetComponent<Renderer>().material = mat[2];
                }
               
            }
            
            if(moved==true)
            {
                transformpostionTo(whereTogo);
                moved = false;
                searched = false;
            }
        }
        if (round==2)
        {
            int position = 0;
            if (searched == false)
            {
                position = getLeny("3");
                if (position == 100)
                {
                    round++;
                    searched = false;
                }
                else
                {
                    searched = true;
                    TileModel[position].GetComponent<Renderer>().material = mat[2];
                }
            }
            if(moved==true)
            {
                transformpostionTo(whereTogo);
                moved = false;
                searched = false;

            }
        }
        if (round==3)
        {
            int position = 0;
            if (searched == false)
            {
                position = getLeny("4");
                if (position == 100)
                {
                    round++;
                    searched = false;
                }
                else
                {
                    searched = true;
                    TileModel[position].GetComponent<Renderer>().material = mat[2];
                }
            }
            if(moved==true)
            {
                transformpostionTo(whereTogo);
                moved = false;
                globalSlots.threeSelected = false;
                round++;
                searched = false;

            }
        }
        if (round==4)
        {
            int position = 0;
            if (searched == false)
            {
                position = getLeny("5");
                if (position == 100)
                {
                    round++;
                    searched = false;
                }
                else
                {
                    searched = true;
                    TileModel[position].GetComponent<Renderer>().material = mat[2];
                }
            }
            if(moved==true)
            {
                transformpostionTo(whereTogo);
                moved = false;
                globalSlots.fourSelected = false;
                round++;
                searched = false;

            }
        }
        if (round==5)
        {
            int position = 0;
            if (searched == false)
            {
                position = getLeny("6");
                if (position == 100)
                {
                    round++;
                    searched = false;
                }
                else
                {
                    searched = true;
                    TileModel[position].GetComponent<Renderer>().material = mat[2];
                }
            }
            if(moved==true)
            {
                transformpostionTo(whereTogo);
                moved = false;
                globalSlots.fiveSelected = false;
                round++;
                searched = false;

            }
        }
        if (round==6)
        {
            int position = 0;
            if (searched == false)
            {
                position = getLeny("7");
                if (position == 100)
                {
                    round++;
                    searched = false;
                }
                else
                {
                    searched = true;
                    TileModel[position].GetComponent<Renderer>().material = mat[2];
                }
            }
            if(moved==true)
            {
                transformpostionTo(whereTogo);
                moved = false;
                globalSlots.sixSelected = false;
                round++;
                searched = false;

            }
        }
        if (round==7)
        {
               attackEnemy();
            if (moved == true)
            {
                moved = false;
                round++;
                searched = false;
            }
               
        }
        if (round==8)
        {
            attackEnemy();

            if (moved == true)
            {
                moved = false;
                round++;
                searched = false;
            }
        }
        if (round==9)
        {
            attackEnemy();

            if (moved == true)
            {
                moved = false;
                round++;
                searched = false;
            }
        }
        if (round==10)
        {
            attackEnemy();
            round++;
            searched = false;
        }
        if (round==11)
        {
            attackEnemy();
            round++;
            searched = false;
        }
        if (round==12)
        {
            attackEnemy();
            round++;
            searched = false;
        }
        if (round==13)
        {
            attackEnemy();
            round++;
            searched = false;
        }
        if (round==14)
        {
            round = 1;
            searched = false;
        }
    }
    //get the position of the selected soilder
    public int getLeny(string leny)
    {
        int position = 100;
        for (int i = 0; i < 64; i++)
        {
            TileModel[i].GetComponent<Renderer>().material = mat[0];
        }
            for (int i = 0; i < 64; i++)
        {
            if (tileS[i]==leny)
                {
                position = i;
                break;
                }
        }
      
        return position;
    }
    //write to condol the map.
    public static void kiirMap()
    {
        string kiir = "";
        string kiir2 = "";
        string kiir3 = "";
        int k = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                kiir = kiir + GameModel[i, j] + ",";
                kiir2 = kiir2 + tileS[k] + ",";
                kiir3 = kiir3 + tileSLocal[k] + ",";
                if (j % 8 == 7)
                {

                    kiir = kiir + "\n";
                    kiir2 = kiir2 + "\n";
                    kiir3 = kiir3 + "\n";
                }
                k++;

            }
        }
        Debug.Log(kiir);
        Debug.Log(kiir2);
        Debug.Log(kiir3);
    }
    public void transformpostionTo(string tileName)
    {
        if (globalSlots.oneSelected)
        {
            int position = int.Parse(whereTogo.Replace("simpleTile", ""));
            if (tileS[position] == "1")
            {
                solders[0].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);

                for (int i = 0; i < 64; i++)
                {
                    if (tileS[i] == "2")
                    {
                        tileS[i] = "0";
                        tileSLocal[i] = "0";
                        GameModel[i / 8, i % 8] = "0";
                    }
                    if (tileS[i] == "1")
                    {
                        tileS[i] = "0";
                        tileSLocal[i] = "0";
                        GameModel[i / 8, i % 8] = "0";
                    }
                    if (tileSLocal[i] == "20")
                    {

                        tileSLocal[i] = tileS[i];
                    }
                   
                }
                tileS[position] = "2";
                tileSLocal[position] = "2";
                GameModel[position / 8, position % 8] = "k";
                globalSlots.slot1y = position / 8; 
                globalSlots.slot1x = position % 8;
                moved = false;
                globalSlots.oneSelected = false;
                round++;
                searched = false;
                StartCoroutine(playSoundSlot1(leny[0].aud1));
            }
          
        }
        if (globalSlots.twoSelected)
        {
            int position = int.Parse(whereTogo.Replace("simpleTile", ""));
            if (tileS[position] == "1"||tileS[position] == "3")
            {
                solders[1].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);

                for (int i = 0; i < 64; i++)
                {
                    if (tileS[i] == "3")
                    {
                        tileS[i] = "0";
                        tileSLocal[i] = "0";
                        GameModel[i / 8, i % 8] = "0";
                    }
                    if (tileS[i] == "1")
                    {
                        tileS[i] = "0";
                        tileSLocal[i] = "0";
                        GameModel[i / 8, i % 8] = "0";
                    }
                    if (tileSLocal[i] == "20")
                    {
                        tileSLocal[i] = tileS[i];
                    }
                }
                tileS[position] = "3";
                tileSLocal[position] = "3";
                GameModel[position / 8, position % 8] = "ar";
                globalSlots.slot2y = position / 8;
                globalSlots.slot2x = position % 8;
                globalSlots.twoSelected = false;
                round++;
                StartCoroutine(playSoundSlot1(leny[1].aud1));
            }
            
        }
       
    }

    //The enemyAttack
    public void attackEnemy()
    {
       
        if(round==7)
        {
            if (moved == false && caled == false)
            {
                caled = true;
                StartCoroutine(playSoundslot7(leny[6].aud1));
            }
            
        }
        if (round == 8)
        {
            if (moved == false && caled == false)
            {
                caled = true;
                StartCoroutine(playSoundslot8(leny[7].aud1));
            }
        }
        if (round == 9)
        {
            if (moved == false && caled == false)
            {
                caled = true;
                StartCoroutine(playSoundslot9(leny[8].aud1));
            }

        }
        if (round == 10)
        {
            if (globalSlots.slot10I > 0)//if the enemy is more than 0
            {
                //declarate the main variable
                int move = 0;
                int dmg = 0;
                string shortName = "";
                string lenyName = "";
                string target = "";
                if (globalSlots.slot10T == "BImp")
                {
                    blueImp.BIMP leny = new blueImp.BIMP(globalSlots.slot10I);
                    move = leny.move;
                    dmg = leny.dmg;
                    shortName = leny.sortName;
                    lenyName = leny.name;
                }
                int posi = 100;
                int myPosi = 0;
                string[] ered_A = new string[3];
                string ered = searchForEnemy("11");
                ered_A = ered.Split(',');
                posi = int.Parse(ered_A[1]);
                target = ered_A[0];
                myPosi = int.Parse(ered_A[2]);
                //we calculat witch way the enemy is moving
                int distance = 0;
                int distance1 = 0;
                bool enemyAttack = false;
                if (posi < 100)
                {
                    while (move > 0)
                    {

                        distance = posi - myPosi;
                        distance1 = distance;
                        int gogo = myPosi;
                        /*if tileS=0 or bigger than 0 and lover than 8 (your soilder)
                         * if you can move
                         * if the distance is biggr then the distanc after move
                         * if you dont move out of the map
                        */
                        if ((myPosi - 1) > -1)
                        {
                            if (int.Parse(tileS[(myPosi - 1)]) < 8 && move > 0 && distance1 > (posi - (myPosi - 1)) && (posi - (myPosi - 1)) > 0 && (myPosi / 8) == ((myPosi - 1) / 8))
                            {
                                if (tileS[(myPosi - 1)] == "0")
                                {
                                    distance1 = posi - (myPosi - 1);
                                    gogo = myPosi - 1;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi - 1)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        if ((myPosi + 1) < 64)
                        {
                            if (int.Parse(tileS[(myPosi + 1)]) < 8 && move > 0 && distance1 > (posi - (myPosi + 1)) && (posi - (myPosi + 1)) > 0 && (myPosi / 8) == ((myPosi + 1) / 8))
                            {
                                if (tileS[(myPosi + 1)] == "0")
                                {
                                    distance1 = posi - (myPosi + 1);
                                    gogo = myPosi + 1;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi + 1)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        if ((myPosi + 8) < 64)
                        {
                            if (int.Parse(tileS[(myPosi + 8)]) < 8 && move > 0 && distance1 > (posi - (myPosi + 8)) && (posi - (myPosi + 8)) > 0)
                            {
                                if (tileS[(myPosi + 8)] == "0")
                                {
                                    distance1 = posi - (myPosi + 8);
                                    gogo = myPosi + 8;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi + 8)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        if ((myPosi - 8) > -1)
                        {
                            if (int.Parse(tileS[(myPosi - 8)]) < 8 && move > 0 && distance1 > (posi - (myPosi - 8)) && (posi - (myPosi - 8)) > 0)
                            {
                                if (tileS[(myPosi - 8)] == "0")
                                {
                                    distance1 = posi - (myPosi - 8);
                                    gogo = myPosi - 8;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi - 8)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        move--;
                        tileS[myPosi] = "0";
                        tileSLocal[myPosi] = "0";
                        GameModel[myPosi / 8, myPosi % 8] = "0";
                        tileS[gogo] = "11";
                        tileSLocal[gogo] = "11";
                        GameModel[gogo / 8, gogo % 8] = shortName;
                        myPosi = gogo;

                    }
                    if (enemyAttack)
                    {
                        attackThePlayer(dmg, target, lenyName);
                    }
                }
            }
        }
        if (round == 11)
        {
            if (globalSlots.slot11I > 0)//if the enemy is more than 0
            {
                //declarate the main variable
                int move = 0;
                int dmg = 0;
                string shortName = "";
                string lenyName = "";
                string target = "";
                if (globalSlots.slot11T == "BImp")
                {
                    blueImp.BIMP leny = new blueImp.BIMP(globalSlots.slot11I);
                    move = leny.move;
                    dmg = leny.dmg;
                    shortName = leny.sortName;
                    lenyName = leny.name;
                }
                int posi = 100;
                int myPosi = 0;
                string[] ered_A = new string[3];
                string ered = searchForEnemy("12");
                ered_A = ered.Split(',');
                posi = int.Parse(ered_A[1]);
                target = ered_A[0];
                myPosi = int.Parse(ered_A[2]);
                //we calculat witch way the enemy is moving
                int distance = 0;
                int distance1 = 0;
                bool enemyAttack = false;
                if (posi < 100)
                {
                    while (move > 0)
                    {

                        distance = posi - myPosi;
                        distance1 = distance;
                        int gogo = myPosi;
                        /*if tileS=0 or bigger than 0 and lover than 8 (your soilder)
                         * if you can move
                         * if the distance is biggr then the distanc after move
                         * if you dont move out of the map
                        */
                        if ((myPosi - 1) > -1)
                        {
                            if (int.Parse(tileS[(myPosi - 1)]) < 8 && move > 0 && distance1 > (posi - (myPosi - 1)) && (posi - (myPosi - 1)) > 0 && (myPosi / 8) == ((myPosi - 1) / 8))
                            {
                                if (tileS[(myPosi - 1)] == "0")
                                {
                                    distance1 = posi - (myPosi - 1);
                                    gogo = myPosi - 1;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi - 1)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        if ((myPosi + 1) < 64)
                        {
                            if (int.Parse(tileS[(myPosi + 1)]) < 8 && move > 0 && distance1 > (posi - (myPosi + 1)) && (posi - (myPosi + 1)) > 0 && (myPosi / 8) == ((myPosi + 1) / 8))
                            {
                                if (tileS[(myPosi + 1)] == "0")
                                {
                                    distance1 = posi - (myPosi + 1);
                                    gogo = myPosi + 1;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi + 1)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                            if ((myPosi + 8) < 64)
                            {
                                if (int.Parse(tileS[(myPosi + 8)]) < 8 && move > 0 && distance1 > (posi - (myPosi + 8)) && (posi - (myPosi + 8)) > 0)
                                {
                                    if (tileS[(myPosi + 8)] == "0")
                                    {
                                        distance1 = posi - (myPosi + 8);
                                        gogo = myPosi + 8;
                                        string tileName = "simpleTile" + gogo;
                                        enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                    }
                                    else
                                    {
                                    target = tileS[(myPosi + 8)];
                                    enemyAttack = true;
                                        break;
                                    }
                                }
                            }
                        if ((myPosi - 8) > -1)
                        {
                            if (int.Parse(tileS[(myPosi - 8)]) < 8 && move > 0 && distance1 > (posi - (myPosi - 8)) && (posi - (myPosi - 8)) > 0)
                            {
                                if (tileS[(myPosi - 8)] == "0")
                                {
                                    distance1 = posi - (myPosi - 8);
                                    gogo = myPosi - 8;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi - 8)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        move--;
                        tileS[myPosi] = "0";
                        tileSLocal[myPosi] = "0";
                        GameModel[myPosi / 8, myPosi % 8] = "0";
                        tileS[gogo] = "12";
                        tileSLocal[gogo] = "12";
                        GameModel[gogo / 8, gogo % 8] = shortName;
                        myPosi = gogo;

                    }
                    if (enemyAttack)
                    {
                        attackThePlayer(dmg, target, lenyName);
                    }
                }
            }
        }
        if (round == 12)
        {
            if (globalSlots.slot12I > 0)//if the enemy is more than 0
            {
                //declarate the main variable
                int move = 0;
                int dmg = 0;
                string shortName = "";
                string lenyName = "";
                string target = "";
                if (globalSlots.slot12T == "BImp")
                {
                    blueImp.BIMP leny = new blueImp.BIMP(globalSlots.slot12I);
                    move = leny.move;
                    dmg = leny.dmg;
                    shortName = leny.sortName;
                    lenyName = leny.name;
                }
                int posi = 100;
                int myPosi = 0;
                string[] ered_A = new string[3];
                string ered = searchForEnemy("13");
                ered_A = ered.Split(',');
                posi = int.Parse(ered_A[1]);
                target = ered_A[0];
                myPosi = int.Parse(ered_A[2]);
                //we calculat witch way the enemy is moving
                int distance = 0;
                int distance1 = 0;
                bool enemyAttack = false;
                if (posi < 100)
                {
                    while (move > 0)
                    {

                        distance = posi - myPosi;
                        distance1 = distance;
                        int gogo = myPosi;
                        /*if tileS=0 or bigger than 0 and lover than 8 (your soilder)
                         * if you can move
                         * if the distance is biggr then the distanc after move
                         * if you dont move out of the map
                        */
                        if ((myPosi - 1) > -1)
                        {
                            if (int.Parse(tileS[(myPosi - 1)]) < 8 && move > 0 && distance1 > (posi - (myPosi - 1)) && (posi - (myPosi - 1)) > 0 && (myPosi / 8) == ((myPosi - 1) / 8))
                            {
                                if (tileS[(myPosi - 1)] == "0")
                                {
                                    distance1 = posi - (myPosi - 1);
                                    gogo = myPosi - 1;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi - 1)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        if ((myPosi + 1) < 64)
                        {
                            if (int.Parse(tileS[(myPosi + 1)]) < 8 && move > 0 && distance1 > (posi - (myPosi + 1)) && (posi - (myPosi + 1)) > 0 && (myPosi / 8) == ((myPosi + 1) / 8))
                            {
                                if (tileS[(myPosi + 1)] == "0")
                                {
                                    distance1 = posi - (myPosi + 1);
                                    gogo = myPosi + 1;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi + 1)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                            if ((myPosi + 8) < 64)
                            {
                                if (int.Parse(tileS[(myPosi + 8)]) < 8 && move > 0 && distance1 > (posi - (myPosi + 8)) && (posi - (myPosi + 8)) > 0)
                                {
                                    if (tileS[(myPosi + 8)] == "0")
                                    {
                                        distance1 = posi - (myPosi + 8);
                                        gogo = myPosi + 8;
                                        string tileName = "simpleTile" + gogo;
                                        enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                    }

                                    else
                                    {
                                    target = tileS[(myPosi + 8)];
                                    enemyAttack = true;
                                        break;
                                    }
                                }
                            }
                        if ((myPosi - 8) > -1)
                        {
                            if (int.Parse(tileS[(myPosi - 8)]) < 8 && move > 0 && distance1 > (posi - (myPosi - 8)) && (posi - (myPosi - 8)) > 0)
                            {
                                if (tileS[(myPosi - 8)] == "0")
                                {
                                    distance1 = posi - (myPosi - 8);
                                    gogo = myPosi - 8;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi - 8)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        move--;
                        tileS[myPosi] = "0";
                        tileSLocal[myPosi] = "0";
                        GameModel[myPosi / 8, myPosi % 8] = "0";
                        tileS[gogo] = "13";
                        tileSLocal[gogo] = "13";
                        GameModel[gogo / 8, gogo % 8] = shortName;
                        myPosi = gogo;

                    }
                    if (enemyAttack)
                    {
                        attackThePlayer(dmg, target, lenyName);
                    }
                }
            }
        }
        if (round == 13)
        {
            if (globalSlots.slot13I > 0)//if the enemy is more than 0
            {
                //declarate the main variable
                int move = 0;
                int dmg = 0;
                string shortName = "";
                string lenyName = "";
                string target = "";
                if (globalSlots.slot13T == "BImp")
                {
                    blueImp.BIMP leny = new blueImp.BIMP(globalSlots.slot13I);
                    move = leny.move;
                    dmg = leny.dmg;
                    shortName = leny.sortName;
                    lenyName = leny.name;
                }
                int posi = 100;
                int myPosi = 0;
                string[] ered_A = new string[3];
                string ered = searchForEnemy("14");
                ered_A = ered.Split(',');
                posi = int.Parse(ered_A[1]);
                target = ered_A[0];
                myPosi = int.Parse(ered_A[2]);
                //we calculat witch way the enemy is moving
                int distance = 0;
                int distance1 = 0;
                bool enemyAttack = false;
                if (posi < 100)
                {
                    while (move > 0)
                    {

                        distance = posi - myPosi;
                        distance1 = distance;
                        int gogo = myPosi;
                        /*if tileS=0 or bigger than 0 and lover than 8 (your soilder)
                         * if you can move
                         * if the distance is biggr then the distanc after move
                         * if you dont move out of the map
                        */
                        if ((myPosi - 1) > -1)
                        {
                            if (int.Parse(tileS[(myPosi - 1)]) < 8 && move > 0 && distance1 > (posi - (myPosi - 1)) && (posi - (myPosi - 1)) > 0 && (myPosi / 8) == ((myPosi - 1) / 8))
                            {
                                if (tileS[(myPosi - 1)] == "0")
                                {
                                    distance1 = posi - (myPosi - 1);
                                    gogo = myPosi - 1;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi - 1)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        if ((myPosi + 1) < 64)
                        {
                            if (int.Parse(tileS[(myPosi + 1)]) < 8 && move > 0 && distance1 > (posi - (myPosi + 1)) && (posi - (myPosi + 1)) > 0 && (myPosi / 8) == ((myPosi + 1) / 8))
                            {
                                if (tileS[(myPosi + 1)] == "0")
                                {
                                    distance1 = posi - (myPosi + 1);
                                    gogo = myPosi + 1;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi + 1)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                            if ((myPosi + 8) < 64)
                            {
                                if (int.Parse(tileS[(myPosi + 8)]) < 8 && move > 0 && distance1 > (posi - (myPosi + 8)) && (posi - (myPosi + 8)) > 0)
                                {
                                    if (tileS[(myPosi + 8)] == "0")
                                    {
                                        distance1 = posi - (myPosi + 8);
                                        gogo = myPosi + 8;
                                        string tileName = "simpleTile" + gogo;
                                        enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                    }

                                    else
                                    {
                                    target = tileS[(myPosi + 8)];
                                    enemyAttack = true;
                                        break;
                                    }
                                }
                            }
                        if ((myPosi - 8) > -1)
                        {
                            if (int.Parse(tileS[(myPosi - 8)]) < 8 && move > 0 && distance1 > (posi - (myPosi - 8)) && (posi - (myPosi - 8)) > 0)
                            {
                                if (tileS[(myPosi - 8)] == "0")
                                {
                                    distance1 = posi - (myPosi - 8);
                                    gogo = myPosi - 8;
                                    string tileName = "simpleTile" + gogo;
                                    enemys[2].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                                }
                                else
                                {
                                    target = tileS[(myPosi - 8)];
                                    enemyAttack = true;
                                    break;
                                }
                            }
                        }
                        move--;
                        tileS[myPosi] = "0";
                        tileSLocal[myPosi] = "0";
                        GameModel[myPosi / 8, myPosi % 8] = "0";
                        tileS[gogo] = "14";
                        tileSLocal[gogo] = "14";
                        GameModel[gogo / 8, gogo % 8] = shortName;
                        myPosi = gogo;

                    }
                    if (enemyAttack)
                    {
                        attackThePlayer(dmg, target, lenyName);
                    }
                }
            }
        }
    }
    public void MoveEnemy(int ki,string search)
    {
        int move = leny[ki].move;
        int dmg = leny[ki].dmg;
        string shortName = leny[ki].sortName;
        string lenyName = leny[ki].name;
        string target = "";
        int posi = 100;
        int myPosi = 0;
        string[] ered_A = new string[3];
        string ered = searchForEnemy(search);
        ered_A = ered.Split(',');
        posi = int.Parse(ered_A[1]);
        target = ered_A[0];
        myPosi = int.Parse(ered_A[2]);
        //we calculat witch way the enemy is moving
        int distance = 0;
        int distance1 = 0;
        bool enemyAttack = false;
        if (posi < 100)
        {
            while (move > 0)
            {

                distance = posi - myPosi;
                distance1 = distance;
                int gogo = myPosi;
                /*if tileS=0 or bigger than 0 and lover than 8 (your soilder)
                 * if you can move
                 * if the distance is biggr then the distanc after move
                 * if you dont move out of the map
                */
                if ((myPosi - 1) > -1)
                {
                    if (int.Parse(tileS[(myPosi - 1)]) < 8)
                    {
                        if (tileS[(myPosi - 1)] == "0" && move > 0 && distance1 > (posi - (myPosi - 1)) && (posi - (myPosi - 1)) > 0 && (myPosi / 8) == ((myPosi - 1) / 8))
                        {
                            distance1 = posi - (myPosi - 1);
                            gogo = myPosi - 1;
                        }
                       if(int.Parse(tileS[(myPosi - 1)])>0)
                        {
                            target = tileS[(myPosi - 1)];
                            enemyAttack = true;
                            break;
                        }
                    }
                }
                if ((myPosi + 1) < 64)
                {
                    if (int.Parse(tileS[(myPosi + 1)]) < 8 )
                    {
                        if (tileS[(myPosi + 1)] == "0" && move > 0 && distance1 > (posi - (myPosi + 1)) && (posi - (myPosi + 1)) > 0 && (myPosi / 8) == ((myPosi + 1) / 8))
                        {
                            distance1 = posi - (myPosi + 1);
                            gogo = myPosi + 1;
                        }
                        if (int.Parse(tileS[(myPosi + 1)])>0)
                        {
                            target = tileS[(myPosi + 1)];
                            enemyAttack = true;
                            break;
                        }
                    }
                }
                if ((myPosi + 8) < 64)
                {
                    if (int.Parse(tileS[(myPosi + 8)]) < 8 )
                    {
                        if (tileS[(myPosi + 8)] == "0" && move > 0 && distance1 > (posi - (myPosi + 8)) && (posi - (myPosi + 8)) > 0)
                        {
                            distance1 = posi - (myPosi + 8);
                            gogo = myPosi + 8;
                        }
                        if (int.Parse(tileS[(myPosi + 8)])>0)
                        {
                            target = tileS[(myPosi + 8)];
                            enemyAttack = true;
                            break;
                        }
                    }
                }
                if ((myPosi - 8) > -1)
                {
                    if (int.Parse(tileS[(myPosi - 8)]) < 8 )
                    {
                        if (tileS[(myPosi - 8)] == "0" && move > 0 && distance1 > (posi - (myPosi - 8)) && (posi - (myPosi - 8)) > 0)
                        {
                            distance1 = posi - (myPosi - 8);
                            gogo = myPosi - 8;

                        }
                        if (int.Parse(tileS[(myPosi - 8)]) > 0)
                        {
                            target = tileS[(myPosi - 8)];
                            enemyAttack = true;
                            break;
                        }
                    }
                }

                string tileName = "simpleTile" + gogo;
                enemys[0].transform.position = GameObject.Find(tileName).GetComponent<Renderer>().bounds.center - new Vector3(0, 0, 0.1f);
                move--;
                tileS[myPosi] = "0";
                tileSLocal[myPosi] = "0";
                GameModel[myPosi / 8, myPosi % 8] = "0";
                tileS[gogo] = "8";
                tileSLocal[gogo] = "8";
                GameModel[gogo / 8, gogo % 8] = shortName;
                myPosi = gogo;

            }

        }
        if (enemyAttack)
        {
            attackThePlayer(dmg, target, lenyName);

        }
    }
    public void attackThePlayer(int dmg, string target,string lenyName)
    {
        bool crit = false;
        int admg = 0;
        if ((Random.Range(1,10)%5)==0)
        {
            crit = true;
        }
        if(crit)
        {
            admg = Random.Range(dmg, (dmg*2));
        }
        else
        {
             admg = Random.Range(1, dmg);
        }

        int healt = 0;
        int ahealt = 0;
        int db = 0;
        string name = "";
        if(target=="2")
        {
                db = leny[0].db;
                ahealt = leny[0].ahealt;
                name = leny[0].name;
        }
        if (target=="3")
        {     
                db = leny[1].db;
                ahealt = leny[1].ahealt;
                name = leny[1].name;
        }
        healt = ahealt * db;
        int survival = 0 ;
        if((healt-admg)>0)
        {
            if(((healt-admg) % ahealt) > 0)
            {
                survival = ((healt-admg) / ahealt) +1;
            }
            else
            {
                survival = (healt-admg) / ahealt;
            }

            GameObject.Find("enemyStat").GetComponent<Text>().text = lenyName + " attacked you, and do " + admg
                + " dmg\n " + (db - survival) + " " + name + " die!";
            if(target=="2")
            {
                globalSlots.slot1I = survival;
                leny[0].db = survival;
            }
            if (target=="3")
            {
                globalSlots.slot2I = survival;
                leny[1].db = survival;
            }
        }
        else
        {
            GameObject.Find("enemyStat").GetComponent<Text>().text = lenyName + " attacked you, and killed all "+name+"'s";
            if (target == "2")
            {
                globalSlots.slot1I = 0;
                solders[0].GetComponent<Animator>().SetBool("Live", false);
                StartCoroutine(Solder1Die(leny[0].aud3));
            }
            if (target == "3")
            {
                globalSlots.slot2I = 0;
                solders[1].GetComponent<Animator>().SetBool("Live", false);
                StartCoroutine(Solder2Die(leny[1].aud3));
            }
            numberOfTeam--;
        }
    }
    //delete from map;
    public void erase(string where)
    {
        for(int i=0;i<64;i++)
        {
            if(tileS[i]==where)
            {
                tileS[i] = "0";
                tileSLocal[i] = "0";
                GameModel[i / 8, i % 8] = "0";
                break;
            }
        }
    }
    //we search for the enemy, and first for archer
    //return 3 param, target position, target type,your position
    public string searchForEnemy(string you)
    {
        string returna ="";
        int posi = 0;
        for (int i = 0; i < 64; i++)
        {
            if (tileS[i] == "3")
            {
                returna = returna+"3,";
                returna = returna+i+",";
            }
            if (tileS[i] == you)
            {
                posi= i;
            }
        }
        if (returna.Length == 0)
        {
            for (int i = 0; i < 64; i++)
            {
                if (tileS[i] == "2")
                {
                    returna = returna + "2,";
                    returna = returna + i + ",";
                    break;
                }
                if (tileS[i] == "4")
                {
                    returna = returna + "4,";
                    returna = returna + i + ",";
                    break;
                }
                if (tileS[i] == "5")
                {
                    returna = returna + "5,";
                    returna = returna + i + ",";
                    break;
                }
                if (tileS[i] == "6")
                {
                    returna = returna + "6,";
                    returna = returna + i + ",";
                    break;
                }
                if (tileS[i] == "7")
                {
                    returna = returna + "7,";
                    returna = returna + i + ",";
                    break;
                }
            }
        }
        returna = returna + posi + ",";
        return returna;
    }
    //Play sound delayed
    IEnumerator Solder1Die(AudioClip clip)
    {
        yield return new WaitForSeconds(1.1f);
        solders[0].GetComponent<AudioSource>().enabled = false;
        solders[0].GetComponent<AudioSource>().clip = clip;
        solders[0].GetComponent<AudioSource>().enabled = true;
        solders[0].SetActive(false);
        erase("2");

    }
    IEnumerator Solder2Die(AudioClip clip)
    {
        yield return new WaitForSeconds(.5f);
        solders[1].GetComponent<AudioSource>().enabled = false;
        solders[1].GetComponent<AudioSource>().clip = clip;
        solders[1].GetComponent<AudioSource>().enabled = true;
        solders[1].SetActive(false);
        erase("3");

    }
    IEnumerator playSoundSlot1(AudioClip clip)
    {
        yield return new WaitForSeconds(0.2f);
        solders[0].GetComponent<AudioSource>().enabled = false;
        solders[0].GetComponent<AudioSource>().clip = clip;
        solders[0].GetComponent<AudioSource>().enabled = true;

    }
    IEnumerator playSoundSlot2(AudioClip clip)
    {
        yield return new WaitForSeconds(0.3f);
        solders[1].AddComponent<AudioSource>();
        solders[1].GetComponent<AudioSource>().volume = 0.15f;
        solders[1].GetComponent<AudioSource>().enabled = false;
        solders[1].GetComponent<AudioSource>().clip = clip;
        solders[1].GetComponent<AudioSource>().enabled = true;

    }
    IEnumerator playSoundslot7(AudioClip clip)
    {
        yield return new WaitForSeconds(1);
        if (moved == false)
        {
        if (globalSlots.slot7I > 0)//if the enemy is more than 0
        {
            MoveEnemy(6,"8");
            enemys[0].AddComponent<AudioSource>();
            enemys[0].GetComponent<AudioSource>().volume = 0.15f;
            enemys[0].GetComponent<AudioSource>().enabled = false;
            enemys[0].GetComponent<AudioSource>().clip = clip;
            enemys[0].GetComponent<AudioSource>().enabled = true;
        }
            moved = true;
            caled = false;
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator playSoundslot8(AudioClip clip)
    {
        yield return new WaitForSeconds(1);
        if (moved == false)
        {
            if (globalSlots.slot8I > 0)//if the enemy is more than 0
        {
                //declarate the main variable
            MoveEnemy(7, "9");
            enemys[1].AddComponent<AudioSource>();
            enemys[1].GetComponent<AudioSource>().volume = 0.15f;
            enemys[1].GetComponent<AudioSource>().enabled = false;
            enemys[1].GetComponent<AudioSource>().clip = clip;
            enemys[1].GetComponent<AudioSource>().enabled = true;
        }
            moved = true;
            caled = false;
        }
        yield return new WaitForSeconds(1);

    }
    IEnumerator playSoundslot9(AudioClip clip)
    {
        yield return new WaitForSeconds(1);
        if (moved == false)
        {
        if (globalSlots.slot9I > 0)//if the enemy is more than 0
        {
            MoveEnemy(8, "9");
            enemys[2].AddComponent<AudioSource>();
            enemys[2].GetComponent<AudioSource>().volume = 0.15f;
            enemys[2].GetComponent<AudioSource>().enabled = false;
            enemys[2].GetComponent<AudioSource>().clip = clip;
            enemys[2].GetComponent<AudioSource>().enabled = true;
        }
        moved = true;
        caled = false;
        }
    yield return new WaitForSeconds(1);

}
    }
