using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Freecam : MonoBehaviour
{
    [SerializeField] Camera freecam;

    [SerializeField] float speed = 0.1f;


    void Start()
    {
        
    }

    void Update()
    {
        freecam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
        
    }
}
