using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerGeneral : MonoBehaviour
{
    public static GameManagerGeneral instance;
    public PlayerManager player;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject done;

    private bool miniGameSolved = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

        PlayerManager.instance.health = 100;
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        done.SetActive(false);
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void ApplyDamage(int damage)
    {
        PlayerManager.instance.TakeDamage(damage);
    }

    public void GoToMiniGame(string miniGameSceneName)
    {
        SceneManager.LoadScene(miniGameSceneName);
    }

    public void ReturnToMainGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void SetMiniGameStatus(bool success)
    {
        miniGameSolved = success;
    }

    public void ReturnToMainGameWithSuccess(bool success)
    {
        if (success)
        {
            Debug.Log("Mini-game completat cu succes! Jucatorul se intoarce in jocul principal.");
        }
        else
        {
            Debug.Log("Mini-game nereusit! Jucatorul se intoarce in jocul principal.");
        }

        SceneManager.LoadScene("MainGameScene");
    }
}
