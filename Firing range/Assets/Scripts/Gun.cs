using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float noTargetHitPoint = 1000;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 targetPoint;
            if(Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(noTargetHitPoint);
            }
            Vector3 direction = targetPoint - shootPoint.position;
            GameObject shootedBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            shootedBullet.GetComponent<Bullet>().SetDirection(direction.normalized);
        }
    }
}
