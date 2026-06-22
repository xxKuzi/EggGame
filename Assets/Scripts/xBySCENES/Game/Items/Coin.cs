using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    bool coinMove;
    [SerializeField] private bool coinRotate = true;
    [SerializeField] Transform player;
    float moveSpeed = 15f; //TRY WITHOUT F
    
    
    [SerializeField] float xRotation;
    
    private void Update()
    {
        if(coinMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

        if (coinRotate)
        {
            transform.Rotate(0, xRotation * Time.deltaTime, 0);    
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Coin Detector")
        {
            coinMove = true;            
        }

    }
}
