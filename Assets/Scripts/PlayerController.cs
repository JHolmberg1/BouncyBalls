using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool speedUp = false;
    public ParticleSystem cubeParticle;
    public GameObject cubeForm;
    public bool victory = false;
    public GameObject canvas;

    private GameObject focalPoint;

    float TimeDelay_Seconds = 3.0f;
    float Timer;

    void Start()
    {
        Time.timeScale = 1;
        focalPoint = GameObject.Find("Focal Point");
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        distToGround = playerCollider.bounds.extents.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        if (isGrounded)
        {
            rb.AddForce(focalPoint.transform.forward * moveVertical * speed * Time.deltaTime);
        }
        else
        {
            rb.AddForce(focalPoint.transform.forward * (moveVertical /5) * speed * Time.deltaTime);
        }
    }
    void Update()
    {
        Jumping();
        Abilitys();
        Endgame();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HradBrake"))
        {
            hardBrake = true;
        }
        if (collision.gameObject.CompareTag("SpeedUp"))
        {
            speedUp = true;
        }
        if (collision.gameObject.CompareTag("victory"))
        {
            victory = true;
        }
        
    }

    void Abilitys()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && hardBrake && !cubed)
        {
            rb.velocity = Vector3.down;
            cubeParticle.Play();
            cubeForm.SetActive(true);
            cubed = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && cubed)
        {
            cubed = false;
            cubeParticle.Play();
            cubeForm.SetActive(false);
        }

        if (Timer < Time.realtimeSinceStartup && Input.GetKeyDown(KeyCode.Mouse1) && speedUp)
        {
            Timer = Time.realtimeSinceStartup + TimeDelay_Seconds;
            rb.AddForce(focalPoint.transform.forward * speed * 4);
        }
    }

    void Endgame()
    {
        if (victory == true)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }

        if (victory && Input.GetKeyDown(KeyCode.Escape) || rb.position.y < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Jumping()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        if (cubed == false)
        {

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(0, jump, 0, ForceMode.Impulse);
            }
        }
    }
}

