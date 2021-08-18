using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject stopPanel;
    public GameObject fadeSprite;
    public GameObject[] Count;
    public GameObject[] Berry;
    public GameObject SpeedUpTxt;

    void Start()
    {
        stopPanel.SetActive(false); // �г� �����
        fadeSprite.SetActive(false);
        SpeedUpTxt.SetActive(false);

        for(int i = 0; i < Count.Length; i++)
        {
            Count[i].SetActive(false);
        }
        for(int i = 0; i < Berry.Length; i++)
        {
            Berry[i].SetActive(false);
        }
    }

}
