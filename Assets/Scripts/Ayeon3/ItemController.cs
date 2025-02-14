using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    GameObject _player;
    GameObject _twinkle_;

    public Booster_Controller booster_Controller;
    public SomoonGauge somoon;
    public Sprite[] ItemImage;
    int saveIndex;
    public GameObject GameObject_item0, GameObject_item1;
    public TextMeshProUGUI itemName;
    public float upSpeed = 1;
    // item0, item1 => slot_item


    Slot item_slot;
    Item item;
    public static bool isBasket, usingItem;

    private void UpSpeed()
    {
        if (isBasket) return;
        else
        {
            isBasket = true;
            saveIndex = GameManager.speedIndex;
            GameManager.speedIndex = 3;
            SomoonGauge.somoonContinue = false;
            booster_Controller.Collider_UnEnable();
            Invoke("ReturnSpeed", 3f);
        }
    }

    private void ReturnSpeed()
    {
        isBasket = false;
        GameManager.speedIndex = saveIndex;
        upSpeed = 1;
        StartCoroutine(afterBooster());
        SomoonGauge.somoonContinue = true;
    }
    IEnumerator afterBooster()
    {
        for (int i = 0; i < 3; i++)
        {
            _player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
            yield return new WaitForSeconds(0.2f);
            _player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
        }
        StopCoroutine(afterBooster());
    }

    void Start()
    {
        _player = GameObject.Find("Player");
        _twinkle_ = GameObject.Find("Twinkle");

        item_slot = new Slot();
        item_slot.slot_init();
        isBasket = usingItem = false;

        GameObject_item0.SetActive(false);
        GameObject_item1.SetActive(false);

    }

    private void Update()
    {
        itemName.transform.position = new Vector2(_player.transform.position.x, _player.transform.position.y + 1f);
        if (SwipeManager.doubleTap)
        {
            if (item_slot.item_have() == 0) return;
            else _use_item_in_the_slot();
        }

        if (GameObject_item1.GetComponent<Image>().sprite != null) GameObject_item1.SetActive(true);
        else
        {
            GameObject_item1.SetActive(false);
            if(GameObject_item0.GetComponent<Image>().sprite != null) GameObject_item0.SetActive(true);
            else GameObject_item0.SetActive(false);
        }
    }

    public void _get_new_item_on_the_road()
    {
        item = new Item();

        int new_item_type;
        new_item_type = (int)item.new_random_item();
        
        int item1_type;
        
         // Update the slot item
        if (item_slot.full())
        {
            // slot_full()
            // Delete the first item
            item_slot.q.Dequeue();
            item1_type = (int)item_slot.q.Peek();
            // item0 <- item1
            GameObject_item0.GetComponent<Image>().sprite = ItemImage[item1_type];

            // Add the new item
            item_slot.q.Enqueue(new_item_type);
            // item1 <- new item
            GameObject_item1.GetComponent<Image>().sprite = ItemImage[new_item_type];
            return;
        }

        else if (item_slot.empty())
        {
            // Add the new item
            item_slot.q.Enqueue(new_item_type);
            // item0 <- new item
            GameObject_item0.GetComponent<Image>().sprite = ItemImage[new_item_type];
            return;
        }

        // Add the new item
        item_slot.q.Enqueue(new_item_type);
        // item1 <- new item
        GameObject_item1.GetComponent<Image>().sprite = ItemImage[new_item_type];
        
    }


    public void _use_item_in_the_slot()
    {
        Animator _player_animator = _player.GetComponent<Animator>();
        
        usingItem = _player.GetComponent<Animator>().GetBool("ITEM");

        if (usingItem) return;// While one item is being used, the other cannot be used.
        else
        {
            Item.item_type typetype = (Item.item_type)item_slot.q.Dequeue();

            if (item_slot.item_have() == 1)
            {
                GameObject_item0.GetComponent<Image>().sprite = ItemImage[(int)item_slot.q.Peek()];
                // item1.Sprite
                GameObject_item1.SetActive(false);
                GameObject_item1.GetComponent<Image>().sprite = null;
            }
            else if (item_slot.item_have() == 0)
            {
                // item0.Sprite
                GameObject_item0.SetActive(false);
                GameObject_item0.GetComponent<Image>().sprite = null;
            }
            StartCoroutine(showItem());

            // ITEM USE FUNCTION 
            if (typetype == Item.item_type.wig)
            {
                // WIG = FULL DAMAGE COVER
                
                itemName.text = "빨간 가발" + System.Environment.NewLine + "착용중";
                if(MainMenu.AudioPlay) AudioManager.wigHatAudio.Play();
                _player_animator.SetBool("W",true);
                // twinkle on
                _twinkle_.GetComponent<Animator>().SetBool("T",true);
            }
            else if (typetype == Item.item_type.hat)
            {
                // HAT = HALF DAMAGE COVER

                itemName.text = "모자" + System.Environment.NewLine + "착용중";
                if (MainMenu.AudioPlay) AudioManager.wigHatAudio.Play();
                _player_animator.SetBool("H",true);
                // twinkle on
                _twinkle_.GetComponent<Animator>().SetBool("T",true);
            }
            else if (typetype == Item.item_type.death_berry)
            {
                itemName.text = "마녀의 열매"+System.Environment.NewLine+"사람들에게 먹이기 성공";
                somoon.LowerSomoon();
            }
            else if (typetype == Item.item_type.basket)
            {
                _player_animator.SetBool("B",true);
                itemName.text = "바구니 타고" + System.Environment.NewLine + "날아가는 중";
                if (MainMenu.AudioPlay) AudioManager.boosterAudio.Play();
                // twinkle on
                _twinkle_.GetComponent<Animator>().SetBool("T",true);
                booster_Controller.Collider_UnEnable();
                UpSpeed();
            }
            else //typetype == Item.item_type.green_yum
            {
               _player_animator.SetBool("G",true);
                itemName.text = "쓸데없는"+System.Environment.NewLine+"초록색 염색약이군..";
                _player_animator.SetBool("MJ", false);
                SomoonGauge.somoonContinue = true;
                if (MainMenu.AudioPlay) AudioManager.eraserAudio.Play();
            }
        }
    }
    IEnumerator showItem()
    {
        Animator _player_animator = _player.GetComponent<Animator>();
        itemName.gameObject.SetActive(true);
        if(_player_animator.GetBool("B")) yield return new WaitForSeconds(5f);
        else yield return new WaitForSeconds(2f);
        itemName.gameObject.SetActive(false);    
        StopCoroutine(showItem());
    }
}

public class Item
{
    public enum item_type
    {
        wig,
        hat,
        death_berry,
        basket,
        green_yum
    }

    public item_type new_random_item()
    {
        item_type new_item;
        new_item = (item_type)Random.Range(0, 5);

        return new_item;
    }
}

public class Slot
{
    public Queue<int> q;

    public void slot_init()
    {
        q = new Queue<int>();
    }

    public int item_have()
    {
        return q.Count;
    }

    public bool empty()
    {
        return (q.Count == 0);
    }

    public bool full()
    {
        return (q.Count == 2);
    }
}