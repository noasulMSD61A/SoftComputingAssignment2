using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int snakeLenghtdraw;

    public static int enemysnakeLenghtdraw = 4;

    public static bool lvl1done = false;

    public bool isloaded = false;

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
