using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    
    Rigidbody2D rb;
    [SerializeField] GameObject player;
    float moveX;
    float moveSpeed = 20f;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveX = Input.acceleration.x * moveSpeed;
        

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX, 0f);
        
    }
}
