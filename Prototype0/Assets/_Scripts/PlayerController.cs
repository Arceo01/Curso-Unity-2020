using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10;
    private float horizontal;
    private float vertical;
    private float inbounds = 19;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Move();
        KeepInbounds();

    }
    private void Move()
    {
        if (horizontal != 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontal);
        }
        if (vertical != 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        }
    }
    void KeepInbounds()
    {
        if (transform.position.x < -inbounds)
        {
            transform.position = new Vector3(-inbounds, transform.position.y, transform.position.z);
        }
        if (transform.position.x > inbounds)
        {
            transform.position = new Vector3(inbounds, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -inbounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -inbounds);
        }
        if (transform.position.z > inbounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, inbounds);
        }
    }
}
