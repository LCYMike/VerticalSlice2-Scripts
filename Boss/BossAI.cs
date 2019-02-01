using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float yPos;

    private float chaseAmp = 1.5f;

    public static float setIgnore = 2f;
    public static float ignoreTime = 0f;

    private bool isAtMax = false;

    private float distanceToTarget;
    private GameObject player;
    private GameObject target;

    private BossAI bossAi;
    private BossRend bossRend;
    private BossAnimations anim;


    private void Start()
    {
        anim = GetComponent<BossAnimations>();
        transform.position = new Vector2(minX, yPos);
        bossAi = GetComponent<BossAI>();
        bossRend = FindObjectOfType<BossRend>();
        transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
    }

    void FixedUpdate()
    {

        if (Boss.health <= 0)
        {
            bossAi.enabled = false;
        }

        if (BossAttack.isAttacking)
        {
            return;
        }

        if (ignoreTime > 0)
            ignoreTime -= Time.deltaTime;

        //Find the player
        if (ignoreTime <= 0 && Player.health > 0)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Attacking");
            }
        }
        else
        {
            player = null;
        }

        //Calculate distance
        if (player != null)
            distanceToTarget = GetRange();

        //check if the player is within follow range
        if (player != null && distanceToTarget <= Boss.followRange)
        {
            target = player;
        }
        else
        {
            target = null;
        }

        //check if a target is found
        if (target)
        {
            if (distanceToTarget > Boss.attackRange)
            {
                //follow target
                if (target.transform.position.x < transform.position.x)
                {
                    isAtMax = true;
                    bossRend.setFlipX(false);
                    transform.position = new Vector2(transform.position.x - (Boss.moveSpeed * chaseAmp * Time.deltaTime), transform.position.y);
                }
                else
                {
                    isAtMax = false;
                    bossRend.setFlipX(true);
                    transform.position = new Vector2(transform.position.x + (Boss.moveSpeed * chaseAmp * Time.deltaTime), transform.position.y);
                }
                return;
            }
            else
            {
                return;
            }
        }

        //set bool and flip image 
        if (transform.position.x > maxX)
        {
            isAtMax = true;
        }
        else if (transform.position.x < minX)
        {
            isAtMax = false;
        }

        //move boss
        if (isAtMax)
        {
            transform.position = new Vector2(transform.position.x - (Boss.moveSpeed * Time.deltaTime), transform.position.y);
            bossRend.setFlipX(false);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + (Boss.moveSpeed * Time.deltaTime), transform.position.y);
            bossRend.setFlipX(true);
        }

    }

    public void SetIgnoreTime()
    {
        ignoreTime = setIgnore;
    }

    public float GetRange()
    {
        if (player)
        {
            return Vector2.Distance(transform.position, player.transform.position);
        }
        return Mathf.Infinity;
    }

}