using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGizmos : MonoBehaviour {
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Boss.followRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Boss.attackRange);
    }
}
