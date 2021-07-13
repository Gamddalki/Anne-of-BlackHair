using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreTxt; // ���� Text
    public static int score = -1;
    public static float AddScoreNum = 0.1f; // ���ʴ����� ������ 1�� ���� ������ ����
    private void Start()
    {
        GamePlay();
    }
    private void FixedUpdate()
    {
        scoreTxt.text = score.ToString(); // score ���� Text ��������
    }

    public static IEnumerator AddScore()
    {
        while (Time.timeScale == 1) // ������ �������̸�
        {
            score++;
            yield return new WaitForSeconds(AddScoreNum);
        }
    }

    public void GamePlay()
    {
        score = -1;
        StartCoroutine(AddScore()); // score++ ����
    }
    public void GameOver()
    {
        StopCoroutine(AddScore()); // score++ ����
    }
}
