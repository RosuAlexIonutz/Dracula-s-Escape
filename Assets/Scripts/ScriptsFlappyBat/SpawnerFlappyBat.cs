using UnityEngine;

public class SpawnerFlappyBat : MonoBehaviour
{
    public GameObject prefab;
    public PlayerFlappyBat player;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    public GameObject done;
    private int spawnCount = 0;
    public int maxSpawns = 5;

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        done.SetActive(true);
    }

    private void OnEnable()
    {
        spawnCount = 0;
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        Invoke(nameof(Pause), 10f);
    }

    private void EndGame()
    {
        CancelInvoke(nameof(Spawn));
        done.SetActive(true);
        Pause();
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (spawnCount >= maxSpawns)
        {
            CancelInvoke(nameof(Spawn));
            return;
        }

        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight / 2, maxHeight / 2);
        spawnCount++;
    }
}
