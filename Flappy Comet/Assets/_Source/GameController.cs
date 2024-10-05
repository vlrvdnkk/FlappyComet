using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject comet;
    public GameObject enemyPrefab;
    public GameObject bonusPrefab;
    public TextMeshProUGUI scoreText;
    public float enemySpawnInterval = 2f;
    public float bonusSpawnInterval = 5f;

    private int score;
    private float screenWidth;
    private float screenHeight;

    private void Awake()
    {
        Instance = this;
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        screenHeight = Camera.main.orthographicSize;
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnBonuses());
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "" + score;
    }

    public void RestartGame()
    {
        // Logic to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float spawnX = screenWidth + 1f;
            float spawnY = Random.Range(-screenHeight + 1f, screenHeight - 1f);
            Instantiate(enemyPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnInterval);
        }
    }

    private IEnumerator SpawnBonuses()
    {
        while (true)
        {
            float spawnX = screenWidth + 1f;
            float spawnY = Random.Range(-screenHeight + 1f, screenHeight - 1f);
            Instantiate(bonusPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
            yield return new WaitForSeconds(bonusSpawnInterval);
        }
    }
}
