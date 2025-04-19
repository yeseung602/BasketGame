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
        // gameOverPanel �Y��ȭ
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        // score���� ��������
        gameOverText.GetComponent<TextMeshProUGUI>().text = scoreText.GetComponent<TextMeshProUGUI>().text;
        
    }

    public void Retry()
    {
       Time.timeScale = 1f; // ���� �����
        SceneManager.LoadScene("GameScene");
    }
}
