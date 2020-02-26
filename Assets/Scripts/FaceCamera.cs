using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.forward = transform.position - target.position;
        Debug.DrawRay(transform.position,transform.forward * 10, Color.red);
    }
}
