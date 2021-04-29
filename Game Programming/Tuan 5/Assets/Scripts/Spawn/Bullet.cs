using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // phai su dung trigger cho bullet, nếu không sẽ đẩy bullet bật ngươc
    [SerializeField]
    private GameObject effect;
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        Vector2 temp = transform.position;
        temp.y += 20 * Time.deltaTime;
        transform.position = temp;

        if (temp.y > 6) Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }

    }

}