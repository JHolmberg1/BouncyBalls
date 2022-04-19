using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public float turnSpeed = 4.0f;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3( 3.0f, 3.0f, 3.0f);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = (player.position + offset);
        transform.LookAt(player.position);
    }
}
