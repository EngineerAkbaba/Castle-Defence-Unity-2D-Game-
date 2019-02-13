using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public float speed; //Speed of enemies
	public static bool enemyDirectionLeft; //The enemies coming from rigth (to left)
    public static bool enemyDirectionRight; //The enemies coming from left (to right)

	//Initialize the speed of the enemies according their direction
	void Start ()
    {
        if (enemyDirectionLeft) //If the enemy comes from rigth (to left)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0) * speed; //Add speed vector to left direction (add only x direction)
        }

        if (enemyDirectionRight) //If the enemy comes from left (to right)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0) * speed; //Add speed vector to right direction (add only x direction)
        }
	}

	/*public void EnemyDirectionToRight()
	{
		GetComponent<Rigidbody> ().velocity = new Vector3 (1, 0, 0)*speed;
	}

	public void EnemyDirectionToLeft()
	{
		GetComponent<Rigidbody> ().velocity = new Vector3 (-1, 0, 0)*speed;
	}*/

}
