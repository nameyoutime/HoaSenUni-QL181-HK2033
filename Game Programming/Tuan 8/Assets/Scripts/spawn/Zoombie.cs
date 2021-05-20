using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoombie : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 5f;
    private float direction;
    private GameObject boss;
    void Awake()
    {
        boss =  GameObject.Find("boss/boss");
        direction = -boss.transform.localScale.x;
        Vector2 scale = transform.localScale;
        scale.x = direction;
        transform.localScale = scale;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x += direction * speed * Time.deltaTime;
        transform.position = pos;
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "bound")
        {
            Destroy(gameObject);
        }
    }
}
