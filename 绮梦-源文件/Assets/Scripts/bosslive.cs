using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosslive : MonoBehaviour
{
    public int bosslife;
    bool ishuo;
    float huotime,zhuangtime;
    int huonum;
    public GameObject player;
    public GameObject Bullet;
    public ParticleSystem ps;
    public GameObject BossBlood;
    // Start is called before the first frame update
    void Start()
    {
        bosslife = 500;
        ishuo = false;
        huonum = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        zhuangtime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(bosslife<=0)
        {
            Destroy(gameObject);
        }
        if(ishuo)
        {

            if(Time.time>huotime)
            {
                BossBlood.GetComponent<GameManager>().Boss.Play();
                bosslife -= 8;
                Debug.Log("燃烧效果：" + bosslife);
                huotime = Time.time + 2;
                huonum++;
            }
          
        }
        if(huonum>=3)
        {
            ishuo = false;
            huonum = 0;
        }
        BossBlood.GetComponent<GameManager>().BossHP.value = bosslife;
        if (bosslife <= 0)
        {
            BossBlood.GetComponent<GameManager>().Win.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {

            if(gameObject.transform.position.y<11)
            {
                
                if (Time.time>zhuangtime)
                {
                BossBlood.GetComponent<GameManager>().Hit.Play();
                collision.gameObject.GetComponent<PlayerMove>().life -= 3;
                }
                Debug.Log("被撞到了" + "还有:" + collision.gameObject.GetComponent<PlayerMove>().life);
                zhuangtime = Time.time + 2;
            }
        }

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
        if (collision.gameObject.tag == "biao")
        {
            BossBlood.GetComponent<GameManager>().Boss.Play();
            bosslife -= 5;
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Debug.Log(bosslife);
        }
        if (collision.gameObject.tag == "jian")
        {
            BossBlood.GetComponent<GameManager>().Boss.Play();
            bosslife -= 15;
            Debug.Log(collision.gameObject.tag + ":" + bosslife);
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.tag == "ma")
        {
            BossBlood.GetComponent<GameManager>().Boss.Play();
            bosslife -= 8;
            Debug.Log(collision.gameObject.tag + ":" + bosslife);
            huotime = Time.time + 2;
            ishuo = true;
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.tag == "bing")
        {
            BossBlood.GetComponent<GameManager>().Boss.Play();
            bosslife -= 8;
            Debug.Log(collision.gameObject.tag + ":" + bosslife);
            gameObject.GetComponent<bossmove>().ISbing = true;
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.x + "x is");
            Invoke("reflash", 5);
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.tag == "hua")
        {
            BossBlood.GetComponent<GameManager>().Boss.Play();
            bosslife -= 8;
            Debug.Log(collision.gameObject.tag + ":" + bosslife);
            player.GetComponent<PlayerMove>().life += 1;
            Debug.Log(player.GetComponent<PlayerMove>().life+"playerlife is");
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.tag == "banzhuan")
        {
            BossBlood.GetComponent<GameManager>().Boss.Play();
            bosslife -= 8;
            Debug.Log(collision.gameObject.tag + ":" + bosslife);
            Destroy(collision.gameObject);
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
    }

    void reflash()
    {
        gameObject.GetComponent<bossmove>().ISbing = false;
    }
}
