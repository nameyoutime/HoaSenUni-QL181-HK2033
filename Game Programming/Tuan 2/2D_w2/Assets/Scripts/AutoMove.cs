using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float MovementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        autoMove();
    }
    void autoMove()
    {
        Vector3 temp = transform.position;
        temp.x -= MovementSpeed * Time.deltaTime;
        if (temp.x < -2)
        {
            temp.x = -2;
            MovementSpeed = -MovementSpeed;
        }
        if (temp.x > 2)
        {
            temp.x = 2;
            MovementSpeed = -MovementSpeed;
        }
        transform.position = temp;
    }
}
