using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI TeksPoin;
    public GameObject TombolMulai;
    public GameObject GameOverPanel;
    private int score;

    private void Awake()
    {
        TombolMulai.SetActive(true);
        Application.targetFrameRate = 60;
        Pause();
    }

    public void StartGame()
    {
        score = 0;
        TombolMulai.SetActive(false);
        TeksPoin.text = score.ToString();
        GameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        //buatkan saya algoritma untuk menghapus semua pipa yang ada di scene
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("rintangan");
        GameObject[] poin = GameObject.FindGameObjectsWithTag("Poin");
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i]);
            Destroy(poin[i]);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        TeksPoin.text = score.ToString();
        
        Debug.Log("Score: " + score);
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Final Score: " + score);
        GameOverPanel.SetActive(true);
        TombolMulai.SetActive(true);
        Pause();
    }
}