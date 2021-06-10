using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    // public Transform target;
    // public Vector3 offset;
    // public static mainCamera Instance;
    Transform CamTransform;
    AudioSource m_MyAudioSource;
    public static float volume;
    public Transform Player;
    // Start is called before the first frame update
    private void Awake()
    {
        volume = 0.003f;
    }
    void Start()
    {

        CamTransform = Camera.main.transform;
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.Play();
    }
    private void Update() {
        m_MyAudioSource.volume = volume;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!Player)
            return;
        
        // this.transform.position.x = player.transform.position.x + offsetX
        // transform.position = target.position + offset;
        CamTransform.position = new Vector3(Player.position.x, CamTransform.position.y, CamTransform.position.z);
    }
}
