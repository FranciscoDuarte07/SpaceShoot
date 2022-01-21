using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyExpPrefab;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private AudioClip audioClip;

    private UIManager uiManager;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7f)
        {
            float randomX = Random.Range(-7.5f, 7.5f);
            transform.position = new Vector3(randomX, 7f, 0);              
        }
    }

    //Destroy enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            if (collision.transform.parent != null)
            {
                Destroy(collision.transform.parent.gameObject);
            } 
            Destroy(collision.gameObject);
            Instantiate(enemyExpPrefab, transform.position, Quaternion.identity);
            uiManager.UpdateScore();
            //Play expltion sound
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
        }
        Instantiate(enemyExpPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
        Destroy(this.gameObject);
    }
}
