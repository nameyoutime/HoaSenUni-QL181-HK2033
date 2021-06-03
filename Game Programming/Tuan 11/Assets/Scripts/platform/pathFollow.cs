using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFollow : MonoBehaviour
{
    public pathDef path;
    public float MoveSpeed = 1f;
    private Transform _TargetPoint;
    private float x;
    void Start()
    {
        if (path == null)
            return;
        _TargetPoint = path.getPointAt(0);
        x = transform.position.x;
    }
    void Update()
    {
        if (path == null)
            return;
        transform.position = Vector2.MoveTowards(transform.position, _TargetPoint.position,
        MoveSpeed * Time.deltaTime);
        float Distance = Vector2.Distance(transform.position, _TargetPoint.position);

        // Debug.Log(transform.position.x-x);
        // if(transform.position.x-x == 0){
        //     Debug.Log("0");
        // }
        if (Distance <= 0.1f)
            _TargetPoint = path.getNextPoint();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;


        }

    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
