using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float timer = 2f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; if (timer <= 0)
            Destroy(gameObject);

            
        Vector3 pos = transform.position; 
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0); 
        pos += transform.rotation * velocity; 
        transform.position = pos;

    }
}
