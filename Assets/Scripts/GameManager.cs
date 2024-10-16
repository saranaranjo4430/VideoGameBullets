using UnityEngine;
using UnityEngine.SceneManagement;  // For restarting the scene
using UnityEngine.UI;               // For handling the UI components
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton instance

    public int score = 0;                // Player's score
    public GameObject pauseMenuUI;       // Reference to the pause menu UI
    public Button resumeButton;          // Reference to the resume button
    public Button restartButton;         // Reference to the restart button
    public Button quitButton;            // Reference to the quit button
    public TextMeshProUGUI scoreText;               // Reference to the Text component displaying the score

    private bool isPaused = false;       // Keeps track of whether the game is paused

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Don't destroy on loading new scenes
        }
        /*
        else
        {
            Destroy(gameObject);
        }
        */
    }

    void Start()
    {
        // Start with the pause menu hidden
        pauseMenuUI.SetActive(false);

        // Attach button listeners to their respective functions
        if (resumeButton != null) resumeButton.onClick.AddListener(ResumeGame);
        if (restartButton != null) restartButton.onClick.AddListener(RestartGame);
        if (quitButton != null) quitButton.onClick.AddListener(QuitGame);

        // Update the score display at the start
        UpdateScoreText();
    }

    void Update()
    {
        // Use Escape key to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Method to add points to the player's score
    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score);  // Log the updated score for testing
        UpdateScoreText();  // Update the score text on screen
    }

    // Method to update the score display
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Method to pause the game
    public void PauseGame()
    {
        if (!isPaused)
        {
            Debug.Log("Pausing the game");
            isPaused = true;
            Time.timeScale = 0f;  // Freeze the game
            pauseMenuUI.SetActive(true);  // Show the pause menu
            Cursor.lockState = CursorLockMode.None;  // Unlock the cursor to interact with the UI
            Cursor.visible = true;  // Show the cursor
        }
    }

    // Method to resume the game
    public void ResumeGame()
    {
        if (isPaused)
        {
            Debug.Log("Resuming the game");
            isPaused = false;
            Time.timeScale = 1f;  // Unfreeze the game
            pauseMenuUI.SetActive(false);  // Hide the pause menu
            Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor back for gameplay
            Cursor.visible = false;  // Hide the cursor
        }
    }

    // Method to restart the game (reload the current scene)
    public void RestartGame()
    {
        Debug.Log("Restarting the game");
        Time.timeScale = 1f;  // Ensure game is running at normal speed
        score = 0;  // Reset the player's score to 0
        UpdateScoreText();  // Reset the score text
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");  // Log message for testing in the Unity Editor

        // If running in the Unity editor, exit play mode (only for testing)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running a built version of the game, quit the application
        Application.Quit();
#endif
    }
}
