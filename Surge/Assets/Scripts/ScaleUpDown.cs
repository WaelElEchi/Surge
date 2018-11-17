using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpDown : MonoBehaviour
{
    private Vector3 originalScale;
    public Vector3 targetScale;

    public float scaleSpeed = 3f;

    [SerializeField] private bool scaleDown;

    // Use this for initialization
    private void Start()
    {
        originalScale=transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        if (originalScale.x-0.2f<transform.localScale.x)
        {
            scaleDown=true;
        }
        else if (transform.localScale.x<targetScale.x+0.2f)
        {
            scaleDown=false;
        }

        if (scaleDown)
            ScaleDown();
        else
            ScaleUp();
    }

    private void ScaleDown()
    {
        Vector3 scale = transform.localScale;
        scale.x=Mathf.Lerp(scale.x, targetScale.x, scaleSpeed*Time.deltaTime);
        scale.y=Mathf.Lerp(scale.y, targetScale.y, scaleSpeed*Time.deltaTime);
        transform.localScale=scale;
    }

    private void ScaleUp()
    {
        Vector3 scale = transform.localScale;
        scale.x=Mathf.Lerp(scale.x, originalScale.x, scaleSpeed*Time.deltaTime);
        scale.y=Mathf.Lerp(scale.y, originalScale.y, scaleSpeed*Time.deltaTime);
        transform.localScale=scale;
    }
}