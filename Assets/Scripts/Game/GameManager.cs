
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Telas da partida")]
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    public bool GameEnded { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Time.timeScale = 1f;
    }

    void Start()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        if (defeatPanel != null)
            defeatPanel.SetActive(false);
    }

    public void WinGame()
    {
        if (GameEnded)
            return;

        GameEnded = true;
        Time.timeScale = 0f;

        if (victoryPanel != null)
            victoryPanel.SetActive(true);

        Debug.Log("VITÓRIA!");
    }

    public void LoseGame()
    {
        if (GameEnded)
            return;

        GameEnded = true;
        Time.timeScale = 0f;

        if (defeatPanel != null)
            defeatPanel.SetActive(true);

        Debug.Log("DERROTA!");
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        GameEnded = false;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
