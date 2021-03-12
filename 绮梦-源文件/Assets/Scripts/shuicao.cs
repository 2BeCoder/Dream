using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuicao : MonoBehaviour
{
    int x;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       x= UnityEngine.Random.Range(1, 9);
        Invoke("todo", x);
        anim.SetBool("ishuang", false);
    }

    // Update is called once per frame
  void todo()
    {
        anim.SetBool("ishuang", true);
    }
}
