using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floordong : MonoBehaviour
{
    int sum;
    float tran;
    // Start is called before the first frame update
    void Start()
    {
        sum = 0;
        tran = -0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (sum % 130 == 0)
        { tran *= -1; }
        gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - tran);
        sum += 1;
    }
}

