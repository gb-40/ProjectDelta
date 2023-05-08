using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed; 
    private Rigidbody2D rb;
    private Vector2 movement;
    // private Vector2 moveInput;
    public Camera cam;
    public Vector2 mousePos;
    public static Transform Instance;

    // Have to set rb in Start since it is private
    // Can be made public to do in unity
    // Then the Start() func can be removed
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT WITH MOUSE AIM
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
         
     

        // ================================================================== //
        // BELOW WORKS WITHOUT AIMING

        // moveInput.x = Input.GetAxisRaw("Horizontal");
        // moveInput.y = Input.GetAxisRaw("Vertical");

        // moveInput.Normalize();

        // rb.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;

        // ================================================================== //
        //BELOW IS UNKNOWN

        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");

        // Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // rb.velocity = movement.normalized * moveSpeed * Time.deltaTime * 200f; 
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }

    private void Awake()
    {
        Instance = transform;
    }
}
