using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour // 씬 전환함수가 모여있는 class
{

    public void PlayGame()
    {   
        SpawnManager.MobStartNum = 0;
        if (MainMenu.AudioPlay)
            AudioManager.SwitchSceneAudio.Play();
        SceneManager.LoadScene("mainGame");
 
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void toMainMenu()
    {
        if (MainMenu.AudioPlay)
            AudioManager.SwitchSceneAudio.Play();
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }

    public void Tutorial()
    {
        if (MainMenu.AudioPlay)
            AudioManager.ButtonAudio.Play();
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadScene()
    {
        if (MainMenu.AudioPlay)
            AudioManager.SwitchSceneAudio.Play();
        SceneManager.LoadScene("Loading");
    }
    public void SomoonGameOver()
    {
        SceneManager.LoadScene("Ending_Somoon");
    }
    public void BerryGameOver()
    {
        SceneManager.LoadScene("Ending_Berry");
    }
}
