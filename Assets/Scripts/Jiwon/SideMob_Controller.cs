using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMob_Controller : MonoBehaviour
{
    public Animator[] mob_ani;
    public SpriteRenderer[] spriteRenderers;
    public BoxCollider[] mob_collider;
    public GameObject[] mobs;

    //������ ���� ���� ���ۺ��� �ִϸ��̼� ON
    public void Set()
    {
        //for���� �ִϸ��̼� �ִ� ����ĳ���Ϳ��� ����
        for(int i = 0; i < mob_ani.Length; i++)
        {
            mob_ani[i].SetBool("isErase", true);
        }

        //�ִϸ��̼� ���� �ֵ��� �̹����� ��ü
        for(int i = 0; i < mobs.Length; i++)
        {
            spriteRenderers[i].sprite = mobs[i].GetComponent<MobBase>().sprites[2];
        }
        for(int i=0;i<mob_collider.Length;i++)
            mob_collider[i].enabled = false;

        Invoke("UnSet", 2f);    //������ ���� ȿ�� 2�ʵ��� ����
    }

    //������ ���� ȿ�� ����
    public void UnSet()
    {
        for (int i = 0; i < mob_ani.Length; i++)
        {
            mob_ani[i].SetBool("isErase", false);
        }

        for (int i = 0; i < mobs.Length; i++)
        {
            spriteRenderers[i].sprite = mobs[i].GetComponent<MobBase>().sprites[0];
        }
        for (int i = 0; i < mob_collider.Length; i++)
            mob_collider[i].enabled = true;
    }
}
