using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour // �� ��ȯ�Լ��� ���ִ� class
{

    public void PlayGame()
    {
        if (MainMenu.AudioPlay)
            AudioManager.SwitchSceneAudio.Play();
        SpawnManager.MobStartNum = 0;
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
}
