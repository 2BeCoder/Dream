using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beike : MonoBehaviour
{
    public Transform kongjian;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                player.transform.position = kongjian.position;
            }
            
        }
    }
   
}
