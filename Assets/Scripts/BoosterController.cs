using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour
{

    public Rigidbody rb;
    public int boostSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("boosted");
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * boostSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
