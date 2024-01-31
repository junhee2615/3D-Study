using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnMng : MonoBehaviour
{
    public GameObject startBtn;   // ���� ��ư
    public GameObject startBtn2;   // ���� ��ư2
    public GameObject InfoBtn;   // ���Ӽ��� ��ư
    public GameObject InfoImage;   // ���Ӽ��� �̹���

    // Start is called before the first frame update
    void Start()
    {
        Button startButton = startBtn.GetComponent<Button>();
        startButton.onClick.AddListener(LoadGameScene);

        Button infoButton = InfoBtn.GetComponent<Button>();
        infoButton.onClick.AddListener(ToggleInfoImage);
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("RhinoGame");
    }

    void ToggleInfoImage()
    {
        InfoImage.SetActive(!InfoImage.activeSelf);
        Button startButton2 = startBtn2.GetComponent<Button>();
        startButton2.onClick.AddListener(LoadGameScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
