using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundSettings : MonoBehaviour
{
    [SerializeField] Transform player;    
    private BoxCollider2D bc;

    
    

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
        
        
    }

    void Update()
    {
       
        if(transform.position.y + 1 < player.transform.position.y && bc.isTrigger == true)
        {
            bc.isTrigger = false;
            
           
        }
        if (transform.position.y +0.60 > player.transform.position.y && bc.isTrigger == false)
        {
            bc.isTrigger = true;
            

        }
        

    }
      
    
}
