using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPFollow : MonoBehaviour
{

    public float x;
    public float y;
    public RectTransform HP ;

    void Update()
    {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        HP.position = player2DPosition + new Vector2(x, y + 150);

        if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        {
            HP.gameObject.SetActive(false);
        }
        else
        {
            HP.gameObject.SetActive(true);
        }
    }
}

