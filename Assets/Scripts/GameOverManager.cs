using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameOverText;
    public GameObject scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ShowGameOver()
    {
        // gameOverPanel 홠ㅇ화
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        // score점수 가져오기
        gameOverText.GetComponent<TextMeshProUGUI>().text = scoreText.GetComponent<TextMeshProUGUI>().text;
        
    }

    public void Retry()
    {
       Time.timeScale = 1f; // 게임 재시작
        SceneManager.LoadScene("GameScene");
    }
}
