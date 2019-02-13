using UnityEngine;
using System.Collections;

public class EnemyClimbRight : MonoBehaviour
{
    //If any enemy has come to the ramp (stairs)
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            collisionInfo.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1, 4, 0) * 0.3f; //Add speed to x and y direction (from right to left and up)
        }
    }

    //If the enemy leave from the ramp (strairs)
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            collisionInfo.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0) * 0.3f; //Add speed to only x direction (to left)
        }
    }
}
