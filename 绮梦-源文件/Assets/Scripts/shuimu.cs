using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuimu : MonoBehaviour
{
    float keeptime;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            player.GetComponent<inwatermove>().jiechu = true;
            player.GetComponent<inwatermove>().maxVelocity *= 2;
            Invoke("returnmax", 1);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<inwatermove>().jiechu = false;
        }
    }
  void returnmax()
    {
        player.GetComponent<inwatermove>().maxVelocity =10;
    }

}
