using UnityEngine;

public class BossHit : MonoBehaviour
{

    public BossAI bossAi;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attacking")
        {
            //bossAi.Hit(player.damage);
        }
    }
}
