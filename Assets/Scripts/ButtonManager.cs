using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject gamePanel; // �г� �ν��Ͻ�
    public GameObject fadeSprite; // �г� ������ ȭ��κ� ��ο����� �ϴ� ����
    

    public void Stop() // �Ͻ����� ��ư ������ ��
    {
        gamePanel.SetActive(true);
        fadeSprite.SetActive(true);
        StopCoroutine(GameManager.AddScore());
        Time.timeScale = 0;
    }
    public void Continue() // �ٽ� ���� ���� ��ư ������ ��
    {
        gamePanel.SetActive(false);
        fadeSprite.SetActive(false);
        StartCoroutine(GameManager.AddScore());
        Time.timeScale = 1;
    }
}
