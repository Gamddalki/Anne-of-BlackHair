using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController: MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject fadeSprite;
    private void Start()
    {
        gamePanel.SetActive(false); // �г� �����
        fadeSprite.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape)) // ����Ʈ�� �ڷΰ��� ��ư ������ ��
        {
            gamePanel.SetActive(true); // �г� ���̱�
            fadeSprite.SetActive(true);
        }
    }
}
