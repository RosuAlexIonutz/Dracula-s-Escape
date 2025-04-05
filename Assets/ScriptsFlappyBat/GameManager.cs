using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject playButton;
    public GameObject gameOver;

    public GameObject done;
    public int maxScore = 5;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        done.SetActive(true);
    }

    public void Play()
    {
        playButton.SetActive(false);
        gameOver.SetActive(false);
        done.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(obj);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        done.SetActive(false);
        Time.timeScale = 0f;
        player.enabled = false;
    }

}


