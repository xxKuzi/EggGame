using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionScale : MonoBehaviour
{
   private float Scale;
       

       private void Awake()
       {
           Scale = (1280f/720f) / ((float)Screen.height / (float)Screen.width);
           PlayerPrefs.SetInt("scale", (int)Scale);
       }

       private void Update()
       {
           Debug.Log(Scale);
       }
}
