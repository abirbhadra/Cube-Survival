using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed = 4f;
    [SerializeField] private float jump = 10f;
    private Rigidbody2D _rigidbody;
    [SerializeField] private bool isGrounded = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool killable = true;
    public UIScript scriptUI;

    public bool Killable { get => killable; set => killable = value; }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetButtonDown("Jump")? 1f : 0f;
        MoveCharacter(horizontal, vertical);
        
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0 && isGrounded)
        {
            isGrounded = false;
            Jump();
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // Check if the collision is with an object tagged as "Jump"
        if (collision.gameObject.CompareTag("jump"))
        {
            // Change the sprite renderer color to black on collision enter
            spriteRenderer.color = Color.black;
            Killable = false;
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("You Win");
            scriptUI.EnableWinUI();
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Jump"
        if (collision.gameObject.CompareTag("jump"))
        {
            // Change the sprite renderer color to white on collision exit
            spriteRenderer.color = Color.white;
            Killable = true;
        }
    }

    private void Jump()
    {
        // Apply vertical force to jump.
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jump);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemyvision"))
        { 
            if(Killable == true)
            {
                Debug.Log("player death");
                scriptUI.EnableGameOverUI();
            }
            else if (Killable == false)
            {
                Debug.Log("Player alive");
                scriptUI.DisableGameOverUI();
            }
        }
        
    }
    

    
}
