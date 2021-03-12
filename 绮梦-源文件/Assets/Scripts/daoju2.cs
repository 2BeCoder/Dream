using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class daoju2 : MonoBehaviour
{
    private float sum;
    GameObject[] Bullet;
    public Transform state1, state2;
    public GameObject Bullet1, Bullet2, Bullet3, Bullet4, Bullet5;
    // Start is called before the first frame update
    void Start()
    {
        sum = Time.time + 8;
        Bullet = new GameObject[5];
        Bullet[0] = Bullet1;
        Bullet[1] = Bullet2;
        Bullet[2] = Bullet3;
        Bullet[3] = Bullet4;
        Bullet[4] = Bullet5;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > sum)
        {
            int x = UnityEngine.Random.Range(0, 2);
            int y = UnityEngine.Random.Range(0, 5);
            Debug.Log("x he y:" + x+"   " + y);
            if(x==0)
            {
                Instantiate(Bullet[y], state1.position, state1.rotation);
                Debug.Log(Bullet[y]+"+++++");
            }
            else
            {
                Instantiate(Bullet[y], state2.position, state2.rotation);
                Debug.Log(Bullet[y] + "----");
            }
            sum = Time.time + 15;
        }
    }
}
