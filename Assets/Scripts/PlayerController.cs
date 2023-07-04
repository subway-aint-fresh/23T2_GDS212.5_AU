using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float boundarySize;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");
        playerDirection = new Vector2(directionX, directionY).normalized;
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rb.position + playerDirection * playerSpeed * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -boundarySize, boundarySize);
        newPosition.y = Mathf.Clamp(newPosition.y, -boundarySize, boundarySize);
        rb.MovePosition(newPosition);
    }
}