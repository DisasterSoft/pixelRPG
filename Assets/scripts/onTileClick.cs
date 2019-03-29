using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTileClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (globalSlots.oneSelected)
        {
            if(knightScripts.selected)
            {
               
                knightScripts.kmove = true;
                knightScripts.mousex= (GameObject.Find(this.name).transform.position.x)+ 0.2f;
                knightScripts.mousey= (GameObject.Find(this.name).transform.position.y)+0.3f;
            }
        }
    }
}
