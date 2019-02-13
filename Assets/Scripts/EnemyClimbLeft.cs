using UnityEngine;
using System.Collections;

public class EnemyClimbLeft : MonoBehaviour
{
    //If any enemy has came to the ramp (stairs)
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            collisionInfo.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0) * 0.3f; //Add speed to x and y direction (from left to right and up)
        }
    }

    //If the enemy left from the ramp (strairs)
    void OnCollisionExit(Collision collisionInfo)
    {
        collisionInfo.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0) * 0.3f; //Add speed to only x direction (to right)
    }
}
