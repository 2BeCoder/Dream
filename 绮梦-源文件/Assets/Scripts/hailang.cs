using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hailang : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject music;
    public Rigidbody2D rb;
    public float shootforce;
    public GameObject Bullet;
    float kaishide;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        boss = GameObject.FindGameObjectWithTag("xiyi");
        music = GameObject.FindGameObjectWithTag("GameManager");
        kaishide = player.transform.position.x-boss.transform.position.x ;
       
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
        rb.AddForce(new Vector2(kaishide * shootforce, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            music.GetComponent<GameManager>().Hit.Play();
            Destroy(gameObject);
            player.GetComponent<inwatermove>().life -= 3;
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
    }
}
