using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jump = 20f;
    private Rigidbody rb;
    public bool isGrounded;
    private SphereCollider playerCollider;
    float distToGround;
    public bool hardBrake = false;
    private bool cubed = false;
    public ParticleSystem cubeParticle;
    public GameObject cubeForm;
    private Vector3 movement;

    private GameObject focalPoint;

    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        distToGround = playerCollider.bounds.extents.y;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * moveVertical * speed * Time.deltaTime);
    }
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        if (Input.GetKeyDown(KeyCode.Mouse0) && hardBrake && !cubed)
        {
            rb.velocity = Vector3.down;
            cubeParticle.Play();
            cubeForm.SetActive(true);
            Cooldown(2);
            cubed = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && cubed)
        {
            cubed = false;
            cubeParticle.Play();
            cubeForm.SetActive(false);
        }

        if (cubed == false)
        {

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(0, jump, 0, ForceMode.Impulse);
            }
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HradBrake"))
            {
            hardBrake = true;
            }
        
        
    }

    IEnumerator Cooldown(int cooldown)
    {
        yield return new WaitForSeconds(cooldown);
    }


}

