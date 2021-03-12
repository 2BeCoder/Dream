using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daojudo : MonoBehaviour
{
    public GameObject player;
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        music = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = new Vector3(0.0f, 0.0f, 0.0f);
        if (!GameObject.FindGameObjectWithTag("beijing2"))
        {
            Destroy(gameObject, 20);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag=="tu" || collision.gameObject.tag == "jin" || collision.gameObject.tag == "shui" || collision.gameObject.tag == "huo" || collision.gameObject.tag == "mu")
        {
            
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            switch(this.gameObject.tag)
            {
                case "jin":
                    for(int i=0;i<5;i++)
                    {
                        music.GetComponent<GameManager>().Get.Play();
                        player.GetComponent<shoot>().num[i]=0;
                    }
                    player.GetComponent<shoot>().num[0] += 10;
                    Debug.Log(player.GetComponent<shoot>().num[0] + "添加了num1");
                    break;
                case "mu":
                    for (int i = 0; i < 5; i++)
                    {
                        music.GetComponent<GameManager>().Get.Play();
                        player.GetComponent<shoot>().num[i] = 0;
                    }
                    player.GetComponent<shoot>().num[1] += 10;
                    Debug.Log(player.GetComponent<shoot>().num[1] + "添加了num2");
                     break;
                case "shui":
                    for (int i = 0; i < 5; i++)
                    {
                        music.GetComponent<GameManager>().Get.Play();
                        player.GetComponent<shoot>().num[i] = 0;
                    }
                    player.GetComponent<shoot>().num[2] += 10;
                    Debug.Log(player.GetComponent<shoot>().num[2] + "添加了num3");
                     break;
                case "huo":
                    for (int i = 0; i < 5; i++)
                    {
                        music.GetComponent<GameManager>().Get.Play();
                        player.GetComponent<shoot>().num[i] = 0;
                    }
                    player.GetComponent<shoot>().num[3] += 10;
                    Debug.Log(player.GetComponent<shoot>().num[3] + "添加了num4");
                    break;
                case "tu":
                    for (int i = 0; i < 5; i++)
                    {
                        music.GetComponent<GameManager>().Get.Play();
                        player.GetComponent<shoot>().num[i] = 0;
                    }
                    player.GetComponent<shoot>().num[4] += 10;
                    Debug.Log(player.GetComponent<shoot>().num[4] + "添加了num5");
                   break;
                default: break;
            }

           
            
            
        }
    }
}
