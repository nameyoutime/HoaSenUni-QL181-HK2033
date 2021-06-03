using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameController : MonoBehaviour
{

    public GameObject panel;
    public void playerDie()
    {
        panel.SetActive(true);

    }
    public void restartGame()
    {
        panel.SetActive(false);

        SceneManager.LoadScene("2DCharater");
        // Application.LoadLevel(2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            Destroy(collision.gameObject);
            playerDie();

            // Destroy(Instantiate(exit, collision.transform.position, Quaternion.identity), 1f);
        }
    }
}
