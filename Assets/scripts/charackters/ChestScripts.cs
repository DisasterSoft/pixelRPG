using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ChestScripts : MonoBehaviour
{
    public GameObject goldPlus;
    public Flowchart flowchart;

    void OnTriggerEnter2D(Collider2D other)
    {
        goldPlus.SetActive(true);
       
        if (this.name == "chest1")
        {
            flowchart.SendFungusMessage("chest1");
            globalVariable.addObjectToList("chest1");
        }
        if (this.name == "chest2")
        {
            flowchart.SendFungusMessage("chest2");
            globalVariable.addObjectToList("chest2");
        }
        if (this.name == "barrel1")
        {
            flowchart.SendFungusMessage("barrel1");
            globalVariable.addObjectToList("barrel1");
        }
        StartCoroutine(endGoldAnimation());

    }
    IEnumerator endGoldAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        goldPlus.GetComponent<Animation>().Play("gold+");
        yield return new WaitForSeconds(2);
        goldPlus.SetActive(false);

    }
}
