﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int snakeLenghtdraw;
    public static int enemysnakeLenghtdraw = 4;
    public static bool lvl1done = false;
    public static bool lvl2done = false;
    public static bool lvl3done = false;
    public static bool isloaded = false;
    public static bool isloaded2 = false;
    public static bool isloaded3 = false;
    public static bool isloadedlose = false;
    public static bool sethighscore = false;
    public static bool youlost = false;
    public static GameManager instance;
    string sceneName;
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

        if (youlost == true && isloadedlose==false)
        {
            SceneManager.LoadScene("LoseScene");
            isloadedlose = true;
        }
        

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

    public void loadstart()
    {
        SceneManager.LoadScene("StartScene");
    }



}
