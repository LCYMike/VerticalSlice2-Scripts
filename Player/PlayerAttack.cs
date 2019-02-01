using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static bool isAttacking = false;
    private bool isComboing = false;

    private AudioSystem audioSystem;

    public static float combo = 0;

    private float range;

    private GameObject enemy;

    private Rigidbody2D rb;

    private void Start()
    {
        audioSystem = GameObject.FindWithTag("AudioSystem").GetComponent<AudioSystem>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (enemy = GameObject.FindGameObjectWithTag("Enemy"))
        {
            range = Vector2.Distance(transform.position, enemy.transform.position);
        }

        if (isAttacking)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        } else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        enemy = null;
    }

    public void AddCombo()
    {
        if (isAttacking && !isComboing && combo < 3)
        {
            isComboing = true;
            CancelStop();
        }
        if (!isAttacking)
        {
            isAttacking = true;
        }

    }

    public void Attack()
    {
        isAttacking = true;

        if (range < Boss.followRange - 1f)
        {
            Boss.health -= Player.damage;
            audioSystem.PlayerAttackSlash((int)combo); // value is 0,1,2
            combo++;
            
            isComboing = false;
        }
        Invoke("Stop", 0.4f);
    }

    void CancelStop()
    {
        CancelInvoke("Stop");
    }

    void Stop()
    {
        isAttacking = false;
        combo = 0;
    }

}