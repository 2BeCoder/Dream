using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaoyu : MonoBehaviour
{
    public GameObject Bullet,player;
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,4);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
           
            Destroy(gameObject);
            music.GetComponent<GameManager>().Hit.Play();
            collision.gameObject.GetComponent<inwatermove>().life -= 3;
            Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        if(collision.gameObject.tag=="BK")
        {
            Destroy(gameObject);
        }
    }
}
