using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene_Manager : MonoBehaviour
{
    static string nextScene;
    [SerializeField]
    public bool fin;
    public Slider LoadingBar;
    public GameObject LoadingAudio;
    public Text tip;
    string[][] tips = new string[7][];

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    
    void Update()
    {
        if (fin)
            LoadingBar.value = 1;
        
    }
    
    
    IEnumerator LoadSceneProcess()
    {
        tips[0] = new string[] {"Tip. ���ϴ� ��ġ�ؼ�","��� �� �־��"};
        tips[1] = new string[] {"Tip. ���� �ٸ��� �̿��ؼ�", "�ǳ� �� �־��" };
        tips[2] = new string[] {"Tip.�����ڸ��� ������","�����̿� �ε��� Ȯ���� �پ����" };
        tips[3] = new string[] {"Tip.�����Ӹ��� �����ϸ�", "������� �þ߿� ���� �����ƿ�" };
        tips[4] = new string[] {"Tip.�������� �����ϸ�","���� 5���� ���� �� �־��" };
        tips[5] = new string[] {"Tip.������ ����̵��� �ڰ�������","�����ʵ��� �����ؾ��ؿ�" };
        tips[6] = new string[] {"Tip.�������� �� ���������","�þ߰� ������ �����ϼ���" };
        int tipNum = Random.Range(0, 7);
        LoadingAudio = GameObject.Find("LoadingAudio");
        tip.text = tips[tipNum][0] + System.Environment.NewLine + tips[tipNum][1];
        if (MainMenu.AudioPlay) LoadingAudio.GetComponent<AudioSource>().Play();
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = fin = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                LoadingBar.value = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                LoadingBar.value = Mathf.Lerp(0.9f, 1f, timer);
                if(LoadingBar.value >= 1f)
                {
                    fin = true;
                    yield return new WaitForSeconds(1f);
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(1f);
        op.allowSceneActivation = true;
    }

}
