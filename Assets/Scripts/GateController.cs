using UnityEngine;
using System.Collections;

public class GateController : MonoBehaviour
{
    //Control that if any enemy crash the gate
	void OnTriggerEnter(Collider other)
	{
        //If the enemy arrive to the gate, then destroy it (enemy enters )
		if (other.gameObject.CompareTag("Enemy"))
        {
			Destroy(other.gameObject);
		}
	}
}
