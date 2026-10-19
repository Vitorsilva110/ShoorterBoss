
using UnityEngine;

public class BossHigh2Behavior : BossBehaviorBase
{
    public float shootInterval = 1f;

    private float shootTimer;
    private BossShooter shooter;

    public override void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        shootTimer = 0f;
        shooter = animator.GetComponent<BossShooter>();
    }

    public override void OnStateUpdate(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        if (shooter == null)
            return;

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            shooter.Shoot();
            shootTimer = 0f;
        }
    }
}
