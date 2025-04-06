using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerFlappyBat : MonoBehaviour
{
    public PlayerFlappyBat player;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject done;

    private bool miniGameSolved = false;
    private AttributesManager playerAttributes;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        playerAttributes = player.GetComponent<AttributesManager>();
        Pause();
    }

    public void CompleteMiniGame(bool success)
    {
        SetMiniGameStatus(success);

        if (success)
        {
            ReturnToMainGameWithSuccess();
        }
        else
        {
            GameOver();
        }
    }

    public void SetMiniGameStatus(bool success)
    {
        miniGameSolved = success;
    }

    public void ReturnToMainGameWithSuccess()
    {
        if (miniGameSolved)
        {
            Debug.Log("Mini-game completat cu succes! Intoarcere la jocul principal.");

            if (playerAttributes != null)
            {
                PlayerManager.instance.health = playerAttributes.health;
            }

            SceneManager.LoadScene("MainGameScene");
            Time.timeScale = 1;
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

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        done.SetActive(true);
    }
}
