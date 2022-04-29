using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Transform focalPoint;
    public Transform Maincamera;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        focalPoint.position = player.position;
    }

    
}
