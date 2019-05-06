using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : MonoBehaviour
{
    public GameObject chickenObj;
    public bool chickenWalk = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!chickenWalk)
        {
            StartCoroutine(goChicken());
        }

        
    }
    IEnumerator goChicken()
    {
        chickenWalk = true;
        chickenObj.transform.Translate(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
        yield return new WaitForSeconds(1);
        
        chickenWalk = false;

    }
}
