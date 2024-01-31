using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    public static GameMng inst;   // �̱��� ����
    public GameObject gameClear;   // ���� Ŭ���� UI
    public GameObject gameOver;   // ���� ���� UI
    public Image hpGuage;   // ü�� ������
    public Text itemText;  // ������ ȹ�� ���� ���� ǥ���� Text ������Ʈ
    public Text timerText;   // �ð��� ��Ÿ�� Text UI
    public int maxHealth = 100;   // �ִ� ü�� (�÷��̾�)

    int health = 100;   // ���� ü��
    int itemCounter = 0;   // ������ ȹ�� ���� ��
    float gameTime = 60f;   // 1�� Ÿ�̸�
    private bool isGameOver = false; // ���� ���� ���¸� ��Ÿ���� �÷���

    public GameObject restartBtn;   // ����� ��ư
    public GameObject HomeBtn;   // ����ȭ�� ��ư

    public void Awake()
    {
        if (inst == null)
            inst = this;   // GameMng Ŭ���� �ν��Ͻ� ����
    }

    public void SubHealth(int damage)
    {
        if (!isGameOver) // ���� ���� ���°� �ƴ� ���� ����
        {
            health -= damage;   // ü�� ����
            hpGuage.fillAmount = (float)health / maxHealth;   // ü�� �������� �ݿ�
            if (health <= 0)   // ü���� 0�� �Ǹ�
            {
                isGameOver = true;
                gameOver.SetActive(true);   // ���� UI �����ֱ�
                restartBtn.SetActive(true);   // ����� ��ư �����ֱ�
                //Time.timeScale = 0; // ���� �Ͻ� ����
            }
        }
    }

    public void AddHealth(int damage)
    {
        if (!isGameOver) // ���� ���� ���°� �ƴ� ���� ����
        {
            health += damage;   // ü�� ����
            hpGuage.fillAmount = (float)health / maxHealth;   // ü�� �������� �ݿ�
        }
    }

    public void CollectItem()
    {
        if (!isGameOver) // ���� ���� ���°� �ƴ� ���� ����
        {
            itemCounter++;   // ������ ȹ�� ���� �� ����
            UpdateItemText();   // ������ ȹ�� ���� �� ǥ�� ������Ʈ
        }
    }

    // ������ ȹ�� ���� ���� UI�� ������Ʈ�ϴ� �޼���
    void UpdateItemText()
    {
        itemText.text = ": " + itemCounter.ToString();
    }

    void UpdateTimeText()
    {
        timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();   // �ø��Ͽ� ������ ǥ��
    }

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ������ ȹ�� ���� �� ����
        UpdateItemText();
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            gameTime -= Time.deltaTime;   // ��� �ð� ����
            UpdateTimeText();   // �ð��� UI�� ������Ʈ

            if (gameTime <= 0)
            {
                if (hpGuage.fillAmount > 0)
                {
                    isGameOver = true;
                    gameClear.SetActive(true);
                    Time.timeScale = 0;
                    Button homeButton = HomeBtn.GetComponent<Button>();
                    HomeBtn.SetActive(true);
                    homeButton.onClick.AddListener(LoadGameScene);
                }
            }
        }
    }

    public void Restart()
    {
        // ���� �ٽ� �ε�
        SceneManager.LoadScene("RhinoGame");
        // ����� ��ư ��Ȱ��ȭ
        restartBtn.SetActive(false);
        isGameOver = false;
    }
}