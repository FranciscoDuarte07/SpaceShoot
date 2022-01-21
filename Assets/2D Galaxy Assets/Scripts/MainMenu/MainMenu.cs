using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LoadSinglePlayerMode() 
    {
        SceneManager.LoadScene("Single_Player");
    }

    public void LoadCoOpMode()
    {
        SceneManager.LoadScene("Coop_Mode");
    }
}
