using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] GameObject player;
    [HideInInspector] public Rigidbody2D rb;
    float jumpForce = 25;
    float defJumpForce;    
    [HideInInspector] public float defGravitation = 40;
    private float move;
    [HideInInspector] public float gravity;
    bool isJump = false;
    int timeForceJump = 5;
    [HideInInspector] public int shoeActive = 0;
    [SerializeField] GameObject shoes;
    [SerializeField] public GameObject coinDetector;
    [SerializeField] public GameObject playerMagnet;
    int timeMagnet = 10;
    int magnetActive = 0;
    float moveSpeed = 20;
    [HideInInspector] public float moveX;
    private float sideDistance;

    
    
    






    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        gravity = -defGravitation;
        shoes.SetActive(false);
        defJumpForce = jumpForce;
        coinDetector.SetActive(false);
        playerMagnet.SetActive(false);
        Application.targetFrameRate = 60;




        sideDistance = PlayerPrefs.GetInt("scale") * 5.2f;




    }
    private void FixedUpdate()
    {
        //move = Input.GetAxis("Horizontal");
        moveX = Input.acceleration.x * moveSpeed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }
    void Update()
    {
        
        
        
        
        /*Input.GetKeyDown(KeyCode.Space) &&*/
        if (isJump == false)
        {
            Jump();
            isJump = true;
        }
        
        Physics2D.gravity = new Vector2(0, gravity);        

        

        if (-sideDistance  > transform.position.x)
        {
            player.transform.position = new Vector2(sideDistance, transform.position.y);
        }

        if (transform.position.x > sideDistance)
        {
            player.transform.position = new Vector2(-sideDistance, transform.position.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
 
        }
        if (collision.gameObject.CompareTag("Trampoline"))
        {

            AudioManager.Instance.Play("Trampoline");
            jumpForce = 50;
            Jump();
            
            Invoke("NormalGravity", 0.5f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.CompareTag("Shoe"))
        {
            AudioManager.Instance.Play("Shoes");
            Destroy(collision.gameObject);           
            StartCoroutine(ShoesActive());                       
            
        }
        if (collision.gameObject.CompareTag("Magnet"))
        {
            AudioManager.Instance.Play("Magnet");
            StartCoroutine(ActiveDetector());            
            Destroy(collision.gameObject);

        }
        

    }

    //FUNCTIONS   / BETTER NAME HERE
    

    public void NormalGravity()
    {        
        gravity = -defGravitation;
        jumpForce = defJumpForce;
    }
    void JumpBoost()
    {        
        jumpForce = defJumpForce * 2;
        shoes.SetActive(true);
    }

    public void JumpBoostOff()
    {
        gravity = -defGravitation;
        jumpForce = defJumpForce;
        shoes.SetActive(false);
        
    }
    void Jump()
    {
        AudioManager.Instance.Play("Jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }  
    IEnumerator ShoesActive()
    {
        shoeActive++;
        JumpBoost();
        yield return new WaitForSeconds(timeForceJump);
        if(shoeActive == 2) { yield return new WaitForSeconds(timeForceJump); }
        JumpBoostOff();
        shoeActive = 0;
        
    }
    IEnumerator ActiveDetector()
    {
        magnetActive++;
        playerMagnet.SetActive(true);
        coinDetector.SetActive(true);

        yield return new WaitForSeconds(15f);
        if (magnetActive == 2) { yield return new WaitForSeconds(timeMagnet); }


        coinDetector.SetActive(false);
        playerMagnet.SetActive(false);
        magnetActive = 0;

    }
    
   


}

