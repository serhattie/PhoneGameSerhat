using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject brickPref;
    public float spawnRate;
    bool gameStarted = false;
    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    private Player player;

    Vector2 screenPos;
    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        if (transform.GetComponent<InputSys>().IsPressing(out screenPos) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnBrick", 0.5f, spawnRate);
    }
    void SpawnBrick()
    {
        Camera cam = Camera.main;

        float randomX = Random.Range(0f, 1f);

        Vector3 viewportPos = new Vector3(randomX, 1f, 0f);
        Vector3 worldPos = cam.ViewportToWorldPoint(viewportPos);

        worldPos.y += 1f;
        worldPos.z = 0f;

        Instantiate(brickPref, worldPos, Quaternion.identity);

        int newScore = player.GetAttributes().GetCurrentScore() + 1;
        player.GetAttributes().SetCurrentScore(newScore);

        UpdateText(newScore);
    }

    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }
}