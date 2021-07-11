using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    public GameObject gamePanel;

    void Start()
    {
        gamePanel.SetActive(false); // �г� �����
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // ����Ʈ�� �ڷΰ��� ��ư ������ ��
        {
            Time.timeScale = 0; // �Ͻ�����
            gamePanel.SetActive(true); // �г� ���̱�
        }
    }
}
