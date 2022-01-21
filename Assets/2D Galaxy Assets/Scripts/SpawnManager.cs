using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerUps;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(EnemySpawn());
        StartCoroutine(PoweUpSpawn());
    }

    //Spawn enemies and PU after the start the game
    public void StartSpawn()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PoweUpSpawn());
    }

    //Spawn random enemy
    public IEnumerator EnemySpawn()
    {
        while (gameManager.gameOver == false)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    //Spawn random Power ups
    public IEnumerator PoweUpSpawn()
    {
        while (gameManager.gameOver == false)
        {
            int powerUpValue = Random.Range(0, 3);
            Instantiate(powerUps[powerUpValue], new Vector3(Random.Range(-7.5f, 7.5f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
