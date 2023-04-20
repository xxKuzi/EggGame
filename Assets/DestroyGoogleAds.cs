using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyGoogleAds : MonoBehaviour
{
    [SerializeField] private GameObject googleAds;

    private void Start()
    {
        Invoke("secondStart", 1);
    }

    void secondStart()
    {
        Destroy(googleAds.GameObject());
    }
}
