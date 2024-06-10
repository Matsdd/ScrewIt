// PaintVatScript.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintVatScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float redAmount, blueAmount, yellowAmount;
    public Color targetColor;
    public int score = 0;
    private int totalPumpsUsed = 0;
    private List<Color> validColors;

    public Image targetColorImage;  // Reference to the UI Image for the target color
    public Button resetButton;      // Reference to the Reset Button
    public Button compareButton;    // Reference to the Compare Button
    public Text timerText;          // Reference to the Timer Text
    public GameObject timesUpAlert; // Reference to the Time's Up Alert
    public Text scoreText;          // Reference to the Score Text
    public Text currentScore;

    public float gameDuration = 60f; // Game duration in seconds
    private float timeRemaining;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InitializeValidColors();
        ResetVat();
        GenerateNewTargetColor();

        // Assign the Reset function to the button's onClick event
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetVat);
        }

        // Assign the Compare function to the button's onClick event
        if (compareButton != null)
        {
            compareButton.onClick.AddListener(CompareColors);
        }

        timeRemaining = gameDuration;
        timesUpAlert.SetActive(false); // Hide the alert initially
        UpdateScoreText();
    }

    void Update()
    {
        UpdateVatColor();
        UpdateTimer();
    }

    public void AddColor(string color)
    {
        if (totalPumpsUsed >= 4) return;  // Limit the maximum number of pump uses

        if (color == "Blue")
        {
            blueAmount += 1;
        }
        if (color == "Red")
        {
            redAmount += 1;
        }
        if (color == "Yellow")
        {
            yellowAmount += 1;
        }
        totalPumpsUsed++;
        UpdateVatColor();
    }

    private void UpdateVatColor()
    {
        if (totalPumpsUsed > 0)
        {
            float total = redAmount + yellowAmount + blueAmount;
            _spriteRenderer.color = new Color(
                redAmount / total,
                yellowAmount / total,
                blueAmount / total
            );
        }
        else
        {
            _spriteRenderer.color = Color.white;  // Set to base color
        }
    }

    private void CompareColors()
    {
        if (ColorsAreClose(_spriteRenderer.color, targetColor))
        {
            score += 1;
            Debug.Log("Correct match! Score: " + score);
            currentScore.text = "Score: " + score;
            UpdateScoreText();
            ResetVat();
            GenerateNewTargetColor();
        }
    }

    private bool ColorsAreClose(Color color1, Color color2)
    {
        float tolerance = 0.01f;
        return Mathf.Abs(color1.r - color2.r) < tolerance &&
               Mathf.Abs(color1.g - color2.g) < tolerance &&
               Mathf.Abs(color1.b - color2.b) < tolerance;
    }

    private void ResetVat()
    {
        redAmount = 0;
        blueAmount = 0;
        yellowAmount = 0;
        totalPumpsUsed = 0;
        _spriteRenderer.color = Color.white;  // Set to base color
    }

    private void GenerateNewTargetColor()
    {
        int randomIndex = Random.Range(0, validColors.Count);
        targetColor = validColors[randomIndex];
        Debug.Log("New target color: " + targetColor);

        if (targetColorImage != null)
        {
            targetColorImage.color = targetColor;
        }
    }

    private void InitializeValidColors()
    {
        validColors = new List<Color>
        {
            // Colors that can be made with 2 to 4 pump uses, ensuring they are achievable
            new Color(1, 0, 0),          // Red (2 Red)
            new Color(0, 1, 0),          // Yellow (2 Yellow)
            new Color(0, 0, 1),          // Blue (2 Blue)
            new Color(0.5f, 0.5f, 0),    // Orange (1 Red + 1 Yellow)
            new Color(0.5f, 0, 0.5f),    // Purple (1 Red + 1 Blue)
            new Color(0, 0.5f, 0.5f),    // Green (1 Yellow + 1 Blue)
            new Color(1/3f, 1/3f, 1/3f),  // Neutral Grey (1 Red + 1 Yellow + 1 Blue)
            new Color(0.75f, 0.25f, 0),  // Yellow-Orange (3 Yellow + 1 Red)
            new Color(0.25f, 0, 0.75f),  // Red-Purple (3 Blue + 1 Red)
            new Color(0, 0.75f, 0.25f)   // Blue-Green (3 Yellow + 1 Blue)
            // Add more predefined colors as needed
        };
    }

    private void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Floor(timeRemaining).ToString();
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "Time: 0";
            timesUpAlert.SetActive(true);
            // Optionally, add logic to stop the game or transition to another scene
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
