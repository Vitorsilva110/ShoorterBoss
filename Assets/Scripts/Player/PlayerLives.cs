
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;
    public Image[] lifeIcons;

    private int currentLives;

    public int CurrentLives => currentLives;

    void Start()
    {
        currentLives = maxLives;
        StarUILife();
    }

    public async Awaitable TakeDamage()
    {
        using var ct = new CancellationTokenSource();
        if (currentLives <= 0)
            return;

        currentLives--;
        DecreaseUILife();

        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            if (GameManager.Instance != null)
            {
                await Awaitable.WaitForSecondsAsync(.2f);
                GameManager.Instance.LoseGame();
            }
            else
            {
                Debug.LogError("GameManager não encontrado!");
            }
        }
    }

    void DecreaseUILife()
    {
        if (lifeIcons == null)
            return;

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (lifeIcons[i] != null)
            {
                lifeIcons[i].gameObject.SetActive(i < currentLives);
            }
        }
    }

    private void StarUILife()
    {
        if (lifeIcons == null)
            return;

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (lifeIcons[i] != null)
            {
                lifeIcons[i].gameObject.SetActive(true);
            }
        }
    }
}
