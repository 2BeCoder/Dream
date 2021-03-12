using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baohu : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.parent = player.transform;
     
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<inwatermove>().iskeep = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<inwatermove>().iskeep = false;
        player.GetComponent<inwatermove>().keeptime = Time.time + 15;
        if (collision.gameObject.tag=="xiyi")
        {
            Destroy(gameObject);
        }
        
    }
}
