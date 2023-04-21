using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private GameObject dia;
    [SerializeField] private GameObject specialCoin;
    [SerializeField] private GameObject droppingCoin;
    [SerializeField] Transform player;
    [SerializeField] Transform camera1;
    [SerializeField] Transform background;
    [SerializeField] Button bPause;
    [SerializeField] Button bResume;
    [SerializeField] Button bExit;
    [SerializeField] Button bAlive;
    [SerializeField] Transform safePlace;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private AliveCounter aliveCounter;
    [SerializeField] Buttons buttonsScript;
    [SerializeField] Transform deathMenu;
    [SerializeField] TextMeshProUGUI deathTimer;
    [SerializeField] private GameObject circleTimer;
    [SerializeField] private TextMeshProUGUI alivePriceText;
    private int aliveButtonClicked;
    private int alivePrice = 5;
    int secondsRemain;
    int defSecondRemain = 3;
    bool allowDeath = true;
    Vector2 diaPosition;
    private Vector2 droppingCoinPosition;
    private int diaSpawnFrequency;
    private int diaSpawnCounter;
    private int diaRandomCounter;
    private int droppingCoinCounter;

    public PopUp popUpScript;

    int offset = 10;
    float highestPosition = -2;
    bool cameraMove = true;

    private void Start()
    {
        popUpScript.CloseAtStart();
        secondsRemain = defSecondRemain;
        bResume.gameObject.SetActive(false);
        bExit.gameObject.SetActive(false);        
        safePlace.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(false);
        circleTimer.gameObject.SetActive(false);
        RefreshAlivePriceText();
        DiaSpawnReset();
        
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
            GetCoin("normal");
            Destroy(collision.gameObject);
            
            //DIA SPAWNING
            diaSpawnCounter++;

            if (diaSpawnCounter == diaSpawnFrequency)
            {
                Spawn("dia");
                DiaSpawnReset();
            }

        }

        

        if (collision.gameObject.CompareTag("SpecialCoin"))
        {
            Spawn("droppingCoin");
            GetCoin("normal");
            Destroy(collision.gameObject);
            droppingCoinCounter++;
        }

        if (collision.gameObject.CompareTag("DroppingCoin"))
        {
            Destroy(collision.gameObject);
            GetCoin("normal");

            droppingCoinCounter++;
            if (droppingCoinCounter <= 5)
            {
                Spawn("droppingCoin");
            }
            else
            {
                droppingCoinCounter = 0;
            }
            
        }
        
        
        if (collision.gameObject.CompareTag("Dia"))
        {
            SoundManager.Instance.Play("dia");
            GetDia();
            Destroy(collision.gameObject);
        }

        

    }
    
    private void DiaSpawnReset()
    {
        diaSpawnFrequency = Random.Range(1, 3) + Random.Range(1, 3) + Random.Range(1, 4);
        diaSpawnCounter = 0;
    }
    void GetCoin(string property)
    {
        switch (property)
        {
            case ("normal"):
                coins++;
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
                coinsText.text = "Coins: " + coins;
                break;

            case ("special"):
                coins += 3;
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 3);
                coinsText.text = "Coins: " + coins;
                break;
        }

    }
    void GetDia()
    {
        PlayerPrefs.SetInt("Dia", PlayerPrefs.GetInt("dia") + 1);
    }

    void Spawn(string thing)
    {
        switch (thing)
        {
            case ("droppingCoin"):
            {
                float xSpawnpostion = player.position.x + Random.Range(-3, 3);
                bool inRange = Enumerable.Range(-3, 3).Contains((int)xSpawnpostion);
                while (inRange == false)
                {
                    xSpawnpostion = player.position.x + Random.Range(-3, 3);
                    inRange = Enumerable.Range(-3, 3).Contains((int)xSpawnpostion);
                }
                
                
                
                droppingCoinPosition = new Vector2(xSpawnpostion, player.position.y + 10);
                Instantiate(droppingCoin, droppingCoinPosition, Quaternion.identity);
                
                break;
            }
            
            
            case ("dia"):
            {
                diaPosition = new Vector2(player.position.x, player.position.y + 10);
                Instantiate(dia, diaPosition, Quaternion.identity);        
                
                break;
            }
            
        }
        
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
        circleTimer.gameObject.SetActive(true);
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
        circleTimer.gameObject.SetActive(false);
        allowDeath = false;

        if (PlayerPrefs.GetInt("coins") < alivePrice)
        {
            popUpScript.LowMoneyGame();
        }
        else
        {
            coins -= alivePrice;
            coinsText.text = "Coins: " + coins;
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - alivePrice);
            StartCoroutine(aliveCounter.TimeToStart());
            ButtonSound();
            AlivePriceChange();

            
            
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

    private void AlivePriceChange()
    {
        alivePrice = alivePrice * 2;
        RefreshAlivePriceText();
    }

    private void RefreshAlivePriceText()
    {
        alivePriceText.text = alivePrice.ToString();
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
