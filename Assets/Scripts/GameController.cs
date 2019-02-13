using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject enemy; //The game object that references to enemy
	public float startWait; //Wait of an enemy after another enemy come
	public float spawnWait; //Rate of enemy creation
	public int hazardCount; //Number of enemies

    //Initialize the enemy direction and coroutine
	void Start ()
    {
		EnemyController.enemyDirectionLeft = true; //Let enemies comes from left initially
		StartCoroutine (SpawnWaves()); //Call SpawnWaves function by routine
	}

    //Create enemies
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait); //Wait befor creating enemy

		for (int i = 0; i < hazardCount; i++) //Create enemy acording to number of enemies
        {
            EnemyController.enemyDirectionLeft = true; //Make left direction active
			Vector3 spawnPosition = new Vector3 (2.85f, -0.05f, 2.09f); //Assing enemy position
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0); //Assign direction of enemy
			Instantiate (enemy, spawnPosition, spawnRotation); //Initialize enemy
			yield return new WaitForSeconds (spawnWait); //Wait as much as enemy rate
			EnemyController.enemyDirectionLeft = false; //Make left direction deactive

            EnemyController.enemyDirectionRight = true; //Make right direction active
            Vector3 spawnPosition2 = new Vector3(-2.65f, -0.05f, 2.09f); //Assing enemy position
            Quaternion spawnRotation2 = Quaternion.Euler(0, 0, 0); //Assign direction of enemy
            Instantiate(enemy, spawnPosition2, spawnRotation2); //Initialize enemy
            yield return new WaitForSeconds(spawnWait); //Wait as much as enemy rate
            EnemyController.enemyDirectionRight = false; //Make right direction deactive

		}
	}
}
