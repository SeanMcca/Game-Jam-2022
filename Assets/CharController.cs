using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour

{

    [SerializeField] public float MovementSpeed = 1;
    [SerializeField] public float JumpForce = 1;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;

    [Range(.7f, 1f)] [SerializeField] public float aircontrol_perctange = .7f;


    private bool isJumping;


    private bool facingRight = true;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        if (movement > 0.1f || movement < -0.1f)
        {
            if (isGrounded() && _rb.velocity.y < 0.1f)
            {
                _rb.velocity = new Vector2(movement * MovementSpeed, _rb.velocity.y);
            }
            else
            {
                Debug.Log("InJumpMove");
            
                    _rb.velocity = new Vector2(movement * MovementSpeed * aircontrol_perctange, _rb.velocity.y);

            }   

        }
        if (Input.GetButtonDown("Jump")&&isGrounded())
        {
            Debug.Log("InJump");
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
        }

    }
    private bool isGrounded()
    {
       
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
    }

    private void FixedUpdate()
    {
        var inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }    
    }

    private void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
} 
