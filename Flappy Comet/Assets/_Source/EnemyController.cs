using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float moveRange = 2f;
    private Vector3 startPosition;
    private float moveDirection = 1f;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = Mathf.PingPong(Time.time * speed, moveRange) - (moveRange / 2);
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, startPosition.y + newY, transform.position.z);
    }
}
