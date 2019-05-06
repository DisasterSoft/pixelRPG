using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTileClick : MonoBehaviour
{
   
    private void OnMouseUp()
    {
        
        if (globalSlots.oneSelected)
        {
            battleScript.whereTogo=this.name;
            battleScript.moved = true;    
           
        }
        if (globalSlots.twoSelected)
        {
            battleScript.whereTogo=this.name;
            battleScript.moved = true;    
           
        }
    }
}
