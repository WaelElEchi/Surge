using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float duration = 0.2f;
    private float magnitude = 0.5f;

    public IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed<duration)
        {
            float x = Random.Range(-1f, 1f)*magnitude;
            float y = Random.Range(-1f, 1f)*magnitude;

            transform.localPosition=new Vector3(originalPos.x+x, originalPos.y+y, originalPos.z);
            elapsed+=Time.deltaTime;

            yield return null;
        }

        transform.localPosition=originalPos;
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}