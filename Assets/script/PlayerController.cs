using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isAttacking;
    private bool facingRight = true;

    private PlayerShooting playerShooting;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerShooting = GetComponent<PlayerShooting>();
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    void HandleMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetBool("IsMoving", movement.sqrMagnitude > 0.01f);

        // Flip the player sprite based on movement direction
        if (movement.x < 0 && facingRight)
        {
            Flip(false);
        }
        else if (movement.x > 0 && !facingRight)
        {
            Flip(true);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            isAttacking = true;
            animator.SetBool("IsAttacking", isAttacking);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
            animator.SetBool("IsAttacking", isAttacking);
        }
    }

    void Flip(bool isFacingRight)
    {
        facingRight = isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x = isFacingRight ? Mathf.Abs(scaler.x) : -Mathf.Abs(scaler.x);
        transform.localScale = scaler;

        if (playerShooting != null)
        {
            playerShooting.Flip(isFacingRight);
        }
    }
}


