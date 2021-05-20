using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    [SerializeField]
    private GameObject plane;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CreatePlane());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreatePlane()
    {
        yield return new WaitForSeconds(2);

        Vector2 temp = transform.position;
        temp.y += Random.Range(-2, 2);

        Instantiate(plane, temp, this.transform.rotation);

        StartCoroutine(CreatePlane());

    }

    void Destroy(){

    }
}