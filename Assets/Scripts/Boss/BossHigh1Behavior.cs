
using UnityEngine;

public class BossHigh1Behavior : BossBehaviorBase
{
    public float moveSpeed = 1f;
    public float verticalLimit = 3f;

    private int direction = 1;

    public override void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        direction = 1;
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
    }
}
