using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour
{
    public int direction = 1;
    private bool shooted = false;
    void Update()
    {
        if (shooted)
            Attack();
    }
    public void Shoot(int dir)
    {
        direction = dir;
        shooted = true;
    }
    void Attack()
    {
        Vector2 temp = transform.position;
        temp.x += direction * 5 * Time.deltaTime;
        transform.position = temp;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jumper")
        {
            collision.gameObject.SendMessageUpwards("Damage", 1f);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Border") // dung duong bien
        {
            Destroy(gameObject);
        }
    }
}
