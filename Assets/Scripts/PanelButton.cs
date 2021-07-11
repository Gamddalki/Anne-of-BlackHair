using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton : MonoBehaviour
{
    public GameObject gamePanel;

    public void Stop() // �Ͻ����� ��ư ������ ��
    {
        gamePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue() // �ٽ� ���� ���� ��ư ������ ��
    {
        gamePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
