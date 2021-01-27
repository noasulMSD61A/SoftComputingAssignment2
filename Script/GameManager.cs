using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int snakeLenghtdraw;

    public static int enemysnakeLenghtdraw = 3;

    

    public static bool lvl1done = false;
    public static bool lvl2done = false;
    public static bool isloaded = false;
    public static bool isloaded2 = false;

    public static GameManager instance;
    public void Awake()
    {
        Singleton();
    }

    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
    }

    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (lvl1done == true && isloaded==false)
        {
            SceneManager.LoadScene("Level2");
            isloaded =true;
        }

        if (lvl2done == true && isloaded2 == false)
        {
            SceneManager.LoadScene("Level3");
            isloaded2 = true;
        }


    }

    private void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


}
