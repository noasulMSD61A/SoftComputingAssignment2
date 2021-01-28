using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{

    public InputField nametext;
    

    public void saveName()
    {
        
            PlayerPrefs.SetString("name",nametext.text);
            print("name is" + PlayerPrefs.GetString("name"));
        


    }

    void Start()
    {
        
            saveName();
        
        
    }
    void Update()
    {
        SaveTime();
        
        
    }

    public void SaveTime()
    {
        if (GameManager.lvl3done == true && GameData.Timer>PlayerPrefs.GetFloat("highscore"))
        {
            PlayerPrefs.SetFloat("highscore", GameData.Timer);
            GameManager.sethighscore = true;
            
        }
    }

   


}
