using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceToPlayer : MonoBehaviour
{
    public float rollspeed = 180f;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Character/player");
            if (go != null)
                player = go.transform;
        }

        if (player == null)
            return;

        Vector2 Direction = player.position - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rollspeed * Time.deltaTime);

    }
}
