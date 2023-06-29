using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlickExercise : MonoBehaviour
{
    [SerializeField] private GameObject hitTarget;
    [SerializeField] private float minSpred = -2;
    [SerializeField] private float maxSpred = 2;
    [SerializeField] private float exerciseTime = 5;
    private float timerEnd;
    public void spawnTarget()
    {
        if (Time.time < timerEnd)
        {
            GameObject target = Instantiate(hitTarget, gameObject.transform.position + new Vector3(0, Random.Range(minSpred, maxSpred), Random.Range(minSpred, maxSpred)), Quaternion.identity);
            target.transform.parent = gameObject.transform;
        }
        else
        {
            StartChange(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        timerEnd = Time.time + exerciseTime;
        StartChange(false);
        StartCoroutine(StopExercise(exerciseTime));
        spawnTarget();
    }

    private void StartChange(bool exerciseState)
    {
        gameObject.GetComponent<Collider>().enabled = exerciseState;
        gameObject.GetComponent<MeshRenderer>().enabled = exerciseState;
    }

    private IEnumerator StopExercise(float time)
    {
        yield return new WaitForSeconds(time);
        StartChange(true);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
