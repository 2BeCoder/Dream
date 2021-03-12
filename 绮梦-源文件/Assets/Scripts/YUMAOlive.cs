using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUMAOlive : MonoBehaviour
{
    public GameObject Bullet;
    int sum;
    public GameObject player;
    public GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        sum = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        music = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.up = new Vector3(0.0f, 0.0f, 0.0f);
        Destroy(gameObject, 7);
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            music.GetComponent<GameManager>().Hit.Play();
            Destroy(gameObject);
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            player.GetComponent<PlayerMove>().life -= 5;
        }
    }
  
}
