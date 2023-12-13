using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool canMove = false;

    public float speed;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (canMove)
        {
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Barrier"))
        {
            transform.position = startPos;
        }
    }
}
