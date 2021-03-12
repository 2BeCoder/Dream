using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baoxiang : MonoBehaviour
{
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(GameObject.FindGameObjectWithTag("keepout")==null)
            {
                Instantiate(Bullet, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                collision.gameObject.GetComponent<inwatermove>().keeptime = 0; 
            }
        }
    }
}
