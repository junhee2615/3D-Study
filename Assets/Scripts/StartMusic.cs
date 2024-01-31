using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backMusic;

    private void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backMusic = BackgroundMusic.GetComponent<AudioSource>();   // ������� �����ص�
        if (backMusic.isPlaying) return;   // ��������� ����ǰ� �ִٸ� �н�
        else
        {
            backMusic.Play();
            DontDestroyOnLoad(BackgroundMusic);   // ������� ��� ����ϰ�(���� ��ư�Ŵ������� ����)
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
