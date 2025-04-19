using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemGenerator : MonoBehaviour
{
    public GameOverManager gameOverManager;
    public GameObject appleGo;
    public GameObject bombGO;
    public GameObject addGo;
    float span = 1.0f;
    float delta = 0.0f;
    int ratio = 2;
    int ratioAdd = 3; // 더하기가 나올 확률
    float speed = -1.0f;

    public GameObject timerText;
    public GameObject scoreText;
    public float time = 60.0f;
    public int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void Setparametes(float span, int ratio, float speed, int ratioAdd)
    {
        this.span = span;
        this.ratio = ratio;
        this.speed = speed;
        this.ratioAdd = ratioAdd;
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span) {

            // span 초마다 수행하고 싶은 내용
            delta = 0.0f;
            GameObject item;
            int dice = Random.Range(1, 11); // 1 ~ 10까지의 랜덤한 수 반환

            if (time <= 30)
            {
                Debug.Log(dice);
                if (dice <= ratio) item = Instantiate(bombGO);
                // 1확률로 더하기 객체 생성
                else if (dice == ratioAdd) item = Instantiate(addGo);
                else item = Instantiate(appleGo);

                // -1 ~ 1 사이의 랜덤한 int값
                float x = Random.Range(-1, 2);
                float z = Random.Range(-1, 2);
                item.transform.position = new(x, 4, z);

                ItemController controller = item.GetComponent<ItemController>();
                if (controller != null)
                {
                    // Debug.Log(speed);
                    controller.dropspeed = speed;
                }
            }
            else if(time > 30)
            {
                if (dice <= ratio) item = Instantiate(bombGO);
                else item = Instantiate(appleGo);

                // -1 ~ 1 사이의 랜덤한 int값
                float x = Random.Range(-1, 2);
                float z = Random.Range(-1, 2);
                item.transform.position = new(x, 4, z);

                ItemController controller = item.GetComponent<ItemController>();
                if (controller != null)
                {
                    // Debug.Log(speed);
                    controller.dropspeed = speed;
                }
            }


        }

        

        time -= Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = "Time : " + time.ToString("F1");

        // 먼저 시간 끝났는지 확인!
        if (time <= 0f)
        {
            time = 0f;
            Time.timeScale = 0f;
            gameOverManager.ShowGameOver(); // 게임오버 UI 띄우기
            return; // 이후 코드 실행 막기
        }

        // 이 코드는 그다음에 실행됨
        if (time > 30) Setparametes(3.0f, 1, -1.0f, 0);
        else Setparametes(1.0f, 5, -2.0f, 10);
    }

    public void GetApple()
    {
        score += 100;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + score;
    }

    public void GetBomb()
    {
        score /= 2;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + score;
    }


    // +객체를 담으면 10초 추가하는 메소드
    public void GetTime()
    {
        time = time+10;
        timerText.GetComponent<TextMeshProUGUI>().text = "Time : " + time;
    }
    
}
