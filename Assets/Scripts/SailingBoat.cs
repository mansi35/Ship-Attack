using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailingBoat : MonoBehaviour
{
    public float speed = 40f;
    public float speedrate = 40f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddTorque(0f, 10000 * moveHorizontal * speed * Time.deltaTime, 0f);
        rb.AddForce(movement * speed * speedrate * Time.deltaTime);
    }
}
