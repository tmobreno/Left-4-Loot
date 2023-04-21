using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // movement
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public bool isRight = true;

    // health
    public int playerHealth = 100;

    // scrap and level
    public int playerLevel = 1;
    public int playerScrap = 0;
    public float upgradeDamage = 0f;

    // timer
    float timer = 0f;

    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {

        // movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


    }

    void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * moveSpeed);

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (movement.x < 0 && isRight == true)
        {
            Flip();
            isRight = false;
        }else if (movement.x > 0 && isRight == false)
        {
            Flip();
            isRight = true;
        }

        // slide
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= timer)
            {
                rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * moveSpeed * 10);
                timer = Time.time + 0.5f;
            }
        }
    }

    // damage
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Zombie"))
        {
            StartCoroutine(Knockback(1f, 50f, col.transform));
            playerHealth = playerHealth - 10;
            Debug.Log(playerHealth);
        }
    }

    // knockback

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float knockTimer = 0f;

        while (knockbackDuration > knockTimer)
        {
            knockTimer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
