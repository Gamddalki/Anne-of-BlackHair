using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject stopPanel;
    public GameObject GameOverPanel;
    public GameObject fadeSprite;
    public GameObject AnneCry;

    void Start()
    {
        stopPanel.SetActive(false); // �г� �����
        GameOverPanel.SetActive(false);
        fadeSprite.SetActive(false);
        AnneCry.SetActive(false);
    }

}
