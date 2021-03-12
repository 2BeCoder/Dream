using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyemove : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public GameObject music;
    private float x;
    public GameObject Bullet;
    
    public ParticleSystem ps;
    public  int eyelife;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        music = GameObject.FindGameObjectWithTag("GameManager");
        eyelife = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(eyelife<=0)
        {
            Destroy(gameObject);
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
        }
        Destroy(gameObject, 10);
        if (player)
        {
            rb.AddForce(new Vector2(player.transform.position.x - rb.transform.position.x, 0));
            x = Mathf.Clamp(rb.velocity.x, -20, 20);
            rb.velocity = new Vector2(x, rb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var main = ps.main;
        ps.startColor = Color.white;
        if (collision.gameObject.tag == "BK")
        {
            Destroy(gameObject);
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
        }

        if (collision.gameObject.tag == "Player")
        {
            music.GetComponent<GameManager>().Hit.Play();
            Destroy(gameObject);           
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);          
            player.GetComponent<PlayerMove>().life -= 2;

        }

    }
}
