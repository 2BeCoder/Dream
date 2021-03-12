using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longzhudo : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject music;
    public Rigidbody2D rb;
    private float x,y,z,d,f;
    public GameObject Bullet;
    public ParticleSystem ps;
    float tr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        boss = GameObject.FindGameObjectWithTag("long");
        music = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10);
        z = boss.GetComponent<longmove>().h;
        d = gameObject.transform.position.x - player.transform.position.x;
        f = gameObject.transform.position.x - boss.transform.position.x;

        if (d * f < 0)
        {
            if (player)
            {
                if (player.transform.position.x - gameObject.transform.position.x > 0)
                {
                    rb.AddForce(new Vector2(50, (player.transform.position.y - rb.transform.position.y) * 25));
                }
                else if (player.transform.position.x - gameObject.transform.position.x < 0)
                {
                    rb.AddForce(new Vector2(-50, (player.transform.position.y - rb.transform.position.y) * 25));
                }
                else
                {
                    rb.AddForce(new Vector2(0, (player.transform.position.y - rb.transform.position.y) * 25));
                }
            }
        }

        Debug.Log("速度：" + rb.velocity.x);
        y = Mathf.Clamp(rb.velocity.y, -5, 5);
        x = Mathf.Clamp(rb.velocity.x, -10, 10);
        rb.velocity = new Vector2(x, y);


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        var main = ps.main;
        main.startColor = Color.white;
        if (collision.gameObject.tag=="Player")
        {
            music.GetComponent<GameManager>().Hit.Play();
            player.GetComponent<PlayerMove>().life -= 3;
          Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Ground")
        {
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
