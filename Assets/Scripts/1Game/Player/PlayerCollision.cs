using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{

    float score;
    int coins;
    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Transform coin;
    [SerializeField] Transform player;
    [SerializeField] Transform camera1;
    [SerializeField] Transform background;
    [SerializeField] Button bPause;
    [SerializeField] Button bResume;
    [SerializeField] Button bExit;
    [SerializeField] Button bAlive;
    [SerializeField] Transform safePlace;
    public PlayerMovement playerMovement;
    [SerializeField] Buttons buttonsScript;
    [SerializeField] Transform deathMenu;
    [SerializeField] TextMeshProUGUI deathTimer;
    int secondsRemain;
    int defSecondRemain = 3;
    bool allowDeath = true;

    public PopUp popUpScript;

    int offset = 10;
    float highestPosition = -2;
    bool cameraMove = true;

    private void Start()
    {
        AliveCounter.SetDisactive();
        popUpScript.CloseAtStart();
        secondsRemain = defSecondRemain;
        bResume.gameObject.SetActive(false);
        bExit.gameObject.SetActive(false);        
        safePlace.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (cameraMove)
        {
            if (player.transform.position.y > highestPosition)
            {

                background.transform.position = new Vector2(0, player.transform.position.y - 2);
                camera1.transform.position = new Vector3(0, player.transform.position.y - 2, -offset);
                highestPosition = player.transform.position.y;
            }
            if (player.transform.position.y + 8.18 + 2 < highestPosition)
            {
                Paralyzed();
            }
            if (player.transform.position.y + 8.18 + 2 + 2 < highestPosition)
            {
                Die();
                
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            if (transform.position.y > score)
                score = Mathf.RoundToInt(player.position.y);
            scoreText.text = "Score: " + score;

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            SoundManager.Instance.Play("coin");
            GetCoin();
            Destroy(collision.gameObject);
        }

    }
    void GetCoin()
    {
        coins++;
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
        coinsText.text = "Coins: " + coins;
    }
    void Paralyzed()
    {        
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
    void Die()
    {
        SoundManager.Instance.Play("death");
        cameraMove = false;
        if (score > PlayerPrefs.GetFloat("score")) { PlayerPrefs.SetFloat("score", score); }
        
        
        playerMovement.moveX = 0;
        playerMovement.rb.velocity = new Vector2(0, 0);
        this.GetComponent<PlayerMovement>().enabled = false;
 


        DeathReset();
        deathMenu.gameObject.SetActive(true);
        deathTimer.text = "" + secondsRemain;
        StartCoroutine(Dying());
        

    }
    
   IEnumerator Dying()
    {
        yield return new WaitForSeconds(1);
        secondsRemain--;
        deathTimer.text = "" + secondsRemain;
        
        StartCoroutine(Dying2());

        
    }
    IEnumerator Dying2()
    {
        yield return new WaitForSeconds(1);
        secondsRemain--;
        deathTimer.text = "" + secondsRemain;
        
        StartCoroutine(Dying3());
    }

    IEnumerator Dying3()
    {
        yield return new WaitForSeconds(1);
        secondsRemain--;
        deathTimer.text = "" + secondsRemain;
        

        if (allowDeath) { Exit(); }

    }

    public void Exit()
    {
        buttonsScript.ExitGameNoSoundAd(); 
    }



    public void Pause()
    {

        ButtonSound();
        playerMovement.gameObject.SetActive(false);
        bPause.gameObject.SetActive(false);
        bResume.gameObject.SetActive(true);
        bExit.gameObject.SetActive(true);
        if (score > PlayerPrefs.GetFloat("score")) PlayerPrefs.SetFloat("score", score);

        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
        


    }
    public void Resume()
    {
        ButtonSound();
        playerMovement.gameObject.SetActive(true);
        bPause.gameObject.SetActive(true);
        bResume.gameObject.SetActive(false);
        bExit.gameObject.SetActive(false);

        GetComponent<BoxCollider2D>().isTrigger = false;
        GetComponent<Rigidbody2D>().isKinematic = false;

    }
    void DeathReset()
    {
        allowDeath = true;
        secondsRemain = defSecondRemain;
    }
    public void AliveButton()
    {
        ButtonSound();
        deathMenu.gameObject.SetActive(false);
        allowDeath = false;

        if (PlayerPrefs.GetInt("coins") < 5)
        {
            popUpScript.LowMoneyGame();
        }
        else
        {
            coins -= 5;
            coinsText.text = "Coins: " + coins;
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 5);
            StartCoroutine(AliveCounter.TimeToStart());
            ButtonSound();

            
            
            background.transform.position = new Vector2(0, score);
            camera1.transform.position = new Vector3(0, score, -offset);
            highestPosition = score;

            ResetBoosts();
            safePlace.gameObject.SetActive(true);

            cameraMove = true;
            safePlace.gameObject.transform.position = new Vector2(0, score);
            gameObject.transform.position = new Vector2(0, score + 3f);

        }

    }    
    public void Alive()
    {

        this.GetComponent<PlayerMovement>().enabled = true;

    }

   

    void ResetBoosts()
    {
        playerMovement.NormalGravity();
        playerMovement.JumpBoostOff();

        playerMovement.coinDetector.SetActive(false);
        playerMovement.playerMagnet.SetActive(false);

        playerMovement.shoeActive = 0;
    }    
    void ButtonSound()
    {
        SoundManager.Instance.Play("button");
    }
    

    
    
}
