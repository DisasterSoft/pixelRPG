using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class zombieMove : MonoBehaviour
{

    public GameObject zombieObj;
    public bool zombieWalk = false;
    void Update()
    {
        if (!zombieWalk)
        {
            StartCoroutine(gozombie());
        }


    }
    IEnumerator gozombie()
    {
        zombieWalk = true;
        zombieObj.transform.Translate(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
        yield return new WaitForSeconds(1);
        zombieWalk = false;

    }
}
    
