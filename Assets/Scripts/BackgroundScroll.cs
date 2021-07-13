using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material mat; // Material �ν��Ͻ�
    float current_Y = 0; // ��� �̹����� Y��ǥ
    public float speed; // ��� �̹����� ��ũ�� �ӵ�
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material; 
    }

    void Update()
    {
        current_Y += speed * Time.deltaTime;
        mat.mainTextureOffset = new Vector2(0, current_Y);
    }
}
