using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomoonGauge : MonoBehaviour
{
    public GameManager gameManager;
    public float adultFirstTouchTime;
    public float childFirstTouchTime;
    float startTime;
    public float realTime;

    public float somoonGauge;
    public int adultTouch_Num;
    public int childTouch_Num;

    // Update is called once per frame
    void Awake()
    {
        startTime = Time.time;
        somoonGauge = 0;


    }

    void Update()
    {
        //��������ð� ������Ʈ
        realTime = Time.time - startTime;
        SomoonCtrl();
        /*if (Input.GetKey(KeyCode.P) && GameManager.isPlay == true)
        {
            somoonGauge += 1;
        }
        if (somoonGauge >= 100.0f)
        {
            gameManager.GameOver();
        }*/ //�ҹ������� �׽�Ʈ�� �ڵ�. Ű���� P�� ������ �ҹ��������� �ö�
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Radar" && GameManager.isPlay == true)
        {
            //�ε��� �� ����� �������� ����
            bool isAdult = collision.gameObject.name.Contains("Adult");
            bool isChildren = collision.gameObject.name.Contains("Children");

            //��� ó�� �ε����� ���
            if (isAdult && adultTouch_Num == 0)
            {
                adultTouch_Num++;
                adultFirstTouchTime = realTime;  //ó�� �ε��� �ð� ����

            }

            //��� n��° �ε�ģ ���
            else if (isAdult && adultTouch_Num != 0)
            {
                adultTouch_Num++;

            }

            //���̿� ó�� �ε����� ���
            else if (isChildren && childTouch_Num == 0)
            {
                childTouch_Num++;
                childFirstTouchTime = realTime;  //ó�� �ε��� �ð� ����

            }

            //���̿� n ��° �ε��� ���
            else if (isChildren && childTouch_Num != 0)
            {
                childTouch_Num++;

            }
        }
    }

    public void SomoonCtrl()
    {
        if(somoonGauge >= 100.0f)
        {
            gameManager.GameOver();
        }
        else
        {
            somoonGauge = 0.5f * (adultTouch_Num + childTouch_Num * 2);

            if(adultTouch_Num != 0)
            {
                somoonGauge += 0.5f * (realTime - adultFirstTouchTime);
            }

            if(childTouch_Num != 0)
            {
                somoonGauge += 0.8f * (realTime - childFirstTouchTime);
            }
        }
    }
}
