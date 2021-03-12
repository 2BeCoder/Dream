using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject Bullet1, Bullet2, Bullet3, Bullet4, Bullet5,Bullet6;
   public GameObject Bullet0;
    GameObject[] Bullet;
    private Transform BulletStart;
    private GameObject DO;
    private GameObject PLayer;
    bool I;
    public float timeH;
    private float Ltime;
    public int[] num;
    // Start is called before the first frame update
    void Start()
    {
        Bullet = new GameObject[6];
        num = new int[5];
        DO = GameObject.Find("shoot");
        PLayer = GameObject.Find("Player");
        Bullet[0] = Bullet1;Bullet[1] = Bullet2;Bullet[2] = Bullet3;Bullet[3] = Bullet4;Bullet[4] = Bullet5;Bullet[5] = Bullet6;
    }

    // Update is called once per frame
    void Update()
    {
       
        I = PLayer.GetComponent<PlayerMove>().IStran;
        BulletStart = DO.transform;
        if (Input.GetKeyDown(KeyCode.J) && Time.time > Ltime )
        {
           
            for(int i=0;i<5;i++)
            {
               
                if(num[i]>0)
                {
                    Debug.Log(num[i]);
                    Bullet0 = Bullet[i];
                    num[i] -= 1;
                    Debug.Log(num[i] + "还有这么多num{"+i+"}");
                    break;
                }
                else
                {
                   
                    if (!GameObject.FindGameObjectWithTag("long"))
                    {
                        Bullet0 = Bullet6;
                    }
                    else
                    {
                        Bullet0 = null;
                    }
                }
            }

            if (I)
            {
                if (Bullet0 != null)
                {
                    Instantiate(Bullet0, BulletStart.position, Quaternion.Euler(new Vector3(0, 180f, 0)));
                }
             
            }
            else
            {
                if (Bullet0 != null)
                {
                    Instantiate(Bullet0, BulletStart.position, BulletStart.rotation);
                }
            }

      
            Ltime = Time.time + timeH;
        }
    }
}
