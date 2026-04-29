using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public float speed = 5.0f;
    public float jumpForce = 150;
    public bool isGrounded = true;

    private float moveValue;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if(moveValue > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if(moveValue < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        if (Keyboard.current != null) 
        {
            moveValue = (Keyboard.current.dKey.isPressed ? 1f : 0) - (Keyboard.current.aKey.isPressed ? 1f : 0);


        }

        if (moveValue != 0) 
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }


        _rb.linearVelocity = new Vector2(moveValue * speed, _rb.linearVelocity.y); 
        
        // Jump Logic
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded) 
        {
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, jumpForce)); 
            Debug.Log("Jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
