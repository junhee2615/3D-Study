using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    public static GameMng inst;   // 싱글턴 패턴
    public GameObject gameClear;   // 게임 클리어 UI
    public GameObject gameOver;   // 게임 오버 UI
    public Image hpGuage;   // 체력 게이지
    public Text itemText;  // 아이템 획득 누적 수를 표시할 Text 컴포넌트
    public Text timerText;   // 시간을 나타낼 Text UI
    public int maxHealth = 100;   // 최대 체력 (플레이어)

    int health = 100;   // 현재 체력
    int itemCounter = 0;   // 아이템 획득 누적 수
    float gameTime = 60f;   // 1분 타이머
    private bool isGameOver = false; // 게임 오버 상태를 나타내는 플래그

    public GameObject restartBtn;   // 재시작 버튼
    public GameObject HomeBtn;   // 메인화면 버튼

    public void Awake()
    {
        if (inst == null)
            inst = this;   // GameMng 클래스 인스턴스 시정
    }

    public void SubHealth(int damage)
    {
        if (!isGameOver) // 게임 오버 상태가 아닐 때만 실행
        {
            health -= damage;   // 체력 감소
            hpGuage.fillAmount = (float)health / maxHealth;   // 체력 게이지에 반영
            if (health <= 0)   // 체력이 0이 되면
            {
                isGameOver = true;
                gameOver.SetActive(true);   // 실패 UI 보여주기
                restartBtn.SetActive(true);   // 재시작 버튼 보여주기
                //Time.timeScale = 0; // 게임 일시 정지
            }
        }
    }

    public void AddHealth(int damage)
    {
        if (!isGameOver) // 게임 오버 상태가 아닐 때만 실행
        {
            health += damage;   // 체력 증가
            hpGuage.fillAmount = (float)health / maxHealth;   // 체력 게이지에 반영
        }
    }

    public void CollectItem()
    {
        if (!isGameOver) // 게임 오버 상태가 아닐 때만 실행
        {
            itemCounter++;   // 아이템 획득 누적 수 증가
            UpdateItemText();   // 아이템 획득 누적 수 표시 업데이트
        }
    }

    // 아이템 획득 누적 수를 UI에 업데이트하는 메서드
    void UpdateItemText()
    {
        itemText.text = ": " + itemCounter.ToString();
    }

    void UpdateTimeText()
    {
        timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();   // 올림하여 정수로 표시
    }

    // Start is called before the first frame update
    void Start()
    {
        // 초기 아이템 획득 누적 수 설정
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
            gameTime -= Time.deltaTime;   // 경과 시간 감소
            UpdateTimeText();   // 시간을 UI에 업데이트

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
        // 씬을 다시 로드
        SceneManager.LoadScene("RhinoGame");
        // 재시작 버튼 비활성화
        restartBtn.SetActive(false);
        isGameOver = false;
    }
}