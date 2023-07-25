using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float rotationSpeed = 5f;
    private float currentRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation = rotationSpeed * Time.deltaTime;
            transform.Rotate(0f,currentRotation , 0f);

    }
}
