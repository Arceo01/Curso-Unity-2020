using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal!=0)
        {
            Move();
        }
    }

    void Move()
    {
       transform.Translate(Vector3.right * Time.deltaTime * speed * horizontal);
    }
}
