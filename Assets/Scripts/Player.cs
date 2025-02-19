using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float jumpForce = 20f;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groudCheckRadius = 0.2f;
    [SerializeField]
    private LayerMask whatIsGround;
    private Animator anim;
    [SerializeField]
    private BoxCollider2D normalCollider;
    [SerializeField]
    private CapsuleCollider2D duckCollider;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        normalCollider.enabled = true;
        duckCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfGrounded();
        HandleJump();
        HandleDuck();
        HandleSoundFx();
    }
    
    private bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groudCheckRadius, whatIsGround); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groudCheckRadius);
    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void HandleDuck()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            normalCollider.enabled = false;
            duckCollider.enabled = true;
            anim.SetBool("isDuck", true);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            normalCollider.enabled = true;
            duckCollider.enabled = false;
            anim.SetBool("isDuck", false);
        }
    }
    
    private void HandleSoundFx()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.PlayJumpClip();
        }
        if (isGrounded && !AudioManager.instance.HasPlayedFX())
        {
            AudioManager.instance.PlayTapClip();
            AudioManager.instance.SetPlayingFX(true);
        }
        else if (!isGrounded)
        {
            AudioManager.instance.SetPlayingFX(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            AudioManager.instance.PlayHurtClip();
            GameManager.instance.GameOver();
        }
    }
}
