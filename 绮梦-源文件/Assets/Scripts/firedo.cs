using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firedo : MonoBehaviour
{
    private GameObject player;
    float firetime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        firetime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag=="Player")
        {
            if (Time.time > firetime)
            {
                player.GetComponent<PlayerMove>().life -= 2;
                Debug.Log("你被烫伤了，生命值：" + player.GetComponent<PlayerMove>().life);
                firetime = Time.time + 2;
            }
        }
    }
   
}
