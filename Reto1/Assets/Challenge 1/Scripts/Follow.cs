using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject following;
    private Vector3 offset = new Vector3(30, 0, 0);

    void Update()
    {
        transform.position = following.transform.position + offset;
    }

}
