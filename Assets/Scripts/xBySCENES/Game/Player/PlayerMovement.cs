using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] GameObject player;
    public Rigidbody2D rb;

    
    float jumpForce = 25;
    float defJumpForce;    
    public float defGravitation = 40;
    private float move;
    public float gravity;
    bool isJump = false;

    [SerializeField] Transform egg;
    int timeForceJump = 5;
    public int shoeActive = 0;

    public PlayerCollision playerCollision;

    [SerializeField] GameObject shoes;

    [SerializeField] public GameObject coinDetector;
    [SerializeField] public GameObject playerMagnet;

    int timeMagnet = 10;
    int magnetActive = 0;

    float moveSpeed = 20;
    public float moveX;

    
    private float sideDistance;
    






    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        gravity = -defGravitation;
        shoes.SetActive(false);
        defJumpForce = jumpForce;
        egg.GetComponent<SpriteRenderer>().enabled = false;
        coinDetector.SetActive(false);
        playerMagnet.SetActive(false);
        Application.targetFrameRate = 60;
        



        sideDistance = PlayerPrefs.GetInt("scale") * 5.2f;




    }
    private void FixedUpdate()
    {
        moveX = Input.acceleration.x * moveSpeed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }
    void Update()
    {
        

        /*move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);*/

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

            SoundManager.Instance.Play("trampoline");
            jumpForce = 50;
            Jump();
            
            Invoke("NormalGravity", 0.5f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.CompareTag("Shoe"))
        {
            SoundManager.Instance.Play("shoes");
            Destroy(collision.gameObject);           
            StartCoroutine(ShoesActive());                       
            
        }
        if (collision.gameObject.CompareTag("Magnet"))
        {
            SoundManager.Instance.Play("magnet");
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
        SoundManager.Instance.Play("jump");
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

