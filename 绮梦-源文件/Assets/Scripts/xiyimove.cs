using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiyimove : MonoBehaviour
{
    public int h,v;
    float x,y,z,k;
    public bool IStran;
    public GameObject player,Bullet,Bullet2,Bullet3;
    public Transform dlstate,duqi,shootstate;
    public Rigidbody2D rb;
    float diaoluotime,duwutime,shoottime;
    public int xiyilife;
    public GameObject xiyiBlood;
    // Start is called before the first frame update
    void Start()
    {
        IStran = true;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        diaoluotime = Time.time;
        duwutime = Time.time + 50;
        shoottime = Time.time + 10;
        xiyilife = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if(xiyilife<=0)
        {
            Destroy(gameObject);
        }
        if(Time.time>shoottime)
        {
            if (h > 0)
            {
                Instantiate(Bullet3, shootstate.position, shootstate.rotation);
            }
            else
            {
                
                Instantiate(Bullet3, shootstate.position, Quaternion.Euler(new Vector3(0, 180f, 0)));
            }
           k= UnityEngine.Random.Range(1, 5);
            shoottime = Time.time + k;
        }
        
        if (gameObject.transform.position.y - player.transform.position.y < -80 || gameObject.transform.position.y - player.transform.position.y > 80)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if(Time.time>duwutime)
        {
            Instantiate(Bullet2, duqi.position, duqi.rotation);
            duwutime = Time.time + 50;
        }

        

        if(Time.time>diaoluotime)
        {
           z= UnityEngine.Random.Range(-50, 51);
            Instantiate(Bullet, new Vector3(dlstate.gameObject.transform.position.x+z, dlstate.gameObject.transform.position.y, dlstate.gameObject.transform.position.z), dlstate.gameObject.transform.rotation);
            diaoluotime = Time.time + 2;
        }



        if (player.transform.position.x - rb.transform.position.x > 5)
        {
            h = 1;
        }
        else if (player.transform.position.x - rb.transform.position.x < -5)
        {
            h = -1;
        }
        else
        {
            h = 0;
        }
        if (player.transform.position.y - rb.transform.position.y > 2)
        {
            v = -1;
        }
        else if (player.transform.position.y - rb.transform.position.y < -2)
        {
            v = 1;
        }
        else
        {
            v= 0;
        }
       
        this.transform.up = new Vector3(0.0f, .0f, .0f);
        if (h > 0)
        {
            Vector3 theScale = transform.localScale;
            if (theScale.x > 0)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
            }

            IStran = true;
        }
        if (h == 0)
        {
            if (IStran)
            {

                Vector3 theScale = transform.localScale;
                if (theScale.x > 0)
                {
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
            }
        }
        if (h < 0)
        {
            IStran = false;
            Vector3 theScale = transform.localScale;
            if (theScale.x < 0)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
        xiyiBlood.GetComponent<GameManager>().BossHP.value = xiyilife;
        if (xiyilife <= 0)
        {
            xiyiBlood.GetComponent<GameManager>().Win.SetActive(true);
        }
    }



    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(20 * h, 20*-v));
        x = Mathf.Clamp(rb.velocity.x, -10f, 10f);
        y = Mathf.Clamp(rb.velocity.y, -5f, 5f);
        rb.velocity = new Vector2(x,y);
    }
}
