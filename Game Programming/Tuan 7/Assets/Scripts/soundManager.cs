using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip Jump;
    static AudioSource audio;
    void Start()
    {
        Jump = Resources.Load<AudioClip>("jump");

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(string clip){
        switch (clip)
        {
            case "jump":
            audio.PlayOneShot(Jump);
            break;
            default:
            break;
        }
    }
}
