using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(direction * speed);
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
