using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biubiumove : MonoBehaviour
{
    public float Speed;
    private GameObject palyer;
    private GameObject Do;
    public GameObject music;
    public GameObject Bullet,Bullet2;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        Do = GameObject.Find("shoot");
        palyer = GameObject.Find("Player");
        GetComponent<Rigidbody2D>().velocity = Speed * (Do.transform.position - palyer.transform.position);
        music = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject)
        { 
            Destroy(gameObject, 0.6f);
        }

    }
    void OnTriggerEnter2D(Collider2D GetObj)

    {
        if (GetObj.gameObject.tag == "xiyi")
        {
            music.GetComponent<GameManager>().Boss.Play();
            Instantiate(Bullet2, GetObj.gameObject.transform.position, GetObj.gameObject.transform.rotation);
            GetObj.gameObject.GetComponent<xiyimove>().xiyilife -= 8;
            Debug.Log("xiyi :" + GetObj.gameObject.GetComponent<xiyimove>().xiyilife);
            Destroy(gameObject);
        }

        if (GetObj.tag == "eye")
        {
            if (this.gameObject.tag == "banzhuan")
            {
                GetObj.GetComponent<eyemove>().eyelife -= 5;
                Destroy(this.gameObject);
            }
            else
            {
                GetObj.GetComponent<eyemove>().eyelife -= 1;
                Destroy(this.gameObject);
            }

        }
       
        if (GetObj.tag == "Ground")
        {
            var main = ps.main;
            
            switch (this.gameObject.tag)
            {
                case "ma":  main.startColor = Color.red; break;
                case "banzhuan": main.startColor = Color.gray; break;
                case "bing": main.startColor = Color.blue; break;
                case "hua": main.startColor = Color.green; break;
                case "jian":main.startColor = Color.yellow;break;
                default: main.startColor = Color.white; break;
            }
            
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
       


    }

}


