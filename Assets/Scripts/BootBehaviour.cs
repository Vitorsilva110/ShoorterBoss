using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class BootBehaviour : MonoBehaviour
{
    [SerializeField] private float m_Delay = .4f;
    
    private async Awaitable Start()
    {
        using var ct = new CancellationTokenSource();
        await Awaitable.WaitForSecondsAsync(m_Delay, ct.Token);
        SceneManager.LoadScene("Game");
    }
}
