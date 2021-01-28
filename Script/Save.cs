using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public new InputField name;
    

    public void saveName()
    {
        if (GameManager.lvl3done == true && GameData.Timer >PlayerPrefs.GetFloat("highscore",0))
        {
            PlayerPrefs.SetString("name", name.text);
        }


    }

    void Update()
    {
        SaveTime();
        saveName();
    }

    public void SaveTime()
    {
        if (GameManager.lvl3done == true && GameData.Timer>PlayerPrefs.GetFloat("highscore",0))
        {
            PlayerPrefs.SetFloat("highscore", GameData.Timer);
            
            
        }
    }

    
}
