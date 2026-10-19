
using System.Collections;
using UnityEngine;

public class BossPhaseTransition : MonoBehaviour
{
    public BossHealth bossHealth;
    public Animator bossAnimator;
    public SpriteRenderer bossSprite;
    public float transitionDuration = 2f;

    private BossHealth.LifeState lastLifeState;
    private Coroutine transitionCoroutine;

    void Start()
    {
        if (bossHealth == null)
            bossHealth = GetComponent<BossHealth>();

        if (bossAnimator == null)
            bossAnimator = GetComponent<Animator>();

        if (bossSprite == null)
            bossSprite = GetComponent<SpriteRenderer>();

        if (bossHealth != null)
            lastLifeState = bossHealth.CurrentLifeState;
    }

    void Update()
    {
        if (bossHealth == null || bossAnimator == null)
            return;

        if (bossHealth.CurrentLifeState != lastLifeState)
        {
            lastLifeState = bossHealth.CurrentLifeState;

            if (transitionCoroutine != null)
                StopCoroutine(transitionCoroutine);

            transitionCoroutine = StartCoroutine(PhaseTransitionRoutine());
        }
    }

    IEnumerator PhaseTransitionRoutine()
    {
        bossHealth.SetInvulnerable(true);
        bossAnimator.speed = 0f;

        float elapsed = 0f;
        bool visible = true;

        while (elapsed < transitionDuration)
        {
            visible = !visible;

            if (bossSprite != null)
                bossSprite.enabled = visible;

            yield return new WaitForSeconds(0.15f);
            elapsed += 0.15f;
        }

        if (bossSprite != null)
            bossSprite.enabled = true;

        bossAnimator.speed = 1f;
        bossHealth.SetInvulnerable(false);
        transitionCoroutine = null;
    }
}
