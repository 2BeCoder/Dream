using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed;
    public float maxX ;
    public float minX ;
    public float maxY;
    public float minY;
    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        if (player)
        {

            Vector3 temp = this.transform.position;

            if (player.position.x <= maxX && player.position.x >= minX)
            {
                temp.x = Mathf.Lerp(temp.x, player.position.x, Time.deltaTime * cameraSpeed);
     
            }
            if (player.position.y <= maxY && player.position.y >= minY)
            {
                temp.y = Mathf.Lerp(temp.y, player.position.y, Time.deltaTime * cameraSpeed);

            }
            if (GameObject.FindGameObjectWithTag("xiyi"))
            {
                if (player.position.y < -38)
                {
                    temp.y = Mathf.Lerp(temp.y, minY, Time.deltaTime * cameraSpeed);
                }
                if(player.position.y>-2)
                {
                    temp.y = Mathf.Lerp(temp.y, maxY, Time.deltaTime * cameraSpeed);
                }
            }
            else if (player.position.y < -14)
            {
                temp.y = Mathf.Lerp(temp.y, minY, Time.deltaTime * cameraSpeed);
            }
            transform.position = temp;
        }
    }

}
