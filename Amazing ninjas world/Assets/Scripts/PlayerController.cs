using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public float groundDistanceThreshold = 0.55f;

    public LayerMask WhatIsGround;

    private bool _isGround;
    private bool _enabled;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enabled = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!_enabled) return;
        float movement = moveSpeed * Input.GetAxisRaw("Horizontal");
        _rigidbody.position += movement * Time.deltaTime * Vector2.right;
    }

    void Update()
    {
        if (!_enabled) return;
        _isGround = Physics2D.Raycast(transform.position,Vector2.down,
        groundDistanceThreshold,WhatIsGround);
        
        if(_isGround && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = Vector2.up * jumpForce;
        }
    }

    public void Enable()
    {
        _enabled = true;
    }
    public void Disable()
    {
        _enabled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hello");
        if (other.gameObject.CompareTag("Hazard"))
        {
            gameManager.KillPlayer();
        }
    }
}
