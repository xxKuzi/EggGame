using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinNames : MonoBehaviour
{
    private SkinNames Instance;
    static public List<string> skin = new List<string>(new string[15]);

    private void Awake()
    {
        skin[0] = "white";
        skin[1] = "brown";
        skin[2] = "colored";
        skin[3] = "star";
        skin[4] = "star2";
    }
}

