using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicktarget : MonoBehaviour
{
    protected void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject.Find("Points").GetComponent<PointsManager>().AddPoint();
            gameObject.transform.parent.GetComponent<FlickExercise>().spawnTarget();
            Destroy(gameObject);
        }
    }
}
