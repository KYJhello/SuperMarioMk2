using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private float moveSpeed;
    private void Awake()
    {
        moveSpeed = Random.Range(1f,3f) * Time.deltaTime;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

}
