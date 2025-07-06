using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject GameOverScreen; // Ganti tipe dari GameOverScreen ke GameObject
    public GameObject platformPrefab;
    public int maxPlatform = 10;

    private int score = 0;
    private int platformsTouched = 0;

    private void Awake()
    {
        score = 0;
        platformsTouched = 0;
        Time.timeScale = 1f;
    }

    void Start()
    {
        SpawnPlatforms();

        // Sembunyikan Game Over Screen saat awal game
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(false);
        }
    }

    void SpawnPlatforms()
    {
        for (int i = 0; i < maxPlatform; i++)
        {
            Vector3 posisi = new Vector3(Random.Range(-2f, 2f), i * 2f, 0);
            Instantiate(platformPrefab, posisi, Quaternion.identity);
        }
    }

    void Spawn10More()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 posisi = new Vector3(Random.Range(-2f, 2f), (platformsTouched + i) * 2f, 0);
            Instantiate(platformPrefab, posisi, Quaternion.identity);
        }
    }

    public void TouchedPlatform(string name)
    {
        platformsTouched++;
        score++;

        if (platformsTouched % 10 == 0)
        {
            Spawn10More();
        }

        Debug.Log("Platform Disentuh: " + name + " | Skor: " + score);
    }

    public void GameOver()
    {
        // Tampilkan Game Over Screen dan pause game
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(true);
        }

        Time.timeScale = 0;
    }
}
