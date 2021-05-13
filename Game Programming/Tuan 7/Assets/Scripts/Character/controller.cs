using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public movingBackground movingBackground;
    public soundManager sound;

    public Character2D character;
    public Animator animatior;
    private Rigidbody2D _rigidbody;
    private AudioSource footstep;
    public float runSpeed = 40f;
    private float horizontalMove, horizontalInput, direction;
    [SerializeField] private float m_JumpForce = 8f;
    [SerializeField] private GameObject bullet;
    private bool jumped, isFalling;

    Object bulletref;
    // Start is called before the first frame update
    void Start()
    {
        // jumped = false;isFalling = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        footstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animatior.SetFloat("Speed", Mathf.Abs(horizontalMove));
        horizontalInput = Input.GetAxisRaw("Horizontal");

        move();
        // Fire();

    }
    void checkStopMoving()
    {
        if (_rigidbody.velocity.x == 0 || horizontalInput == 0)
        {
            movingBackground.left = false;
            movingBackground.right = false;
            // footstep.Stop();
            // do idle animations
        }
    }

    void footstepSound()
    {
        footstep.Play();
    }
    void move()
    {
        character.Move(horizontalMove * Time.fixedDeltaTime, horizontalInput);
        falling();
        jump();
        checkStopMoving();
    }
    void falling()
    {
        if (_rigidbody.velocity.y < -0.1)
        {
            isFalling = true;
            animatior.SetBool("isFalling", true);
            animatior.SetBool("isJumping", false);

        }
    }
    void jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0f, m_JumpForce), ForceMode2D.Impulse);
            animatior.SetBool("isJumping", true);
            animatior.SetBool("isFalling", false);
            jumped = true;
            sound.playSound("jump"); 
        }
        if (_rigidbody.velocity.y == 0)
        {
            jumped = false;
            isFalling = false;
            animatior.SetBool("isFalling", false);
        }

    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
