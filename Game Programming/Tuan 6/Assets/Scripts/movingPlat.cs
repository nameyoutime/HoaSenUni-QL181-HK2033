using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{
    public int direction;
    public float speed;
    void Start()
    {
        direction = 1;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bound")
        {
            Debug.Log("hit");
            direction = -direction;
        }
    }

}
