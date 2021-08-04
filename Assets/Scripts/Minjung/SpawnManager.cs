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
   // int MobCreateNum = 0;
   //int ItemCreateTerm; // Mob�� ItemCreateTerm�� ������ ������ Item 1�� ����
    int BackCreateNum = 0; // Ǯ,����,�� �������� ��

    public float startNum_Create, finalNum_Create; // mob ���尣�� �ð� ����. startNum: �ּ� �ð� ����, finalNum: �ִ� �ð� ����
    private void Start()
    {
        StartCoroutine(CreateMob());
        StartCoroutine(CreateRoad());
        StartCoroutine(CreateItem());
        StartCoroutine(CreateColor());
    }
    IEnumerator CreateMob() // ��������� ����
    {
        int BackNum = Random.Range(1, 4); // Ǯ, ����, �� ���� term
        yield return new WaitForSeconds(3f); // �����ϰ� 3�� �ĺ��� Mob ����
        while (true)
        {
            if (GameManager.isPlay)
            {
                float time = Random.Range(startNum_Create, finalNum_Create); // ����������� �����ϴ� �ð� ����
                SideMobs[DeactiveMob()].SetActive(true); // ��Ȱ��ȭ�� Mob�� �߿��� 1���� Ȱ��ȭ
                BackCreateNum++;
                yield return new WaitForSeconds(time/2);
                if (BackCreateNum == BackNum) // ����������� BackNum�� �����ɶ����� Ǯ/����/�� �� 1�� Ȱ��ȭ
                {
                    BackGround[DeactiveBack()].SetActive(true);
                    yield return new WaitForSeconds(time / 2);
                    BackCreateNum = 0;
                    BackNum = Random.Range(1, 3);
                }
                else
                {
                    yield return new WaitForSeconds(time / 2);
                }
                if (MobStartNum ==0)
                {
                    MobStartNum++;
                }
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
            yield return null;
        }
    }
    IEnumerator CreateRoad() // ��ֹ� ����
    {
        while (true)
        {
            if (GameManager.score %50 == 0 && GameManager.isPlay) // ������ 50�� ����� �ɶ����� ����
            {
                int score = GameManager.score;
                int num = Random.Range(15, 20); // �������� ��ֹ��� �������� ����
                while (GameManager.score <= score + num) // ������ 50n + num�� �ɶ����� ��ֹ� ����
                {
                    Road[DeactiveRoad()].SetActive(true);
                    yield return new WaitForSeconds(Random.Range(1, 2));

                }
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
    int DeactiveBack()
    {
        List<int> num = new List<int>();
        for(int i=0; i < BackGround.Length; i++)
        {
            if (!BackGround[i].activeSelf)
            {
                num.Add(i);
            }
        }
        int x = 0;
        if(num.Count > 0)
        {
            x = num[Random.Range(0, num.Count)];
        }
        return x; // ��Ȱ��ȭ�� BackGround�� �ε����� 1���� ��ȯ
    }
    
    int DeactiveRoad()
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
    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj); // �Ű������� ���� ���� ������Ʈ�� ����
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
}
