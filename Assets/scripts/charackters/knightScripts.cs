using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Fungus;
public class knightScripts : MonoBehaviour
{
    [SerializeField]
    [Header("csaje")]
    Animator anim;
    public Flowchart flowchart;
    public static GameObject stats,knight;
    public  GameObject stats1,knight1;
    [Header("statok")]
    public int lepes = 3;
    public static bool selected = false;
    public static bool kmove = false;
    public bool kmove1 = false;
    public float speed = 0.1f;
    public bool isAlive = true;
    [Header("poziciók")]
    public static int kposition = 0;
    public int kpozi = 0;
    [Header("új sor,oszlop")]
    public static int ksor = 0;
    public static  int koszlop = 0;
    [Header("régi sor,oszlop")]
    public static  int oldksor = 0;
    public static int oldkoszlop = 0;
    [Header("bejövő inputok")]
    public static float mousex;
    public static float mousey;
    [Header("merre tovább")]
    public static  float newposx, newposy,mposx,mposy;
    public static string whereToGo;
    public string whereToGo1;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("youStat")!=null)
            {
            stats = GameObject.Find("youStat");
            knight = GameObject.Find("Knight");
            stats1 = stats;
            knight1 = knight;
            newposx = knight.transform.position.x;
            newposy = knight.transform.position.y;
        }
        anim = GetComponent<Animator>();
        anim.SetBool("knight1Idle", true);

    }

    // Update is called once per frame
    void Update()
    {

       
        kmove1 = kmove;
        if (kmove)
        {
            whereToGo1 = whereToGo;
            mposx = mousex;
            mposy = mousey;
            StartCoroutine(knightMove());
        }
        else
        { 
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        globalVariable.addObjectToList("knight1");
        flowchart.SendFungusMessage("knight1");
       
    }
    private void OnMouseUp()
    {
        globalSlots.oneSelected = true;
        stats.GetComponent<Text>().text = "";
        knightScripts.stats.GetComponent<Text>().text = "Knight("+globalSlots.slot1I+")\nHP: (3) " + (3*globalSlots.slot1I) + "\nDMG: (4) " + (4*globalSlots.slot1I) + "";
        if (tileScript.round == 1)
        {
            selected = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tileScript.gameModel[i, j] == "k")
                    {
                        kposition = (i * 8) + j;
                    }
                }
            }
            koszlop = kposition % 8;
            ksor = kposition / 8;
            oldkoszlop = koszlop;
            oldksor = ksor;
            for (int a = 0; a < (lepes + 1); a++)
            {
                for (int b = 0; b < (lepes-a); b++)
                {

                    if (((koszlop + b) < 8) && ((ksor + a) < 8))
                    {

                        if (tileScript.gameModel[(ksor + a), (koszlop + b)] == "0")
                        {
                            tileScript.gameModel[(ksor + a), (koszlop + b)] = "1";
                        }
                        if (tileScript.gameModel[(ksor + a), (koszlop + b)] == "w1" || tileScript.gameModel[(ksor + a), (koszlop + b)] == "w2")
                        {
                            tileScript.tileS[((ksor + a)*8)+(koszlop + b)] = "aa";
                        }
                       
                    }
                    if (((koszlop + b) < 8) && ((ksor - a) > -1))
                    {
                        if (tileScript.gameModel[(ksor - a), (koszlop + b)] == "0")
                        {
                            tileScript.gameModel[(ksor - a), (koszlop + b)] = "1";
                        }
                        if (tileScript.gameModel[(ksor - a), (koszlop + b)] == "w1" || tileScript.gameModel[(ksor - a), (koszlop + b)] == "w2")
                        {
                            tileScript.tileS[((ksor - a) * 8) + (koszlop + b)] = "aa";
                        }
                    }
                    if (((koszlop - b) > -1) && ((ksor - a) > -1))
                    {
                        if (tileScript.gameModel[(ksor - a), (koszlop - b)] == "0")
                        {
                            tileScript.gameModel[(ksor - a), (koszlop - b)] = "1";
                        }
                        if (tileScript.gameModel[(ksor - a), (koszlop - b)] == "w1" || tileScript.gameModel[(ksor - a), (koszlop - b)] == "w2")
                        {
                            tileScript.tileS[((ksor -a) * 8) + (koszlop - b)] = "aa";
                        }
                    }
                    if (((koszlop - b) > -1) && ((ksor + a) < 8))
                    {

                        if (tileScript.gameModel[(ksor + a), (koszlop - b)] == "0")
                        {
                            tileScript.gameModel[(ksor + a), (koszlop - b)] = "1";
                        }
                        if (tileScript.gameModel[(ksor + a), (koszlop - b)] == "w1" || tileScript.gameModel[(ksor + a), (koszlop - b)] == "w2")
                        {
                            tileScript.tileS[((ksor + a) * 8) + (koszlop - b)] = "aa";
                        }

                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tileScript.gameModel[i, j] == "1")
                        tileScript.tileS[((i * 8) + j)] = "1";
                    if (tileScript.gameModel[i, j] == "k")
                        tileScript.tileS[((i * 8) + j)] = "2";
                }
            }
            tileScript.kiirMap();
        }
    }
    IEnumerator knightMove()
    {
            //Debug.Log("kx: " + knight.transform.position.x + "ky: " + knight.transform.position.y + "mx: " + mousex + "my: " + mousey);
            yield return new WaitForSeconds(0.5f);
        kpozi = int.Parse(whereToGo.Replace("simpleTile", ""));
        if (tileScript.tileS[kpozi] == "1")
        {
            koszlop = kpozi % 8;
            ksor = kpozi / 8;
            stats.GetComponent<Text>().text = stats.GetComponent<Text>().text + "\n Kinght moved to " + ksor + "," + koszlop;
            knight.transform.position = tileScript.tiles[kpozi].transform.position + new Vector3(0.2f, 0.3f, -0.16f);
            /*if (knight.transform.position.x < mousex)
            {
                knight.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (knight.transform.position.x > mousex)
            {
                knight.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (knight.transform.position.y < mousey)
            {
                knight.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (knight.transform.position.y > mousey)
            {
                knight.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (Mathf.Round(knight.transform.position.y) == Mathf.Round(mousey) && (Mathf.Round(knight.transform.position.x) == Mathf.Round(mousex)))
             {*/
            //Debug.Log("kposition:" + kposition);
            tileScript.tileS[kposition] = "0";
            //Debug.Log("oldksor" + oldksor+ " oldkoszlop" + oldkoszlop);
            tileScript.gameModel[oldksor, oldkoszlop] = "0";
            //Debug.Log("ksor" + ksor + " koszlop" + koszlop);
            //tileScript.ujraRajzolRegi(kposition);
            tileScript.gameModel[ksor, koszlop] = "k";
            //Debug.Log("kpozi " + kpozi );
            tileScript.tileS[kpozi] = "2";
                tileScript.ujraRajzolRegi(kposition);
                tileScript.ujraRajzol(kpozi);
                newposx = knight.transform.position.x;
                newposy = knight.transform.position.y;
                kmove = false;
                tileScript.round = 2;
           // }
        }
        }
        

public static void attackKnight(int pozi,string kit)
{
        int EnemyPozi = pozi;
        Debug.Log("kpozi " + pozi);
        Debug.Log("EnemyPozi " + EnemyPozi);
        if (tileScript.tileS[pozi + 1] == "1" || tileScript.tileS[pozi - 1] == "1" || tileScript.tileS[pozi + 8] == "1" || tileScript.tileS[pozi - 8] == "1")
    {
        if (tileScript.tileS[pozi + 1] == "1")
        {
            pozi += 1;
            knightScripts.koszlop = pozi % 8;
            knightScripts.ksor = pozi / 8;
            knightScripts.stats.GetComponent<Text>().text = knightScripts.stats.GetComponent<Text>().text + "\n Kinght moved to " + knightScripts.ksor + "," + knightScripts.koszlop;
            knightScripts.knight.transform.position = tileScript.tiles[pozi].transform.position + new Vector3(0.2f, 0.3f, -0.16f);
        }
        else if (tileScript.tileS[pozi - 1] == "1")
        {
            pozi -= 1;
            knightScripts.koszlop = pozi % 8;
            knightScripts.ksor = pozi / 8;
            knightScripts.stats.GetComponent<Text>().text = knightScripts.stats.GetComponent<Text>().text + "\n Kinght moved to " + knightScripts.ksor + "," + knightScripts.koszlop;
            knightScripts.knight.transform.position = tileScript.tiles[pozi].transform.position + new Vector3(0.2f, 0.3f, -0.16f);
        }
        else if (tileScript.tileS[pozi + 8] == "1")
        {
            pozi += 8;
            knightScripts.koszlop = pozi % 8;
            knightScripts.ksor = pozi / 8;
            knightScripts.stats.GetComponent<Text>().text = knightScripts.stats.GetComponent<Text>().text + "\n Kinght moved to " + knightScripts.ksor + "," + knightScripts.koszlop;
            knightScripts.knight.transform.position = tileScript.tiles[pozi].transform.position + new Vector3(0.2f, 0.3f, -0.16f);
        }
        else
        {
            pozi -= 8;
            knightScripts.koszlop = pozi % 8;
            knightScripts.ksor = pozi / 8;
            knightScripts.stats.GetComponent<Text>().text = knightScripts.stats.GetComponent<Text>().text + "\n Kinght moved to " + knightScripts.ksor + "," + knightScripts.koszlop;
            knightScripts.knight.transform.position = tileScript.tiles[pozi].transform.position + new Vector3(-0.2f, 0.3f, -0.16f);
        }
            Debug.Log("kpozi " + pozi);
            tileScript.tileS[kposition] = "0";
           // Debug.Log("oldksor" + oldksor+ " oldkoszlop" + oldkoszlop);
            tileScript.gameModel[oldksor, oldkoszlop] = "0";
           // Debug.Log("ksor" + ksor + " koszlop" + koszlop);
            //tileScript.ujraRajzolRegi(kposition);
            tileScript.gameModel[ksor, koszlop] = "k";
            //Debug.Log("kpozi " + pozi );
            tileScript.tileS[pozi] = "2";
            tileScript.ujraRajzolRegi(kposition);
            tileScript.ujraRajzol(pozi);
            newposx = knight.transform.position.x;
            newposy = knight.transform.position.y;
            //Debug.Log("w1 " + tileScript.slot8Coord + " w2 " + tileScript.slot9Coord+" targetp "+targetPos);
            if (kit=="w1")
            {
                int dmg = Random.Range(1, (4 * globalSlots.slot1I));
                int alive = 0;
                    if((globalSlots.slot8I*1)>dmg)
                {
                    if (((globalSlots.slot8I*1) - dmg)%1==0)
                        {
                        alive= ((globalSlots.slot8I * 1) - dmg) / 1;
                        }
                    else
                    {
                        alive = (((globalSlots.slot8I * 1) - dmg) / 1)+1;
                    }
                        stats.GetComponent<Text>().text = "\n Kinght attack Wolf1 and do " + dmg + " dmg \n and " + (globalSlots.slot8I - alive) + " die";
                    globalSlots.slot8I = alive;
                 }
                else
                {
                    tileScript.tileS[EnemyPozi] = "0";
                    Debug.Log("tileScript.tileS[EnemyPozi] " + tileScript.tileS[EnemyPozi]);
                    tileScript.gameModel[(EnemyPozi / 8), (EnemyPozi % 8)] = "0";
                    Debug.Log("tileScript.gameModel[(EnemyPozi % 8), (EnemyPozi / 8)] "+ tileScript.gameModel[(EnemyPozi % 8), (EnemyPozi / 8)]);
                    tileScript.kiirMap();
                    stats.GetComponent<Text>().text = "\n Kinght attack Wolf1 and do " + dmg + " dmg  \n and kill them";
                    wolftScript.wolf1Live = false;
                }
            }
            if (kit=="w2")
            {
                int dmg = Random.Range(1, (4 * globalSlots.slot1I));
                int alive = 0;
                    if((globalSlots.slot9I*1)>dmg)
                {
                    if (((globalSlots.slot9I*1) - dmg)%1==0)
                        {
                        alive= ((globalSlots.slot9I * 1) - dmg) / 1;
                        }
                    else
                    {
                        alive = (((globalSlots.slot9I * 1) - dmg) / 1)+1;
                    }
                        stats.GetComponent<Text>().text = "\n Kinght attack Wolf2 and do " + dmg + " dmg \n and " + (globalSlots.slot8I - alive) + " die";
                    globalSlots.slot9I = alive;
                }
                else
                {
                    tileScript.tileS[EnemyPozi] = "0";
                    tileScript.gameModel[(EnemyPozi / 8), (EnemyPozi % 8)] = "0";
                    stats.GetComponent<Text>().text = "\n Kinght attack Wolf2 and do " + dmg + " dmg \n and kill them";
                    wolftScript.wolf2Live = false;
                }
            }
            kmove = false;
            tileScript.round = 2;
        }
    }
}


