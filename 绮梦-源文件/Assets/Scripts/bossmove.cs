using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmove : MonoBehaviour
{
    private float mX, mY;
    public float num,latetime,sotime;
    public Animator anim;
    public GameObject Bullet,Bullet2;
    public Transform start;
    public Rigidbody2D rb;
    public bool IStran,ISbing;
    private int h,h2;
    private bool startgame;
    GameObject[] Imgs;
    // Start is called before the first frame update
    void Start()
    {
        startgame = false;
        
        num = 1;
        anim.SetBool("isshoot", false);
        rb = GetComponent<Rigidbody2D>();
        IStran = false;
        h = 1;
        mX = 800;
        mY = 0;
        latetime = Time.time + 10;
        sotime = Time.time + 50;
        ISbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("开始移动了");
            startgame = true;
        }
        if (ISbing)
        {
            rb.velocity = new Vector2(rb.velocity.x*1/10, rb.velocity.y);

        }
        if(gameObject.transform.position.y < -10)
        {
            mY *= -1;
           rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*-1);
     gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+1, gameObject.transform.position.z);

        }
        if (gameObject.transform.position.y>17.5 && gameObject.transform.position.y <22)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-1, gameObject.transform.position.z);
            mY = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            
        }
        num += 1;
        if (Time.time < sotime)
        {
            if (Time.time > latetime)
            {
                mY = -4;
                latetime = Time.time + 20;
            }
        }
        if(Time.time>sotime)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,35, gameObject.transform.position.z);
            YUMAOSHOOT();
            Invoke("BEcome", 10);
       
            sotime = Time.time+50;
        }
        if (num%400==0)
        {
            anim.SetBool("isshoot", true);
            SHOOT();
            num = 1;
        }
        else
        {
           
            this.transform.up = new Vector3(0.0f, 0.0f, 0.0f);

        }
        if (this.transform.position.x < -20)
        {
            
            h = 1;
            mX *= -1;
            mY *= -1;
            this.transform.position = new Vector2(-17, this.transform.position.y);
        }
        if( this.transform.position.x > 80)
        {
           
            h = -1;
            mX *=-1;
            mY *=-1;
            this.transform.position = new Vector2(78, this.transform.position.y);
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
        if (h != 0)
        {
            if (ISbing)
            {
                rb.AddForce(new Vector2(mX * 1 / 10, mY));
            }
            else
            {
                rb.AddForce(new Vector2(mX, mY));
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    void SHOOT()
    {
        if (startgame)
        {
            Instantiate(Bullet, start.position, start.rotation);
            Invoke("RESHOOT", 1);
        }
    }
    void RESHOOT()
    {
        anim.SetBool("isshoot", false);
      
    }
    void  YUMAOSHOOT()
    {
        Imgs = GameObject.FindGameObjectsWithTag("yumao");
        foreach(var item in Imgs)
        {
            Instantiate(Bullet2, item.transform.position, item.transform.rotation);
        }
       
    }
    void BEcome()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,15, gameObject.transform.position.z);
    }


}
