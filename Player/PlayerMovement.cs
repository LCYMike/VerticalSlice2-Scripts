using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private SpriteRenderer sprite;

    private PlayerAnimations playerAnim;

    private float minSpeed = Player.minSpeed;
    private float maxSpeed = Player.maxSpeed;
    private float acceleration = Player.acceleration;
    private float speed;

    private float jumpForce = Player.jumpForce;
    private float jumpTime = Player.airTime;
    private float jumpCoolDown = Player.jumpCoolDown;

    private float dashCoolDown = Player.dashCoolDown;

    private bool isJumping;
    private bool isDashing;
    private bool isRunning;


    private Rigidbody2D rb;

    private void Start()
    {
        isJumping = false;
        playerAnim = GetComponent<PlayerAnimations>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (Player.health <= 0)
            return;

        if (dashCoolDown > 0)
        {
            dashCoolDown -= Time.deltaTime;
        }
        else if (isDashing)
        {
            isDashing = false;
        }

        if (jumpCoolDown > 0)
        {
            jumpCoolDown -= Time.deltaTime;
        }


        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void MoveLeft()
    {
        if (Player.health <= 0 || PlayerAttack.isAttacking)
            return;

        if (speed < maxSpeed)
        {
            speed += acceleration;
        }

        sprite.flipX = true;
        isRunning = true;

        rb.position -= new Vector2((speed * Time.deltaTime) / 100, 0f);
    }

    public void MoveRight()
    {
        if (Player.health <= 0 || PlayerAttack.isAttacking)
            return;

        if (speed < maxSpeed)
        {
            speed += acceleration;
        }

        sprite.flipX = false;
        isRunning = true;

        rb.position += new Vector2((speed * Time.deltaTime) / 100, 0f);
    }

    public void SlowDown()
    {
        if (Player.health <= 0)
            return;

        isRunning = false;

        if (speed > minSpeed && !isDashing && !isJumping)
        {
            speed -= acceleration * 20 * Time.deltaTime;
        }
    }

    public void Jump()
    {
        if (Player.health <= 0)
            return;

        if (!isJumping)
        {
            jumpTime = Player.airTime;
            isJumping = true;
        }

        jumpTime -= Time.deltaTime;

        if (jumpTime > 0)
        {
            rb.position += new Vector2(0f, jumpForce * Time.deltaTime);
        }
    }

    public void Dash()
    {
        if (Player.health <= 0)
            return;

        if (!isDashing && !isJumping && dashCoolDown <= 0)
        {
            isDashing = true;
            speed += 500;
            Invoke("Stop", 0.1f);
        }
    }

    private void Stop()
    {
        speed -= 500;
        dashCoolDown = 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDashing && collision.transform.tag == "Enemy")
        {
            CancelInvoke("Stop");
            Stop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (jumpCoolDown <= 0 && collision.transform.tag != "HitBox")
        {
            isJumping = false;
        }
    }

    private float GetHeight()
    {
        return transform.position.y;
    }

    public bool GetJump()
    {
        return isJumping;
    }

    public bool GetDash()
    {
        return isDashing;
    }

    public bool GetRunning()
    {
        return isRunning;
    }
}