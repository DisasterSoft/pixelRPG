using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class knightScripts : MonoBehaviour
{
    Animator anim;
    public Flowchart flowchart;
    public GameObject stats,knight;
    public int kposition = 0;
    public int ksor = 0;
    public int koszlop = 0;
    public int lepes = 3;
    public static  bool selected = false;
    public static bool kmove = false;
    public bool kmove1 = false;
    public static float mousex;
    public static float mousey;
    public float  speed=1f;
    public float newposx, newposy,mposx,mposy;
    // Start is called before the first frame update
    void Start()
    {
        newposx = knight.transform.position.x;
        newposy = knight.transform.position.y;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        kmove1 = kmove;
        if (kmove)
        {
            mposx = mousex;
            mposy = mousey;
            anim.SetBool("knight1Idle", false);
            anim.SetBool("knight1Walk", true);
            StartCoroutine(knightMove());
        }
        else
        {
            anim.SetBool("knight1Idle", true);
            anim.SetBool("knight1Walk", false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      
        flowchart.SendFungusMessage("knight1");
       
    }
    private void OnMouseUp()
    {
        globalSlots.oneSelected = true;
        stats.GetComponent<Text>().text = "Knight\nHP: 3 (*" + globalSlots.slot1I + ")\nDMG: 4 (*" + globalSlots.slot1I + ")";
        selected = true;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(tileScript.gameModel[i,j]=="k")
                {
                    kposition = (i*8)+j;
                }
            }
        }
       koszlop = kposition % 8;
       ksor = kposition / 8;
        
                for (int a = 0; a < (lepes+1); a++)
                {
                for (int b = 0; b < (lepes+1); b++)
            {
                if (((koszlop + b) < 8) && ((ksor + a) < 8))
                {
                    if (tileScript.gameModel[(ksor + a), (koszlop + b)] == "0")
                    {
                        tileScript.gameModel[(ksor + a), (koszlop + b)] = "1";
                    }
                }
                if (((koszlop + b) < 8) && ((ksor - a) > 0))
                {
                    if (tileScript.gameModel[(ksor - a), (koszlop + b)] == "0")
                    {
                        tileScript.gameModel[(ksor - a), (koszlop + b)] = "1";
                    }
                }
                if (((koszlop - b) > 0) && ((ksor - a) > 0))
                {
                    if (tileScript.gameModel[(ksor - a), (koszlop - b)] == "0")
                    {
                        tileScript.gameModel[(ksor - a), (koszlop - b)] = "1";
                    }
                }
                if (((koszlop - b) > 0) && ((ksor + a) < 8))
                {
                    if (tileScript.gameModel[(ksor + a), (koszlop - b)] == "0")
                    {
                        tileScript.gameModel[(ksor + a), (koszlop - b)] = "1";
                    }
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(tileScript.gameModel[i,j]=="1")
                    tileScript.tileS[((i*8)+j)] = "1";
               
            }
        }
        
    }
    IEnumerator knightMove()
    {
        
        //Debug.Log("kx: " + knight.transform.position.x + "ky: " + knight.transform.position.y + "mx: " + mousex + "my: " + mousey);
        yield return new WaitForSeconds(0.3f);
        if (knight.transform.position.x<mousex)
        {
            knight.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (knight.transform.position.x > mousex)
        {
            knight.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (knight.transform.position.y<mousey)
        {
            knight.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (knight.transform.position.y > mousey)
        {
            knight.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if(Mathf.Round(knight.transform.position.y)==Mathf.Round(mousey) && (Mathf.Round(knight.transform.position.x)==Mathf.Round(mousex)))
            {
            tileScript.ujraRajzolRegi(kposition);
            kposition += Mathf.RoundToInt(newposx - mousex)+(Mathf.RoundToInt(newposy - mousey)*7);
            tileScript.ujraRajzol(kposition);
            newposx = knight.transform.position.x;
            newposy = knight.transform.position.y;
            tileScript.kiirMap();
            kmove = false;
        }
        }
   
}
