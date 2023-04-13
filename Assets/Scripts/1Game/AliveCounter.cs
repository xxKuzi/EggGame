using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AliveCounter : MonoBehaviour
{
    static PlayerCollision playerCollision;
    static TextMeshProUGUI counterText;
    private void Start()
    {
        playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
        counterText = GameObject.FindGameObjectWithTag("AliveCounter").GetComponent<TextMeshProUGUI>();
        
    }
    public static void SetDisactive()
    {
        counterText.gameObject.SetActive(false);
    }
    public static IEnumerator TimeToStart()
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
