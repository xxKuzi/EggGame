using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AliveCounter : MonoBehaviour
{
    [SerializeField] PlayerCollision playerCollision;
    [SerializeField] TextMeshProUGUI counterText;
    

    private void Awake()
    {
        SetDisactive();
    }

    public void SetDisactive()
    {
        counterText.gameObject.SetActive(false);
        
    }
    
    public IEnumerator TimeToStart()
    {
        
        counterText.gameObject.SetActive(true);
        
        int counter = 3;

        counterText.text = "" + counter;
        counter--;
        yield return new WaitForSeconds(1);
        counterText.text = "" + counter;
        counter--;
        yield return new WaitForSeconds(1);
        counterText.text = "" + counter;
        counter--;
        yield return new WaitForSeconds(1);
        
        playerCollision.Alive();
        counterText.gameObject.SetActive(false);
        yield break;
        
    }
}
