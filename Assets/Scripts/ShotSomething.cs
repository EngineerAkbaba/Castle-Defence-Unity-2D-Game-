using UnityEngine;
using System.Collections;

public class ShotSomething : MonoBehaviour
{
	public float lifeTime; //Life time of the enemy 
	public int scorePoint; //The point that player will win if it kill an enemy

    //Control that if the shot crash with the enemy
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy"))
        {
            ScoreText.score = ScoreText.score + scorePoint; //Increase the score
            other.gameObject.GetComponent<Animator>().SetBool("EnemyDie", true); ///Make "EnemyDie" animation active
			other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * 2; //Bounce the enemy
			other.gameObject.GetComponent<BoxCollider>().isTrigger = true; //Make trigger of Box Collider active

            //Destroy enemy
			Destroy(gameObject);
			Destroy(other.gameObject, lifeTime);
		}
	}
}
