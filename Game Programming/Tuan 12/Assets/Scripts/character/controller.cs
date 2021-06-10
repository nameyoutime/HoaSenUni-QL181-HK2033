using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public movingBackground movingBackground;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = true;
    public Animator animatior;
    private Rigidbody2D _rigidbody;
    private AudioSource footstep;
    public float runSpeed = 40f;
    private float horizontalMove, horizontalInput, direction;
    [SerializeField] private float m_JumpForce = 8f;
    [SerializeField] private GameObject bullet;
    private bool jumped, isFalling;

    Object bulletref;

    public bool spotted = false;
    public Transform startSight, endSight;
    private int numberBullet = 10;
    private float timeDelay = 0;

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
    private void FixedUpdate()
    {
        line();
    }


    void line()
    {
        Debug.DrawLine(startSight.position, endSight.position, Color.red);
        spotted = Physics2D.Linecast(startSight.position, endSight.position, 1 <<
        LayerMask.NameToLayer("Jumper"));
        timeDelay += Time.deltaTime;
        if (timeDelay > 0.5f && spotted && numberBullet > 0)
        {
            Attack();
            timeDelay = 0;
        }

    }
    void Attack()
    {
        numberBullet--;
        if (m_FacingRight)
        {
            GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            body.GetComponent<bulletPlayer>().Shoot(1);
        }
        else if (!m_FacingRight)
        {
            GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            body.GetComponent<bulletPlayer>().Shoot(-1);
        }
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
        Move(horizontalMove * Time.fixedDeltaTime, horizontalInput);
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
            soundManager.playSound("jump");
        }
        if (_rigidbody.velocity.y == 0)
        {
            jumped = false;
            isFalling = false;
            animatior.SetBool("isFalling", false);
        }

    }

    public void Move(float move, float input)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);
        // And then smoothing it out and applying it to the character
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        if (input > 0)
        {
            movingBackground.left = true;
            movingBackground.right = false;
        }
        else if (input < 0)
        {
            movingBackground.right = true;
            movingBackground.left = false;
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
