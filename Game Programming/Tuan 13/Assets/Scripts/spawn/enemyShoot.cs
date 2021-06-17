using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    Transform player;
    public int detectDistant = 3;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject go = GameObject.Find("Character/player");
        // Debug.Log(Vector3.Distance(transform.position, go.transform.position));

        // if (Vector3.Distance(transform.position, go.transform.position) < 3)
        // {
        //     new WaitForSeconds(6);

        //     StartCoroutine(Attack());
        // }

    }

    IEnumerator Attack()
    {
        GameObject go = GameObject.Find("Character/player");
        yield return new WaitForSeconds(Random.Range(1, 3));
        if (Vector3.Distance(transform.position, go.transform.position) < detectDistant)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

        StartCoroutine(Attack());

    }


}
