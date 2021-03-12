using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
 //   public AudioSource backmusic;
    public GameObject Level1_Explain;
    public GameObject Level2_Explain;
    public GameObject Level3_Explain;
    public Slider PlayerHP;
    public Slider BossHP;
    public GameObject Win;
    public GameObject Fail;
    public GameObject pauselist;
    public GameObject control;
    public AudioSource BGM;
    public AudioSource Boss;
    public AudioSource Hit;
    public AudioSource Get;
    public void OnTurnScenes(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
    public void Pause()
    {
        Time.timeScale =  0;
        pauselist.SetActive(true); 
    }
    public void Goon()
    {
        Time.timeScale = 1;
        pauselist.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Start()
    {

        Time.timeScale = 0;
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale==1)
        {
            Time.timeScale = 0;
            pauselist.SetActive(true);
        }
    }
    public void startplay()
    {
        Time.timeScale = 1;
        control.SetActive(false);
    }
    public void onBGM()
    {
        
    }
    public void RetryBoss1()
    {
        SceneManager.LoadScene("03-Boss1");
    }
    public void RetryBoss2()
    {
        SceneManager.LoadScene("04-Boss2");
    }
    public void RetryBoss3()
    {
        SceneManager.LoadScene("05-Boss3");
    }
    public void onLevel1_Explain()
    {
        Level1_Explain.SetActive(true);
    }

    public void closeLevel1_Explain()
    {
        Level1_Explain.SetActive(false);
    }

    public void onLevel2_Explain()
    {
        Level2_Explain.SetActive(true);
    }

    public void closeLevel2_Explain()
    {
        Level2_Explain.SetActive(false);
    }
    public void onLevel3_Explain()
    {
        Level3_Explain.SetActive(true);
    }

    public void closeLevel3_Explain()
    {
        Level3_Explain.SetActive(false);
    }

  

    

    
}

