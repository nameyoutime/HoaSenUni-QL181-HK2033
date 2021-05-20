using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    public static float time = 100f;
    public float timeBurn = 1f;

    // Use this for initialization
    void Start()
    {

    }
    private void Awake()
    {
        player = GameObject.Find("player");
        slider = GameObject.Find("Time slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = time;
        slider.value = time;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(time);
        if (!player)
            return;

        if (time > 0)
        {
            time -= timeBurn * Time.deltaTime;
            slider.value = time;
        }
        else
        {
            slider.value = 0f;
            Destroy(player);
            // GameObject.Find("Gameplay Controller").GetComponent<Gameplaycontroller>().PlayerDie();
        }
    }
}
