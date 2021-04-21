using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Character2D character;
    public Animator animatior;
    private Rigidbody2D _rigidbody;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float direction;
    [SerializeField] private float m_JumpForce = 8f;
    [SerializeField]
    private GameObject bullet;

    Object bulletref;
    // Start is called before the first frame update
    void Start()
    {

        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animatior.SetFloat("Speed", Mathf.Abs(horizontalMove));
        Jump();
        Fire();

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0f, m_JumpForce), ForceMode2D.Impulse);
            animatior.SetBool("isJumping", true);
        }
        if (_rigidbody.velocity.y == 0)
        {
            animatior.SetBool("isJumping", false);
        }
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

        }
    }
    void FixedUpdate()
    {
        character.Move(horizontalMove * Time.fixedDeltaTime);
    }

    public void OnLanding()
    {
        animatior.SetBool("isJumping", false);
    }
}
