//using system.collections;
//using system.collections.generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5f;
    public float JumpForce = 5f;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position +=  movement * Time.deltaTime * MovementSpeed;
        Jump();

    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y)<0.001f){
            _rigidbody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }

    }
}
