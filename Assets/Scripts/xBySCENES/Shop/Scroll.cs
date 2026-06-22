using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//idk
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    

    public Scrollbar scrollBar;
    public Button increaseButton;
    public Button decreaseButton;
    public float Step = 0.1f;

    private void Update()
    {
        //Debug.Log(scrollBar.value);
    }
    public void Free()
    {
        scrollBar.value = 1;
    }

    public void SpecialOffer()
    {

        Debug.Log(PlayerPrefs.GetInt("scale"));
        scrollBar.value = 0.585f/(float)PlayerPrefs.GetInt("scale");
        //scrollBar.value = Mathf.Clamp(scrollBar.value - Step, 0, 1);
        /*GetComponent<Button>().interactable = scrollBar.value != 0;
        decreaseButton.interactable = true;*/
    }
}
