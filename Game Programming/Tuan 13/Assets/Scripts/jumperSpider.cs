using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class jumperSpider : MonoBehaviour
{
    public int health = 10;
    [SerializeField]
    private GameObject effect;
    public GameObject text;
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
        GameObject os = Instantiate(text,transform.position,Quaternion.identity);
        os.transform.GetComponent<TextMeshPro>().text = "+1";
        DoorScript.Instance.PlusScore();
        Timer.time += 5;
        Destroy(os,0.5f);
        
    }
}
