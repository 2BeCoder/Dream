using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longlive : MonoBehaviour
{
    public int longlife;
    bool ishuo;
    float huotime;
    int huonum;
    public GameObject player;
    public GameObject Bullet;
    public ParticleSystem ps;
    private float zhuangtime;
    public GameObject LongBlood;
    // Start is called before the first frame update
    void Start()
    {
        longlife = 500;
        ishuo = false;
        huonum = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        zhuangtime = Time.time;
    }

    void Update()
    {
        if (longlife <= 0)
        {
            Destroy(gameObject);
        }
        if (ishuo)
        {

            if (Time.time > huotime)
            {
                longlife -= 8;
                Debug.Log("燃烧效果：" + longlife);
                huotime = Time.time + 2;
                huonum++;
            }
        }
        if (huonum >= 3)
        {
            ishuo = false;
            huonum = 0;
        }
        LongBlood.GetComponent<GameManager>().BossHP.value = longlife;
        if (longlife <= 0)
        {
            LongBlood.GetComponent<GameManager>().Win.SetActive(true);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (gameObject.GetComponent<longmove>().isbeng)
            {
                if (Time.time > zhuangtime)
                {
                    LongBlood.GetComponent<GameManager>().Hit.Play();
                    collision.gameObject.GetComponent<PlayerMove>().life -= 5;
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * 90 * gameObject.GetComponent<longmove>().h, 400));
                    Debug.Log("被撞飞了" + "还有:" + collision.gameObject.GetComponent<PlayerMove>().life);
                    zhuangtime = Time.time + 3;
                }
            }
            else
            {
                if (Time.time > zhuangtime)
                {
                    LongBlood.GetComponent<GameManager>().Hit.Play();
                    collision.gameObject.GetComponent<PlayerMove>().life -= 2;
                    Debug.Log("被撞到了" + "还有:" + collision.gameObject.GetComponent<PlayerMove>().life);
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * 50*gameObject.GetComponent<longmove>().h, 100));
                    zhuangtime = Time.time + 3;
                
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        var main = ps.main;
        switch (collision.gameObject.tag)
        {
            case "ma": main.startColor = Color.red; break;
            case "banzhuan": main.startColor = Color.gray; break;
            case "bing": main.startColor = Color.blue; break;
            case "hua": main.startColor = Color.green; break;
            case "jian": main.startColor = Color.yellow; break;
            default: main.startColor = Color.white; break;
        }

        if (collision.gameObject.tag == "jian")
        {
            LongBlood.GetComponent<GameManager>().Boss.Play();
            longlife -= 15;
            Debug.Log(collision.gameObject.tag + ":" + longlife);
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.tag == "ma")
        {
            LongBlood.GetComponent<GameManager>().Boss.Play();
            longlife -= 8;
            Debug.Log(collision.gameObject.tag + ":" + longlife);
            huotime = Time.time + 2;
            ishuo = true;
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.tag == "bing")
        {
            LongBlood.GetComponent<GameManager>().Boss.Play();
            longlife -= 8;
            Debug.Log(collision.gameObject.tag + ":" + longlife);
            gameObject.GetComponent<longmove>().ISbing = true;
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.x + "x is");
            Invoke("reflash", 5);
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.tag == "hua")
        {
            LongBlood.GetComponent<GameManager>().Boss.Play();
            longlife -= 8;
            Debug.Log(collision.gameObject.tag + ":" + longlife);
            player.GetComponent<PlayerMove>().life += 1;
            Debug.Log(player.GetComponent<PlayerMove>().life + "playerlife is");
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.tag == "banzhuan")
        {
            LongBlood.GetComponent<GameManager>().Boss.Play();
            longlife -= 8;
            Debug.Log(collision.gameObject.tag + ":" + longlife);
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }


    }
 

    void reflash()
    {
        gameObject.GetComponent<longmove>().ISbing = false;
    }
}
