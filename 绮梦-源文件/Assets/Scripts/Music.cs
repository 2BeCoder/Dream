using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource BGM;
    private GameObject[] m_Desk;
    // Start is called before the first frame update
    void Start()
    {
        BGM.Play();
        m_Desk = GameObject.FindGameObjectsWithTag("musics");
        if (m_Desk.Length >= 2)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
   
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "01-Start"|| scene.name == "02-Play")
        {
            if(!BGM.isPlaying)
            {
                BGM.Play();
            }
            Debug.Log("开始界面");
        }
        else
        {
           BGM.Stop();
            Debug.Log("游戏界面");
        }
    }

}
