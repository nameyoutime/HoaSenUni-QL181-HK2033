using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemy;
    public GameObject bullet;
    public float speed = 4f;
    [SerializeField]
    private GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        enemy.velocity = new Vector2(-10f, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
        Destroy(Instantiate(effect, transform.position, this.transform.rotation), 1);



    }
}
