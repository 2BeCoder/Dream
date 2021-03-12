using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duwu : MonoBehaviour
{
    float duwutime;
    // Start is called before the first frame update
    void Start()
    {
        duwutime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10);
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("Player"))
        {
            if (Time.time > duwutime)
            {
                Debug.Log("中毒了");
                other.gameObject.GetComponent<inwatermove>().life -= 2;
                duwutime = Time.time + 2;
            }
        }
    }
}
