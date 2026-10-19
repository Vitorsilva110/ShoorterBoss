
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;
    public Image[] lifeIcons;

    private int currentLives;

    public int CurrentLives => currentLives;

    void Start()
    {
        currentLives = maxLives;
        UpdateLifeUI();
    }

    public void TakeDamage()
    {
        if (currentLives <= 0)
            return;

        currentLives--;
        UpdateLifeUI();

        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            Debug.Log("DERROTA!");
        }
    }

    void UpdateLifeUI()
    {
        if (lifeIcons == null)
            return;

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (lifeIcons[i] != null)
            {
                lifeIcons[i].enabled = i < currentLives;
            }
        }
    }
}
