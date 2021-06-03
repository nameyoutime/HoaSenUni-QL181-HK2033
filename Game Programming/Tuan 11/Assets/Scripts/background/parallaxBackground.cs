using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour
{
    public GameObject bg;
    private Transform cameraTranform;
    private Vector3 lastCameraPos;
    // Start is called before the first frame update
    void Start()
    {
        //lấy camera.
        cameraTranform = Camera.main.transform;
        //đặt camera ngay tại thời điểm bây giờ. 
        lastCameraPos = cameraTranform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //camera đã duy chuyển bao nhiêu từ khi lastcamera
        Vector3 deltaMove = cameraTranform.position - lastCameraPos;
        //chỉnh lại background;
        transform.position += deltaMove;
        lastCameraPos = cameraTranform.position;
    }
}
