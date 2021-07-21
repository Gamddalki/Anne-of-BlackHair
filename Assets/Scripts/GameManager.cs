using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isPlay;

    public Text scoreTxt; // ���� Text
    public static int score = 0;

    public GameObject GameOverPanel;
    public GameObject fadeSprite;
    public Text finalScore;
    public GameObject player;
    public GameObject AnneCry;

    public GameObject BackgroundMusic;
    AudioSource backmusic;
    public GameObject stepSound;
    AudioSource stepAudio;

    public float gameSpeed;
    #region instance
    public static GameManager instance;
    private void Awake()
    {
        backmusic = BackgroundMusic.GetComponent<AudioSource>();
        stepAudio = stepSound.GetComponent<AudioSource>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    private void Start()
    {
        GamePlay();
    }
    private void Update()
    {
        scoreTxt.text = score.ToString(); // score ���� Text ��������
        if (Input.GetKey(KeyCode.S))
        {
            GameOver();
        }
    }


    public IEnumerator AddScore()
    {
        while (Time.timeScale == 1 && isPlay == true) // ������ �������̸�
        {
            score++;
            yield return new WaitForSeconds(gameSpeed); // ���� �ӵ� ������ ������ ����
        }
    }

    public void GamePlay()
    {
        score = 0;
        isPlay = true;
        scoreTxt.text = string.Empty;
        scoreTxt.gameObject.SetActive(true);
        player.SetActive(true);

        SpawnManager.MobStartNum = 0;
        StartCoroutine(AddScore()); // score++ ����

        if (MainMenu.AudioPlay == true)
        {
            backmusic.Play();
            stepAudio.Play();
        }
        else
        {
            backmusic.Pause();
            stepAudio.Pause();
        }

    }
    public void GameOver()
    {
        isPlay = false;
        StopCoroutine(AddScore()); // score++ ����
        finalScore.text = score.ToString();
        GameOverPanel.SetActive(true);
        fadeSprite.SetActive(true);
        scoreTxt.gameObject.SetActive(false);
        player.SetActive(false);
        AnneCry.SetActive(true);

        if (MainMenu.AudioPlay == true)
        {
            backmusic.Pause();
            stepAudio.Pause();
        }

    }



}

