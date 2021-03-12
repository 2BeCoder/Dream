using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump2 : MonoBehaviour
{
    public Rigidbody2D playerRd;
    public float ForceX;
    public float JumpForce;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerRd = gameObject.GetComponent<Rigidbody2D>();
   
        anim.SetBool("isjump2", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K) && gameObject.GetComponent<PlayerMove>().jj==1)
        {
            if (playerRd.velocity.y < 0)
            {
                playerRd.velocity = new Vector2(playerRd.velocity.x, playerRd.velocity.y*-1);
            }
            else
            {
                playerRd.velocity = new Vector2(playerRd.velocity.x, playerRd.velocity.y);
            }
            playerRd.AddForce(new Vector2(0, JumpForce * ForceX));
            Debug.Log("二次起跳"+gameObject.GetComponent<PlayerMove>().jj);
            gameObject.GetComponent<PlayerMove>().jj -=1;
            anim.SetBool("isjump2", true);
        }
        else
        {
            anim.SetBool("isjump2", false);
        }
    
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            gameObject.GetComponent<PlayerMove>().jj = 2;
            Debug.Log("落地:" + gameObject.GetComponent<PlayerMove>().jj);
        }
    }
}
