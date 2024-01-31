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
        backMusic = BackgroundMusic.GetComponent<AudioSource>();   // 배경음악 저장해둠
        if (backMusic.isPlaying) return;   // 배경음악이 재생되고 있다면 패스
        else
        {
            backMusic.Play();
            DontDestroyOnLoad(BackgroundMusic);   // 배경음악 계속 재생하게(이후 버튼매니저에서 조작)
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
