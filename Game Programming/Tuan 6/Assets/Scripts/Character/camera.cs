using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // public Transform target;
    // public Vector3 offset;
    Transform CamTransform;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        CamTransform = Camera.main.transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // this.transform.position.x = player.transform.position.x + offsetX
        // transform.position = target.position + offset;
        CamTransform.position = new Vector3(Player.position.x, CamTransform.position.y, CamTransform.position.z);
    }
}
