using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hScore;
    private void Update()
    {
        hScore.text = "Highest Score: " + PlayerPrefs.GetFloat("score");
    }
}


