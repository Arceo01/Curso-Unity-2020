using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private float speed = 10;
    // Start is called before the first frame update

     void FixedUpdate()
    {

        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            transform.Rotate(Vector3.left * vertical);
        }
        if (horizontal != 0)
        {
            transform.Rotate(Vector3.up * horizontal);
        }
    }
}
