using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideways : MonoBehaviour
{
    [SerializeField] private float boundx = 2.5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float maxAngle = 7.5f;
    [SerializeField] private float rotationSpeed = 3f;

    private bool left;

    // Use this for initialization
    private void Start()
    {
        boundx=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x-1f;

        int rn = Random.Range(0, 1);
        if (rn==0)
            left=true;
        else
            left=false;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveBackAndFourth();
        Rotate();
    }

    private void MoveBackAndFourth()
    {
        if (transform.position.x>=boundx)
        {
            left=true;
        }
        else if (transform.position.x<=-boundx)
        {
            left=false;
        }

        if (left)
        {
            transform.Translate(Vector2.left*moveSpeed*Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right*moveSpeed*Time.deltaTime);
        }
    }

    private void Rotate()
    {
        transform.rotation=Quaternion.Euler(0f, 0f, maxAngle*Mathf.Sin(Time.time*rotationSpeed));
    }
}