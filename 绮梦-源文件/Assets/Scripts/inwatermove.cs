using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inwatermove : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootstate;
    public Rigidbody2D playerRd;
    public bool IStran,jiechu,iskeep;
    public Animator anim;
    public float keeptime,shoottime;
    private float x,y,h;
    public float minVelocity;
    public float maxVelocity;
    public float ForceX,ForceY;
    public float JumpForce;
    public int life;
    public Transform beikee;
    public GameObject PlayerBlood;
    // Start is called before the first frame update
    void Start()
    {
        playerRd = GetComponent<Rigidbody2D>();
        IStran = false;jiechu = false;
        anim.SetBool("ismove", false);
          minVelocity = -10f;
        maxVelocity = 10f;
        iskeep = true;
        life = 24;
        shoottime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (Time.time > shoottime)
            {
                if (IStran)
                {
                    Instantiate(Bullet, shootstate.transform.position, Quaternion.Euler(new Vector3(0, 180f, 0)));
                  }
                else
                {
                    Instantiate(Bullet, shootstate.transform.position, shootstate.transform.rotation);

                }
            }
            shoottime = Time.time + 0.25f;
        }
        if(gameObject.transform.position.y<-80)
        {
            
            if(Input.GetKeyUp(KeyCode.K))
            {
                gameObject.transform.position = beikee.position;
            }
        }

        if (life<=0)
        {
            Destroy(gameObject);
            Debug.Log("你死了");
        }
        if(!iskeep && keeptime!=0)
        {
           if(Time.time>keeptime)
            {
                life = 0;
                Destroy(gameObject);
                Debug.Log("淹死了");
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && jiechu)
        {
            playerRd.velocity = new Vector2(playerRd.velocity.x,50);
    
        }
          this.transform.up = new Vector3(0.0f, 0.0f, 0.0f);
     
        if (h != 0 || v!=0)
        {
            anim.SetBool("ismove", true);
        }
        else
        {
            anim.SetBool("ismove", false);
        }

        if (h < 0)
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
            playerRd.velocity = new Vector2(0.0f, playerRd.velocity.y);
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
        if (h > 0)
        {
            IStran = false;
            Vector3 theScale = transform.localScale;
            if (theScale.x < 0)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
        PlayerBlood.GetComponent<GameManager>().PlayerHP.value = life;
        if (life <= 0)
        {
            PlayerBlood.GetComponent<GameManager>().Fail.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        playerRd.AddForce(new Vector2(h * ForceX, v * ForceY));
        x = Mathf.Clamp(playerRd.velocity.x, minVelocity, maxVelocity);
        y = Mathf.Clamp(playerRd.velocity.y, minVelocity, maxVelocity);
            playerRd.velocity = new Vector2(x,y);
    }
   
}
