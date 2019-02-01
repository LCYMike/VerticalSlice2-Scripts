using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

    public static bool isHit = false;

    public void PlayerHitAnim(){


        PlayerAttack.isAttacking = false;
        isHit = true;

        Invoke("Stop", 0.1f);
    }

    void Stop()
    {
        isHit = false;
    }
}
