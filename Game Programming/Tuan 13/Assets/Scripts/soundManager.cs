using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static soundManager Instance;
    public static AudioClip Jump, Coin, Course_clear;
    static AudioSource sound;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        Jump = Resources.Load<AudioClip>("jump");
        Coin = Resources.Load<AudioClip>("coin");
        Course_clear = Resources.Load<AudioClip>("course_clear");

        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "jump":
                sound.PlayOneShot(Jump,0.5f);
                break;
            case "coin":
                sound.PlayOneShot(Coin,0.5f);
                break;
            case "course_clear":
                sound.PlayOneShot(Course_clear,1f);
                break;
            default:
                break;
        }
    }
}
