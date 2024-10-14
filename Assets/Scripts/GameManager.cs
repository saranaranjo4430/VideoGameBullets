using UnityEngine;
using UnityEngine.SceneManagement;  // For restarting the scene
using UnityEngine.UI;               // For handling the UI components

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton instance

    public int score = 0;                // Player's score
    public GameObject pauseMenuUI;       // Reference to the pause menu UI
    public Button pauseButton;           // Reference to the pause button
    public Button resumeButton;          // Reference to the resume button
    public Button restartButton;         // Reference to the restart button

    private bool isPaused = false;       // Keeps track of whether the game is paused

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Don't destroy on loading new scenes
        }
        /*else
        {
            Destroy(gameObject);
        }*/
    }

    void Start()
    {
        // Start with the pause menu hidden
        pauseMenuUI.SetActive(false);

        // Attach button listeners to their respective functions
        if (pauseButton != null) pauseButton.onClick.AddListener(PauseGame);
        if (resumeButton != null) resumeButton.onClick.AddListener(ResumeGame);
        if (restartButton != null) restartButton.onClick.AddListener(RestartGame);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
    }
}
