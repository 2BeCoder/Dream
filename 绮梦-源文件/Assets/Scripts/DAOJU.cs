using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DAOJU : MonoBehaviour
{
    private float sum;
    GameObject[] station;
    GameObject[] Bullet;
    public GameObject Bullet1, Bullet2, Bullet3, Bullet4, Bullet5;
    // Start is called before the first frame update
    void Start()
    {
        sum = Time.time + 8;
        station = new GameObject[18];
        station = GameObject.FindGameObjectsWithTag("yumao");
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
            int x = UnityEngine.Random.Range(0, 17);
            int y = UnityEngine.Random.Range(0, 5);
            Instantiate(Bullet[y], station[x].transform.position, station[x].transform.rotation);
            sum = Time.time + 15;
        }
    }
}
