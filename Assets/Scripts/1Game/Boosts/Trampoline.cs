using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] Transform player;
    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void Update()
    {
         if (player.position.y - 1f > transform.position.y)
             {
                 GetComponent<BoxCollider2D>().isTrigger = false;
             }

        if (player.position.y < transform.position.y)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    
}

