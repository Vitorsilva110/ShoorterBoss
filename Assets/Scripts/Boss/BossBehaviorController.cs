
using UnityEngine;

public class BossBehaviorController : MonoBehaviour
{
    public BossHealth bossHealth;
    public Animator bossAnimator;

    public float behaviorChangeInterval = 5f;

    private BossHealth.LifeState lastLifeState;
    private float behaviorTimer;
    private int currentBehavior;

    void Start()
    {
        if (bossHealth == null)
            bossHealth = GetComponent<BossHealth>();

        if (bossAnimator == null)
            bossAnimator = GetComponent<Animator>();

        if (bossHealth == null || bossAnimator == null)
        {
            Debug.LogError(
                "BossBehaviorController: configure BossHealth e Animator."
            );
            enabled = false;
            return;
        }

        lastLifeState = bossHealth.CurrentLifeState;
        currentBehavior = 0;
        behaviorTimer = 0f;

        bossAnimator.SetInteger("LifeState", (int)lastLifeState);
        bossAnimator.SetInteger("Behavior", currentBehavior);
    }

    void Update()
    {
        if (bossHealth == null || bossAnimator == null)
            return;

        BossHealth.LifeState currentLifeState =
            bossHealth.CurrentLifeState;

        if (currentLifeState != lastLifeState)
        {
            lastLifeState = currentLifeState;
            currentBehavior = 0;
            behaviorTimer = 0f;

            bossAnimator.SetInteger(
                "LifeState",
                (int)currentLifeState
            );

            bossAnimator.SetInteger("Behavior", currentBehavior);

            Debug.Log("Fase do chefe: " + currentLifeState);
            return;
        }

        behaviorTimer += Time.deltaTime;

        if (behaviorTimer >= behaviorChangeInterval)
        {
            currentBehavior = (currentBehavior + 1) % 3;
            behaviorTimer = 0f;

            bossAnimator.SetInteger("Behavior", currentBehavior);

            Debug.Log("Comportamento do chefe: " + currentBehavior);
        }
    }
}
