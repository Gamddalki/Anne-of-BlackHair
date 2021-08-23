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

    public GameObject BackgroundMusic;
    AudioSource backmusic;
    public GameObject stepSound;
    AudioSource stepAudio;

    public float gameSpeed;
    public GameObject[] Count;

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
            if(Time.timeScale == 1 && isPlay) { 
                score++;
                yield return new WaitForSeconds(0.3f); // ���� �ӵ� ������ ������ ����
            }
            yield return null;
        }
        
    }
    public IEnumerator CountDown()
    {
        for(int i = 0;i<Count.Length;i++)
        {
            Count[i].transform.position = new Vector2(-5.5f, 0);
            Count[i].SetActive(true);
            while (true)
            {
                if (Count[i].transform.position.x >= 0)
                {
                    break;
                }
                Count[i].transform.Translate(Vector2.right * 17 * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
            while (true)
            {
                if (Count[i].transform.position.x >= 5.5f)
                {
                    break;
                }
                Count[i].transform.Translate(Vector2.right * 17 * Time.deltaTime);
                yield return null;
            }
            Count[i].SetActive(false);
            yield return new WaitForSeconds(0.5f);
            yield return null;   
        }
        isPlay = true;
        StopCoroutine(CountDown());
        yield return null;
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
        finalScore.text = score.ToString(); // ���ӿ��� ȭ�� Ȱ��ȭ
        GameOverPanel.SetActive(true);
        fadeSprite.SetActive(true);
        AnneCry.SetActive(true);

        scoreTxt.gameObject.SetActive(false);
        player.SetActive(false);
        rumor.gameObject.SetActive(false);
        itemSlot.SetActive(false);

        if (MainMenu.AudioPlay == true)
        {
            backmusic.Pause();
            stepAudio.Pause();
        }

    }



}
