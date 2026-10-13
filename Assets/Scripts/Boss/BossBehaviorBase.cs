
using UnityEngine;

public class BossBehaviorBase : StateMachineBehaviour
{
    protected BossHealth bossHealth;

    public override void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        bossHealth = animator.GetComponent<BossHealth>();

        if (bossHealth == null)
        {
            Debug.LogError("BossBehaviorBase: BossHealth não foi encontrado no objeto do Animator.");
        }
    }
}
