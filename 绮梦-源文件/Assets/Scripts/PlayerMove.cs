using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float ForceX;
    public float JumpForce;
    public GameObject groundCheck;
    public Rigidbody2D playerRd;
    private float minVelocity;
    private float maxVelocity;
    private float x;
    public bool IStran,IScut;
    public Animator anim;
    public int life,jj;
    public GameObject PlayerBlood;

    // Start is called before the first frame update
    void Start()
    {
        playerRd = GetComponent<Rigidbody2D>();
        minVelocity = -10f;
        maxVelocity = 10f;
        IStran = false;
        anim.SetBool("isrun", false);
        anim.SetBool("isjump", false);
        anim.SetBool("isfuck", false);
        anim.SetBool("isjump2", false);
        life = 24;
        jj = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("long"))
        {
            if (gameObject.transform.position.y < -14.5)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z);
                playerRd.velocity = new Vector2(0, 0);
            }
            if (gameObject.transform.position.y > 17)
            {

                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 6, gameObject.transform.position.z);
                playerRd.velocity = new Vector2(0, 0);
            }
        }
        if (life <= 0)
        {
            Destroy(gameObject);
            Debug.Log("你死了");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (gameObject.GetComponent<shoot>().Bullet0 != null)
            {
                anim.SetBool("isfuck", true);
            }
            }
        else
        {
            anim.SetBool("isfuck", false);
        }
        this.transform.up = new Vector3(0.0f, 0.0f, 0.0f);
        float h = Input.GetAxis("Horizontal");
        if (h != 0)
        {
            anim.SetBool("isrun", true);
        }
        else
        {
            anim.SetBool("isrun", false);
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

        if (Input.GetKeyDown(KeyCode.K) && IsJump() )
        {
            playerRd.AddForce(new Vector2(0, JumpForce * ForceX));
            anim.SetBool("isjump", true);
            jj -= 1;
            Debug.Log("减少一次");
        }
        else { anim.SetBool("isjump", false); }
        PlayerBlood.GetComponent<GameManager>().PlayerHP.value = life;
        if (life <= 0)
        {
            PlayerBlood.GetComponent<GameManager>().Fail.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        playerRd.AddForce(new Vector2(h * ForceX, 0)); 
        x = Mathf.Clamp(playerRd.velocity.x, minVelocity, maxVelocity);
        playerRd.velocity = new Vector2(x, playerRd.velocity.y);
    }
    private bool IsJump()
    {
        bool isJump = true;
        //防止二段跳的关键：如果射线于地面相交，返回true，否则返回false；
        isJump = Physics2D.Linecast(playerRd.transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        return isJump;
        
    }
    
}

