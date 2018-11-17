using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float hue;

    // Use this for initialization
    private void Start()
    {
        hue=Random.Range(0f, 10f)/10f;

        SetBackgroundColor();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetBackgroundColor()
    {
        Camera.main.backgroundColor=Color.HSVToRGB(hue, 0.6f, 0.8f);

        hue+=0.1f;
        if (hue>=1f)
            hue=0f;
    }
}