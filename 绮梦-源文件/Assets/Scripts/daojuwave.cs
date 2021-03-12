using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daojuwave : MonoBehaviour
{

    public Rigidbody2D rb;
    private GameObject player;
    float mX, mY,z,x;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        mX = 4;
        mY = 0;
        z = gameObject.transform.position.x - player.transform.position.x;
        if (z > 0)
        {
            mX *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("beijing2"))
        {
            rb.gravityScale = 0;
            rb.AddForce(new Vector2(mX, mY));
            x = Mathf.Clamp(rb.velocity.x, -2.0f, 2.0f);
            rb.velocity = new Vector2(x, rb.velocity.y);
            
        }

    }
}
