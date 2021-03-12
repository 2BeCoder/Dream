using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longmove : MonoBehaviour
{
    public int h, h2;
    public bool IStran, isfire, isbeng,ISbing;
    public GameObject player, Bullet, Bullet2;
    public Rigidbody2D rb;
    float x;
    private float showtime, firetime, bengtime;
    public Animator anim;
    public Transform shootstate;

  void Start()
    {
        IStran = true;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        showtime = Time.time + 5;
        firetime = Time.time + 50;
        bengtime = Time.time + 20;
        anim.SetBool("isshoot", false);
        anim.SetBool("isbeng", false);
        isfire = false;
        isbeng = false;
        ISbing = false;
    }
 void Update()
    {
        
        if (ISbing)
        {
            rb.velocity = new Vector2(rb.velocity.x * 1 / 20, rb.velocity.y);

        }
        if (isfire == true)
        {
            rb.velocity = new Vector2(rb.velocity.x * 1 / 20, rb.velocity.y);
        }
        else
        {

            rb.velocity = new Vector2(2 * h, rb.velocity.y);
        }
        if (Time.time > showtime && !isbeng)
        {

            if (player.transform.position.x - rb.transform.position.x > 5 || player.transform.position.x - rb.transform.position.x < -5)
            {

                Instantiate(Bullet, shootstate.position, shootstate.rotation);
                showtime = Time.time + 5;
            }
        }
        if (Time.time > firetime)
        {
            isfire = true;
            anim.SetBool("isshoot", true);
            if (IStran)
            {
                Instantiate(Bullet2, shootstate.position, Quaternion.Euler(new Vector3(0, 90f, 0)));
            }
            else
            {
                Instantiate(Bullet2, shootstate.position, Quaternion.Euler(new Vector3(0, -90f, 0)));
            }
            Invoke("nofire", 5);
            firetime = Time.time + 50;
            anim.SetBool("isshoot", false);
        }
        if (Time.time > bengtime && !isfire)
        {
            rb.AddForce(new Vector2(0, 500*20));
            isbeng = true;
            bengtime = Time.time + 20;
            Invoke("rebeng", 2);
            anim.SetBool("isbeng", true); 
        }
        if (isbeng)
        {
            rb.velocity = new Vector2(rb.velocity.x * 8, rb.velocity.y);
        }


        this.transform.up = new Vector3(0.0f, 0.0f, 0.0f);
        if (!isfire)
        {
            if (player.transform.position.x - rb.transform.position.x > 2)
            {
                h = 1;
            }
            else if (player.transform.position.x - rb.transform.position.x < -2)
            {
                h = -1;
            }
            else
            {
                h = 0;
            }
        }
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


    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(200 * h, 0));
        if (!isbeng)
        {
            x = Mathf.Clamp(rb.velocity.x, -2.0f, 2.0f);
            rb.velocity = new Vector2(x, rb.velocity.y);
        }
    }
    void nofire()
    {
        isfire = false;
    }
    void  rebeng()
    {
        isbeng = false;
        anim.SetBool("isbeng", false);
    }

}
