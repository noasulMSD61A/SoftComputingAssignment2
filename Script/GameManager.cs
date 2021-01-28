using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int snakeLenghtdraw;
    public static int enemysnakeLenghtdraw = 3;
    //public static float valTimer = 0f;
    public static bool lvl1done = false;
    public static bool lvl2done = false;
    public static bool lvl3done = false;
    public static bool isloaded = false;
    public static bool isloaded2 = false;
    public static bool isloaded3 = false;


    string sceneName;

    public static GameManager instance;

    bool timerReady = true;
    GameObject timer;
    public void Awake()
    {
        Singleton();
    }

    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (lvl1done == true && isloaded==false)
        {
            SceneManager.LoadScene("Level2");
            isloaded =true;
            GameData.Timer = GameData.Timer;
        }

        if (lvl2done == true && isloaded2 == false)
        {
            SceneManager.LoadScene("Level3");
            isloaded2 = true;
            GameData.Timer = GameData.Timer;
        }

        if (lvl3done == true && isloaded3 == false)
        {
            SceneManager.LoadScene("EndScene");
            isloaded3 = true;
            GameData.Timer = GameData.Timer;
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

    public void loadlevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /*private void setTimer()
    {
        if (sceneName == "SampleScene" && timerReady)
        {
            
            timer = GameObject.FindWithTag("timer");
                                                                                                                // the default value for the timer is started
            timer.GetComponent<timeManager>().started = true; // Get the timer find the component on it named timeManager(script) which is attached to the timer
            timerReady = false;
            print("inside timer");
        }




    }*/



}
