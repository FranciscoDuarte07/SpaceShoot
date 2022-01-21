using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isCoopMode = false;
    public bool gameOver;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject coopPlayers;
    [SerializeField]
    private GameObject pauseMenuPanel;

    private UIManager uiManager;
    private SpawnManager spawnManager;
    //private Animator pauseAnimator; (Solucionar)

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        //pauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>(); (Solucionar)
        //animator ignore the scale time
        //pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime; (Solucionar)
    }

    private void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(isCoopMode == false)
                {
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Instantiate(coopPlayers, Vector3.zero, Quaternion.identity);
                }
                gameOver = false;
                uiManager.HideTitleScreen();
                spawnManager.StartSpawn();
            }
            //Instantiate Main Menu
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Menu");
            }
        }
        //Pause Game
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenuPanel.SetActive(true);
            //pauseAnimator.SetBool("IsPaused", true); (solucionar)
            Time.timeScale = 0f;
        }
    }
    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
