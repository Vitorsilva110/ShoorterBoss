
using UnityEngine;

public class BossMedium2Behavior : BossBehaviorBase
{
    public float moveSpeed = 2f;
    public float verticalLimit = 3f;
    public float shootInterval = 0.8f;

    private int direction = 1;
    private float shootTimer;
    private BossShooter shooter;

    public override void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        direction = 1;
        shootTimer = 0f;
        shooter = animator.GetComponent<BossShooter>();
    }

    public override void OnStateUpdate(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        Vector3 position = animator.transform.position;
        position.y += direction * moveSpeed * Time.deltaTime;

        if (position.y >= verticalLimit)
        {
            position.y = verticalLimit;
            direction = -1;
        }
        else if (position.y <= -verticalLimit)
        {
            position.y = -verticalLimit;
            direction = 1;
        }

        animator.transform.position = position;

        if (shooter != null)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootInterval)
            {
                shooter.ShootDouble();
                shootTimer = 0f;
            }
        }
    }
}
