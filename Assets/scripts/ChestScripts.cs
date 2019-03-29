using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ChestScripts : MonoBehaviour
{


    
    public GameObject goldPlus;
    public Flowchart flowchart;
    public void Start()
    {
       

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        goldPlus.SetActive(true);
        flowchart.SendFungusMessage("chest1");
        StartCoroutine(endGoldAnimation());

    }
    IEnumerator endGoldAnimation()
    {
        yield return new WaitForSeconds(1);
        goldPlus.GetComponent<Animation>().Play("gold+");
        yield return new WaitForSeconds(2);
        goldPlus.SetActive(false);

    }
}
