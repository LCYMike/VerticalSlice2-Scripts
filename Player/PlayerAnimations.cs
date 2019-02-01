using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    Animator animator;
    PlayerMovement playerMovement;

    private float state;

    private bool isAlive = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (isAlive)
        {
            SetState(CalcState());
            animator.SetFloat("State", GetState());
        }
    }

    PlayerAnimationStates CalcState()
    {
        //check if player is alive
        if(Player.health <= 0)
            return PlayerAnimationStates.die;

        //check if player is hit
        if (PlayerHit.isHit)
            return PlayerAnimationStates.hit;

        //check if player is attacking
        if (PlayerAttack.isAttacking == true && PlayerAttack.combo < 1)
            return PlayerAnimationStates.attack1;
        if (PlayerAttack.isAttacking == true && PlayerAttack.combo == 1)
            return PlayerAnimationStates.attack2;
        if (PlayerAttack.isAttacking == true && PlayerAttack.combo == 2)
            return PlayerAnimationStates.attack3;

        //check is player is jumping
        if (playerMovement.GetJump())
            return PlayerAnimationStates.jump;

        //check if player is dashing
        if (playerMovement.GetDash())
            return PlayerAnimationStates.dash;

        //check if player is running
        if (playerMovement.GetRunning())
            return PlayerAnimationStates.run;

        return PlayerAnimationStates.idle;
    }


    float GetState()
    {
        return state;
    }

    void SetState(PlayerAnimationStates State)
    {
        switch (State)
        {
            case PlayerAnimationStates.idle:
                state = 0;
                break;
            case PlayerAnimationStates.run:
                state = 1;
                break;
            case PlayerAnimationStates.dash:
                state = 2;
                break;
            case PlayerAnimationStates.jump:
                state = 3;
                break;
            case PlayerAnimationStates.attack1:
                state = 4;
                break;
            case PlayerAnimationStates.attack2:
                state = 5;
                break;
            case PlayerAnimationStates.attack3:
                state = 6;
                break;
            case PlayerAnimationStates.hit:
                state = 8;
                break;
            case PlayerAnimationStates.die:
                state = 9;
                break;
            default:
                state = 0;
                break;
        }
    }

}
