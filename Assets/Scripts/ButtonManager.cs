using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject fadeSprite;

    public void Stop() // �Ͻ����� ��ư ������ ��
    {
        gamePanel.SetActive(true);
        fadeSprite.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue() // �ٽ� ���� ���� ��ư ������ ��
    {
        gamePanel.SetActive(false);
        fadeSprite.SetActive(false);
        Time.timeScale = 1;
    }
}
