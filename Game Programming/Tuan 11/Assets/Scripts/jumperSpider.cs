using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumperSpider : MonoBehaviour
{
    public int health = 10;
    [SerializeField]
    private GameObject effect;
    void Update()
    {
        // Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation), 1);
        }

    }
    public void Damage(int dm)
    {
        health -= dm;
    }
}
