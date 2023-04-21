using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerFloor : MonoBehaviour
{
    [SerializeField] int numberOfFloor = 1;
    int touches;
    [SerializeField] Sprite skinNormal;
    [SerializeField] Sprite skinLight;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skinNormal;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            if (numberOfFloor == 1)
            {
                touches += 1;
                if (touches == 1)
                {
                    //GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .8f);
                    GetComponent<SpriteRenderer>().sprite = skinNormal;

                }
                if (touches == 2)
                {
                    GetComponent<SpriteRenderer>().sprite = skinLight;
                }

                if (touches == 3)
                {

                    Destroy(gameObject);
                }
            }
            if (numberOfFloor == 2)
            {
                touches += 1;
                if (touches == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = skinLight;

                }

                if (touches == 2)
                {
                    Invoke("Destroy", 0.1f);
                }
            }

        }

    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
