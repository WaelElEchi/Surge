using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerT;
    private float smoothness = 0.3f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float yOffset;

    private void Start()
    {
    }

    private void Update()
    {
        SmoothFollow();
    }

    private void SmoothFollow()
    {
        Vector3 pos = playerT.TransformPoint(new Vector3(0, yOffset, -10f));
        pos=new Vector3(0, pos.y, -10f);

        transform.position=Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness);
    }
}