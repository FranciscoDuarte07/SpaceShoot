using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool tripleShot = false;
    public bool speedBoost = false;
    public bool shield = false;
    public bool isPlayerOne = false;
    public bool isPlayerTwo = false;

    public int lives = 3;

    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private GameObject tripleLaser;

    [SerializeField]
    private float speed = 10f;
    
    [SerializeField]
    private float fireRate = 0.25f;
    private float nextFire = 0.0f;

    [SerializeField]
    private GameObject PlayerExpPrefab;
    [SerializeField]
    private GameObject shields;
    private UIManager uiManager;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private AudioSource audioSource;

    [SerializeField]
    private GameObject[] engine;

    private int hitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (uiManager != null)
        {
            uiManager.UpdateLives(lives);
        }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        /*if (spawnManager != null)
        {
            spawnManager.StartSpawn();
        }*/

        audioSource = GetComponent<AudioSource>();

        hitCount = 0;

        if (gameManager.isCoopMode == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOne == true)
        {
            Movement();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0) && isPlayerOne == true)
            {
                LaserShoot();
            }
        }
        //spwan laser

        if (isPlayerTwo == true)
        {
            MovementPlayerTwo();
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                LaserShoot();
            }
        }


    }

    private void LaserShoot()
    {
       //cooldown and instantiate
       if (Time.time > nextFire)
       {
            //play laser sound
            audioSource.Play();
            if (tripleShot == true)
            {
                Instantiate(tripleLaser, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laser, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            }
            nextFire = Time.time + fireRate;
        }
    }

    private void Movement()
    {
        //player move
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Enable or Disable SpeedBoost
        if (speedBoost == true)
        {
            transform.Translate(Vector3.right * speed * 1.5f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * 1.5f * verticalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        }         

        //player limit
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
    }
    
    //Player 2 movement
    private void MovementPlayerTwo()
    {

        //player move
        if (Input.GetKey(KeyCode.Keypad8))
        {
            transform.Translate(Vector3.up * speed * 0.5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.Translate(Vector3.right * speed * 0.5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.Translate(Vector3.left * speed * 0.5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            transform.Translate(Vector3.down * speed * 0.5f * Time.deltaTime);
        }

        //Enable or Disable SpeedBoost
        if (speedBoost == true)
        {
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector3.up * speed * 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector3.right * speed * 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Translate(Vector3.left * speed * 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                transform.Translate(Vector3.down * speed * 1.5f * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector3.up * speed * 0.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector3.right * speed * 0.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Translate(Vector3.left * speed * 0.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                transform.Translate(Vector3.down * speed * 0.5f * Time.deltaTime);
            }
        }

        //player limit
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
    }

    private void LaserShootPlayerTwo()
    {
        //cooldown and instantiate
        if (Time.time > nextFire)
        {
            //play laser sound
            audioSource.Play();
            if (tripleShot == true)
            {
                Instantiate(tripleLaser, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laser, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            }
            nextFire = Time.time + fireRate;
        }
    }

    public void Damage()
    {
        //shield active = no damage
        if (shield == true)
        {
            shield = false;
            shields.gameObject.SetActive(false);
        }
        else
        {

            hitCount++;

            //failure engine active
            if (hitCount == 1)
            {
                engine[0].SetActive(true);
            }
            else if (hitCount == 2)
            {
                engine[1].SetActive(true);
            }

            lives--;
            uiManager.UpdateLives(lives);
            if (lives < 1)
            {
                Instantiate(PlayerExpPrefab, transform.position, Quaternion.identity);
                gameManager.gameOver = true;
                uiManager.CheckForBestScore();
                uiManager.ShowTitleScreen();
                Destroy(this.gameObject);
            }
        }
    }

    public void TripleShotOn()
    {
        tripleShot = true;
        StartCoroutine(TripleShotPowerDown());
    }

    //Courtine
    public IEnumerator TripleShotPowerDown()
    {
        //PowerUp time down
        yield return new WaitForSeconds(5.0f);
        tripleShot = false;
    }

    public void SpeedBoostOn()
    {
        speedBoost = true;
        StartCoroutine(SpeedBoostDown());
    }

    //Courtine
    public IEnumerator SpeedBoostDown()
    {
        //PowerUp time down
        yield return new WaitForSeconds(5.0f);
        speedBoost = false;
    }

    public void ShieldOn()
    {
        shield = true;
        shields.gameObject.SetActive(true);
    }
}
