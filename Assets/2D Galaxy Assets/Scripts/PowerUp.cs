using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float powerUpID;

    [SerializeField]
    private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.name);

        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                if (powerUpID == 0)
                {
                    //Enable triple Shot
                    player.TripleShotOn();
                }
                else if (powerUpID == 1)
                {
                    //Enable SpeedBoost
                    player.SpeedBoostOn();
                }
                else if (powerUpID == 2)
                {
                    //Enable Shield
                    player.ShieldOn();
                }
            }
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
