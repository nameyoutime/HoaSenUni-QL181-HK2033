using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBoss : MonoBehaviour
{
    [SerializeField]
    public float movespeed = 1f;
    public int direction = 0;
    // private Vector3 startPos, endPos;
    // private Vector3 nextPos;
    // [SerializeField]
    // private Transform PosB;


    private Animator anim;
    [SerializeField] private float TimeAttack = 0;
    private bool normalAttack = true;
    [SerializeField] private GameObject zoombie;
    void Awake()
    {

    }
    void Start()
    {
        anim = GetComponent<Animator>();
        direction = -1;
        // startPos = transform.localPosition;
        // endPos = PosB.localPosition;
        // nextPos = endPos;



        StartCoroutine(Spawner());
    }
    void Running()
    {
        anim.SetTrigger("Move");
        // transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, movespeed *
        // Time.deltaTime);
        Vector3 pos = this.transform.position;
        pos.x += direction * movespeed * Time.deltaTime;
        transform.position = pos;

        // if (Vector3.Distance(transform.localPosition, nextPos) <= 2)
        // {

        // }

    }
    void ChangeDirection()
    {
        direction = -direction;
    }
    void CheckAttack()
    {
        TimeAttack += Time.deltaTime;
        if (TimeAttack > 10f)
        {
            // Debug.Log("HVattack");
            anim.SetTrigger("HeavyAtt");
            TimeAttack = 0;
            normalAttack = true;
        }
        if (TimeAttack > 5f && normalAttack)
        {
            // Debug.Log("atk");
            anim.SetTrigger("NormalAtt");
            normalAttack = false;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Running();
        CheckAttack();
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(2f);
        Vector2 pos = transform.position;
        pos.x -= transform.localScale.x;
        Instantiate(zoombie, pos, transform.rotation);
        StartCoroutine(Spawner());
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (col.gameObject.tag == "bound")
        {
            ChangeDirection();
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            //If the GameObject has the same tag as specified, output this message in the console
            // Debug.Log("Do something else here");
        }
    }
}
