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
    public Slider rumor;
    public GameObject itemSlot;
    public GameObject itemButton;

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
        gameSpeed = 0.3f;
    }
    private void Update()
    {
        scoreTxt.text = score.ToString(); // score ���� Text ��������

    }

    public IEnumerator AddScore()
    {
        while (true) 
        {
            if (GameManager.isPlay) // ������ �������̸�
            {
                score++;
                yield return new WaitForSeconds(0.3f); // ���� �ӵ� ������ ������ ����
            }

        }
    }

    public void GamePlay()
    {
        score = 0;
        isPlay = true;
        scoreTxt.text = string.Empty;
        scoreTxt.gameObject.SetActive(true);
        player.SetActive(true);
        rumor.gameObject.SetActive(true);
        itemSlot.SetActive(true);
        itemButton.SetActive(true);

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
        AnneCry.SetActive(true);

        scoreTxt.gameObject.SetActive(false);
        player.SetActive(false);
        rumor.gameObject.SetActive(false);
        itemSlot.SetActive(false);
        itemButton.SetActive(false);

        if (MainMenu.AudioPlay == true)
        {
            backmusic.Pause();
            stepAudio.Pause();
        }

    }



}

