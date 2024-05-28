using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject puddlePrefab; // Reference to the puddle prefab
    private int puddleCount = 10;
    public Vector3 spawnAreaMin; // Minimum bounds for puddle spawning
    public Vector3 spawnAreaMax; // Maximum bounds for puddle spawning
    private int score;

    private int cleanedCount = 0;
    private int wallCount = 0;
    private int totalTime = 0;
    public float time = 0f;
    private bool isTimerRunning = false;

    public Canvas StartCanvas;
    public Canvas EndCanvas;

    public TMP_Text textMeshPro; // Reference to the TextMeshPro text component

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        StartCanvas.gameObject.SetActive(!StartCanvas.gameObject.activeSelf);
        SpawnPuddles();
        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            // Update the remaining time
            time += Time.deltaTime;
        }
    }

    public void PuddleCounter()
    {
        cleanedCount++;
        Debug.Log("Puddles Cleaned: " + cleanedCount);
        puddleCount--;

        if (puddleCount == 0)
        {
            isTimerRunning=false;
            totalTime = (int)time;
            Debug.Log("total time: " + totalTime);
            score = (cleanedCount * 10) / ((wallCount) + (totalTime /5));
            Debug.Log("Completed with a score of: " + score);
            EndGame();
        }
    }

    public void WallCounter()
    {
        wallCount++;
        Debug.Log("Walls Hit: " + wallCount);
    }

    void SpawnPuddles()
    {
        for (int i = 0; i < puddleCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                1.1f,
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            Instantiate(puddlePrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void EndGame()
    {
        EndCanvas.gameObject.SetActive(!EndCanvas.gameObject.activeSelf);
        textMeshPro.text = "Completed with a score of:  " + score;
        PlayerPrefs.SetInt("HighscoreBoen", score);
    }
}
