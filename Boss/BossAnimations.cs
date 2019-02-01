using UnityEngine;

public class BossAnimations : MonoBehaviour
{
    private BossAI bossAi;
    public Animator animator;

    private float state;

    private void Start()
    {
        bossAi = FindObjectOfType<BossAI>();
    }

    void Update()
    {
        SetState(CalcState());
        animator.SetFloat("Action", GetState());
    }

    float GetState()
    {
        return state;
    }

    BossAnimationStates CalcState()
    {


        //check if boss is dead
        if(Boss.health <= 0)
        {
            return BossAnimationStates.die;
        }

        //check if boss is attacking
        if(BossAttack.isAttacking)
        {
            return BossAnimationStates.attack;
        }

        return BossAnimationStates.walk;
    }

    private void SetState(BossAnimationStates State)
    {
        switch (State)
        {
            case BossAnimationStates.walk:
                state = 0;
                break;
            case BossAnimationStates.attack:
                state = 1;
                break;
            case BossAnimationStates.die:
                state = 2;
                break;
            default:
                state = 0;
                break;
        }
    }

}
