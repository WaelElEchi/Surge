using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float angle = 0;
    [SerializeField] private float sideSpeed = 5f;
    [SerializeField] private float upSpeed = 20f;

    private float xBorder;
    private Rigidbody2D rb;

    public GameObject deathEffect;
    public GameObject pickUpEffect;

    private bool isDead = false;

    public CameraShake cam;

    private void Awake()
    {
    }

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        xBorder=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x-1f;
        cam=Camera.main.GetComponent<CameraShake>();
    }

    private void Update()
    {
        if (isDead) return;

        MoveBall();

        GetInput();
    }

    private void MoveBall()
    {
        Vector2 pos = transform.position;
        pos.x=Mathf.Cos(angle)*xBorder;

        transform.position=pos;
        angle+=Time.deltaTime*sideSpeed;
    }

    private void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(new Vector2(0, upSpeed));
        }
        else
        {
            if (rb.velocity.y>0)

                rb.AddForce(new Vector2(0, -upSpeed/2f));
            else
                rb.velocity=new Vector2(rb.velocity.x, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            Dead();
        }
        else if (collision.CompareTag("Collectable"))
        {
            OnPickUp(collision.transform);
        }
    }

    private void Dead()
    {
        if (cam!=null)
            StartCoroutine(cam.Shake());
        isDead=true;
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 0.5f);
        StopBall();
        GameManager.instance.Lost();
    }

    private void StopBall()
    {
        rb.velocity=new Vector2(0, 0);
        rb.isKinematic=true;
    }

    private void OnPickUp(Transform t)
    {
        GameManager.instance.AddScore();

        Destroy(Instantiate(pickUpEffect, t.position, Quaternion.identity), 0.25f);
        //Destroy(t.gameObject);
        t.gameObject.SetActive(false);
    }
}