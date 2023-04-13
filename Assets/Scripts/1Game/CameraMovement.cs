using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform camera1;
    [SerializeField] Transform background;
    int offset = 10;
    float highestPosition;



    void Update()
    {

        if (player.transform.position.y > highestPosition)
        {
            Debug.Log("player transform position:" + player.transform.position.y + "Highest Position: " + highestPosition); //TRY without transform 
            background.transform.position = new Vector2(0, player.transform.position.y);
            camera1.transform.position = new Vector3(0, player.transform.position.y, -offset);
            highestPosition = player.transform.position.y;
        }



    }

}
