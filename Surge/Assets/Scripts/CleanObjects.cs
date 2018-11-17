using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanObjects : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        collision.gameObject.transform.parent.gameObject.SetActive(false);
    }
}