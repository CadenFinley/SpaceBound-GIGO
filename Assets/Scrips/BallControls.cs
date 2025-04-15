using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallControls : MonoBehaviour
{
    public float power = 10f;
    private Rigidbody2D rb;
    public Vector2 minPower;
    public Vector2 maxPower;
    private Camera cam;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;
    public bool isGrounded = false;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Transform teleTest;
    public bool testActive = false;
    public Transform ms;
    public AudioSource thunk;
    private int check;
    private void Start()
    {
        if (testActive)
        {
            transform.position = teleTest.transform.position;
        }
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Vector2 ballPos = transform.position;
        if(Input.GetMouseButtonDown(0) && isGrounded)
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            changeGrav(0.35f);
            if(transform.position.y <= 260)
            {
                rb.angularVelocity = 0f;
            }
        }
        if (Input.GetMouseButtonUp(0) && isGrounded)
        {
            check = 0;
            if (transform.position.y <= 260)
            {
                changeGrav(1f);
            }
            else
            {
                power = 2.25f;
            }
            isGrounded = false;
            animator.SetBool("jumpAvail", false);
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force*power, ForceMode2D.Impulse);
        }
        check++;
        if (transform.position.y <= 260)
        {
            changeGrav(1f);
        }
        if(check> 10000)
        {
            isGrounded=true;
            animator.SetBool("jumpAvail", true);
        }
    }

    public void StopMovement()
    {
        rb.angularVelocity = 0f;
        rb.velocity = Vector3.zero;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        thunk.Play();
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("jumpAvail", true);      
        }
    }
    public void changeGrav(float f)
    {
        rb.gravityScale = f;
    }

}
