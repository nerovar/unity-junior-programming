using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharp : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    
    private Rigidbody _rb;
    private Vector3 _startPos;

    public int DamageAmount => damage;

    private void Start()
    {
        _startPos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Bounds();
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
            Launch();
    }

    void Move()
    {
        if (_rb.velocity.y >= 0)
        {
            float movement = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.up * -movement * speed * Time.deltaTime);
        }

        if (transform.position.y <= -15f)
        {
            Reset();
        }
    }

    void Bounds()
    {
        Vector3 position = transform.position;
        if (position.x <= -GameManager.Instance.XBounds)
        {
            transform.position = new Vector3(-GameManager.Instance.XBounds, position.y, position.z);
        } else if (position.x >= GameManager.Instance.XBounds)
        {
            transform.position = new Vector3(GameManager.Instance.XBounds, position.y, position.z);
        }
    }
    
    void Launch()
    { 
        _rb.useGravity = true;
    }

    void Reset()
    {
        _rb.useGravity = false;
        transform.position = _startPos;
        _rb.velocity = Vector3.zero;
    }
}
