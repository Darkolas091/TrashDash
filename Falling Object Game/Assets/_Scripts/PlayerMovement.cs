using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text counterComboShow;
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text endScoreText;

    private int increaseLifeCounter = 0;
    [SerializeField] private int comboCounter = 0;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentLives = maxLives;
        livesText.text = currentLives.ToString();
        scoreText.text = "Score: " + score;
    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A) && transform.position.x > -7)
        {
            Move(Vector2.right);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 7)
        {
            Move(Vector2.left);
        }
    }

    private void Move(Vector2 direction)
    {
        direction.Normalize();
        Vector2 targetVelocity = direction * speed;
        playerRigidbody.linearVelocity =
            Vector2.Lerp(playerRigidbody.linearVelocity, targetVelocity, 10 * Time.deltaTime);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
        if (amount > 0)
        {
            AudioManager.Instance.PlayPickupGood();
            increaseLifeCounter++;
            comboCounter++;

            if (comboCounter >= 5)
            {
                counterComboShow.gameObject.SetActive(true);
                counterComboShow.text = "Combo: " + comboCounter;
            }
            else
            {
                counterComboShow.gameObject.SetActive(false);
            }
            if (increaseLifeCounter >= 25)
            {
                AddLife();
                livesText.text = currentLives.ToString();
                increaseLifeCounter = 0;
            }
        }
        else
        {
            AudioManager.Instance.PlayPickupBad();
            increaseLifeCounter = 0;
            comboCounter = 0;
            counterComboShow.gameObject.SetActive(false);
            RemoveLife();
        }
    }

    public void RemoveLife()
    {
        currentLives--;
        Debug.Log("Removing Lives: " + currentLives);
        livesText.text = currentLives.ToString();
        if (currentLives <= 0)
        {
            GameOver();
        }
    }
    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            Debug.Log("Adding Life! Current Lives: " + currentLives);
            currentLives++;
        }
    }

    private void GameOver()
    {
        AudioManager.Instance.StopBackgroundMusic();
        AudioManager.Instance.PlayLoseMusic();
        gameOverPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endScoreText.text = "Final Score: " + score;
        Time.timeScale = 0f; // Pause the game
        Debug.Log("Game Over! Final Score: " + score);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        currentLives = maxLives;
        score = 0;
        livesText.text = currentLives.ToString();
        scoreText.text = "Score: " + score;
        gameOverPanel.SetActive(false);
        endScoreText.text = string.Empty;
        counterComboShow.gameObject.SetActive(false);
        comboCounter = 0;
    }

    public void BreakCombo()
    {
        comboCounter = 0;
        increaseLifeCounter = 0;
        if (counterComboShow != null)
        {
            counterComboShow.text = string.Empty; // Clear the text
            counterComboShow.gameObject.SetActive(false);
        }

        Debug.Log($"Combo broken! Counter reset. comboCounter={comboCounter}, increaseLifeCounter={increaseLifeCounter}");
    }
}