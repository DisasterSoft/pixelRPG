using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class wolftScript : MonoBehaviour
{
    Animator anim;
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("wolt1",true); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      
        flowchart.SendFungusMessage("wolf1");
       
    }
}
