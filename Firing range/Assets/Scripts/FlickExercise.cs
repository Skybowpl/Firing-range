using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickExercise : MonoBehaviour
{
    [SerializeField] private GameObject hitTarget;
    [SerializeField] private float minSpred = -2;
    [SerializeField] private float maxSpred = 2 ;
    public void spawnTarget()
    {
        GameObject target = Instantiate(hitTarget, gameObject.transform.position + new Vector3(0, Random.Range(minSpred, maxSpred), Random.Range(minSpred, maxSpred)), Quaternion.identity);
        target.transform.parent = gameObject.transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        spawnTarget();
    }
}
