using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject playButton;
    [SerializeField] private Player player;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        gameOver.SetActive(false);

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsByType<Pipes>(FindObjectsSortMode.None);

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
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
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
}
