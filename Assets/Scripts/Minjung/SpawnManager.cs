using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] SideMobs;
    public GameObject[] Item;
    public GameObject[] BackGround;
    public GameObject[] Road;
    public static int MobStartNum = 0; // SpawnManager ���� ���� Mob�� �����ϴ� �� ����
    int x_Back;

    public float startNum_Create, finalNum_Create; // mob ���尣�� �ð� ����. startNum: �ּ� �ð� ����, finalNum: �ִ� �ð� ����
    private void Start()
    {
        x_Back = 0;
        StartCoroutine(CreateMob());
        StartCoroutine(CreateRoad());
        StartCoroutine(CreateBack());
        StartCoroutine(CreateItem());
        StartCoroutine(CreateColor());
    }
    IEnumerator CreateMob() // ��������� ����
    {
        yield return new WaitForSeconds(3f); // �����ϰ� 3�� �ĺ��� Mob ����
        while (true)
        {
            if (GameManager.isPlay)
            {
                float time = Random.Range(startNum_Create, finalNum_Create); // ����������� �����ϴ� �ð� ����
                SideMobs[DeactiveMob()].SetActive(true); // ��Ȱ��ȭ�� Mob�� �߿��� 1���� Ȱ��ȭ
                yield return new WaitForSeconds(time);
                
                if (MobStartNum ==0)
                    MobStartNum++;
            }
            else
            {
                yield return new WaitForSeconds(GameManager.instance.Count.Length);
            }
            yield return null;
        }
    }
    IEnumerator CreateItem() // ������ �ָӴ�:  2�ʸ��� ����
    {
        while (true)
        {
            if (GameManager.isPlay)
            {
                Item[0].SetActive(true); // �������ָӴ� Ȱ��ȭ
                yield return new WaitForSeconds(2); // �������� ������ ��, ���� ������ ���� �������� ����
            }
            else
            {
                yield return new WaitForSeconds(GameManager.instance.Count.Length);
            }
            yield return null;
        }
    }
    IEnumerator CreateColor() // Ż���� -> ������ ������ ����
    {
        while (true)
        {
            if (GameManager.isPlay)
            {
                Item[1].SetActive(true); // Ż���� Ȱ��ȭ �Ŀ� ������ Ȱ��ȭ
                yield return new WaitForSeconds(1);
                Item[2].SetActive(true);
                yield return new WaitForSeconds(3);
            }
            else
            {
                yield return new WaitForSeconds(GameManager.instance.Count.Length);
            }
            yield return null;
        }
    }
    IEnumerator CreateBack() // Ǯ,����,�� ����
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            if (GameManager.isPlay)
            {
                
                if (x_Back <= 22) // ��
                {
                    BackGround[x_Back].SetActive(true);
                    yield return new WaitForSeconds(0.3f);
                    BackGround[x_Back + 1].SetActive(true);
                    if (x_Back == 22)
                        yield return new WaitForSeconds(10f);
                    else
                        yield return new WaitForSeconds(0.5f);
                    x_Back +=2;
                }
                else // ����
                {
                    if(x_Back == 25||x_Back==30 || x_Back == 34 || x_Back == 39 || x_Back == 44) { BackGround[x_Back].SetActive(true); x_Back++; }
                    BackGround[x_Back].SetActive(true);
                    yield return new WaitForSeconds(0.8f);
                    x_Back++;
                    if (x_Back == BackGround.Length)
                    {
                        x_Back = 0;
                        yield return new WaitForSeconds(9.2f);
                    }
                }  
                
            }
            else
            {
                yield return new WaitForSeconds(GameManager.instance.Count.Length);
            }
            yield return null;
        }
    }
    IEnumerator CreateRoad() // ��ֹ� ����
    {
        while (true)
        {
            if (GameManager.isPlay)
            {
                Road[DeactiveRoad()].SetActive(true);
                yield return new WaitForSeconds(Random.Range(1, 3));
            }
            else
            {
                yield return new WaitForSeconds(GameManager.instance.Count.Length);
            }
            yield return null;
        }
    }

    int DeactiveMob() // ��Ȱ��ȭ�� Mob�߿��� �����ϴ� �Լ�
    {
        List<int> num = new List<int>();
        for(int i = 0; i < SideMobs.Length; i++)
        {
            if (!SideMobs[i].activeSelf) // ��Ȱ��ȭ�� Mob�� �ε����� List�� �߰�
            {
                num.Add(i);
            }
        }
        int x = 0;
        if (num.Count > 0)
        {
            x = num[Random.Range(0, num.Count)]; 
        }
        return x; // ��Ȱ��ȭ�� Mob�� �ε����� 1���� ��ȯ
    }
    
    int DeactiveRoad() // ��Ȱ��ȭ�� ��ֹ��߿��� �����ϴ� �Լ�
    {
        List<int> num = new List<int>();
        for(int i=0; i< Road.Length; i++)
        {
            if (!Road[i].activeSelf)
            {
                num.Add(i);
            }
        }
        int x = 0;
        if(num.Count > 0)
        {
            x = num[Random.Range(0, num.Count)];
        }
        return x;
    }
}
