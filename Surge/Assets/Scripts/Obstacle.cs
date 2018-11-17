using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int rotationSpeed;

    private void Update()
    {
    }

    private void Rotate()
    {
        if (rotationSpeed!=0)
            transform.Rotate(Vector3.forward*Time.deltaTime*rotationSpeed);
    }
}