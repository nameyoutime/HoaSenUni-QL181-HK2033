using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    void Start()
    {
        if (DoorScript.Instance != null)
            DoorScript.Instance.CollectablesCount++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            soundManager.playSound("coin");
            Timer.time += 20;
            if (DoorScript.Instance != null)
                DoorScript.Instance.DecrementCollectables();

        }
    }

}
