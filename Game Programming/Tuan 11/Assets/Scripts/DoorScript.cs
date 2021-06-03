using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    
    public static DoorScript Instance;
    public GameObject exit;
    private Animator anim;
    private BoxCollider2D box;
    private int Score = 0;
    public Text txtScore;

    [HideInInspector]
    public int CollectablesCount;
    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    IEnumerator DoorOpen()
    {
        box.isTrigger = true;
        anim.Play("Door_open");
        yield return new WaitForSeconds(0.1f);


    }

    public void DecrementCollectables()
    {
        CollectablesCount--;
        Score++;
        txtScore.text = "Score: " + Score;
        if (CollectablesCount == 0 || Score == 10)
        {
            StartCoroutine(DoorOpen());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Debug.Log("hit");
            mainCamera.volume = 0;
            Destroy(collision.gameObject);
            soundManager.playSound("course_clear");
            
            
            // Destroy(Instantiate(exit, collision.transform.position, Quaternion.identity), 1f);
        }
    }

}
