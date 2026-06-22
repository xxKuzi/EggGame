using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinMenuOpenClose : MonoBehaviour
{
   [SerializeField] private GameObject skinMenu; 
   [SerializeField] private GameObject blur;
   [SerializeField] private SkinSelect skinSelect;

   private void Start()
   {
      skinMenu.SetActive(false);
      blur.SetActive(false);
   }

   public void CloseMenuNoSound()
   {
      skinSelect.UpdateSkin();
      skinMenu.SetActive(false);
      blur.SetActive(false);
   }
   public void CloseMenu()
   {
      Sound();
      skinSelect.UpdateSkin();
      skinMenu.SetActive(false);
      blur.SetActive(false);
   }

   public void OpenMenu()
   {
      Sound();
      skinMenu.SetActive(true);
      blur.SetActive(true);
   }

   void Sound()
   {
      AudioManager.Instance.Play("Button");
   }
}
