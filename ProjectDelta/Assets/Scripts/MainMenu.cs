using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   void Start()
   {
      Time.timeScale= 1f; 
   }
   public void PlayGame()
   {
    SceneManager.LoadScene(1); 

   }

   public void QuitGame()
   {
    Debug.Log("QuitGame");
        Application.Quit();
   }
}
