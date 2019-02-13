using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour
{
	public float speed; //Speed of the player
	private float prevSpeed; //The speed before any speed
	
	public Transform shotPosition; //Position of shoting
	public GameObject shot; //Weapon object
	public float shotSpeed; //The speed of weapon
	
	public float fireRate; //The rate of shoting
    private float nextFire; //The shout coming after a shout according to fireRate
	
	private int rightArrowCounter; //Right shoting counter
    private int leftArrowCounter; //Left shoting counter

	private bool enemyInRange; //Controls that if any enemy is on the stairs

	private float timer; //Main time of the game
	public float timeBetweenAttacks = 0.5f; //The time between two shoting
	public int attackDamage = 10; //The efect to the health bar when an enemy crash to the player

    PlayerHealth playerHealth; //Object of "PlayerHealth" class

    //Initialize some variables of enemy
	void Start ()
    {
		enemyInRange = false; //When the game starts, no enemy is on the stairs
		rightArrowCounter = 1; //Enemy starts coming to right direction (from left)
		leftArrowCounter = 0;
        playerHealth = GetComponent<PlayerHealth>(); //Get components of "PlayerHealth" class
	}
	
	//Update runs per frame
	void Update ()
    {
        //If the user STARTS pressing RightArrow
		if (Input.GetKeyDown (KeyCode.RightArrow))
        {
			leftArrowCounter = 0;

			if(rightArrowCounter == 0) //If the player is not shoting to right direction 
            {
                shotSpeed = shotSpeed * -1; //Add speed for shoting
            }

            GetComponent<Animator>().SetBool("run", true); //Make "run" animation active
			GetComponent<Transform>().rotation = Quaternion.Euler(0f, 0f, 0f); //Rotate the player to right direction
			GetComponent<Rigidbody> ().velocity = new Vector3 (1, 0, 0) * speed; //Add speed to player to run

			rightArrowCounter++;
		}

        //If the user STOPS pressing RightArrow (release the key)
		if (Input.GetKeyUp (KeyCode.RightArrow))
        {
            GetComponent<Animator>().SetBool("run", false); //Make "run" animation deactive
			GetComponent<Rigidbody> ().velocity = Vector3.zero; //Stop player
		}

        //If the user STARTS pressing LeftArrow
		if (Input.GetKeyDown (KeyCode.LeftArrow))
        {
			rightArrowCounter = 0;

            if (leftArrowCounter == 0) //If the player is not shoting to left direction 
            {
                shotSpeed = shotSpeed * -1; //Add speed for shoting
            }

            GetComponent<Animator>().SetBool("run", true); //Make "run" animation active
            GetComponent<Transform>().rotation = Quaternion.Euler(0f, 180f, 0f); //Rotate the player to left direction
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0) * speed; //Add speed to player to run

			leftArrowCounter++;
		}

        //If the user STOPS pressing LeftArrow (release the key)
		if (Input.GetKeyUp (KeyCode.LeftArrow))
        {
            GetComponent<Animator>().SetBool("run", false); //Make "run" animation deactive
            GetComponent<Rigidbody>().velocity = Vector3.zero; //Stop player
		}

        //If the user STARTS pressing LeftShift
		if (Input.GetKeyDown (KeyCode.LeftShift))
        {
			prevSpeed = speed; //Assign previus speed
            speed = speed * 2; //Accelerate the speed
		}

        //If the user STOPS pressing LeftShift (release the key)
		if (Input.GetKeyUp (KeyCode.LeftShift))
        {
			speed = prevSpeed; //Reassign the speed to previus speed
		}

        //If the user STARTS pressing LeftControl and no time to shot next weapon
		if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time > nextFire)
        {
            GetComponent<Animator>().SetBool("fireWaiting", true); //Make "fireWaiting" animation active
			nextFire = Time.time + fireRate;

			GameObject go = Instantiate(shot, shotPosition.position, shotPosition.rotation) as GameObject; //Initialize weapon 
			go.GetComponent<Rigidbody>().velocity=Vector3.right * shotSpeed; //Add speed to weapon
			Destroy(go, 4f); //Destroy the weapon
		}

        //If the user STOPS pressing LeftControl (release the key)
		if (Input.GetKeyUp (KeyCode.LeftControl))
        {
            GetComponent<Animator>().SetBool("fireWaiting", false); ////Make "fireWaiting" animation deactive
		}

        timer = timer + Time.deltaTime;

        //If it is time to shot and ant enemy is on the stairs
		if (timer >= timeBetweenAttacks && enemyInRange)
        {
			Attack(); //Call attack function
		}
	}

	void OnTriggerEnter(Collider other) //Controls that if any enemy comes on the stairs
	{
		if (other.gameObject.CompareTag ("Enemy"))
        {
            enemyInRange = true;
        }
	}

    void OnTriggerExit(Collider other) //Controls that if any enemy exits from the stairs
	{
		if (other.gameObject.CompareTag ("Enemy"))
        {
            enemyInRange = false;
        }
	}

    //Enemy attack to player
	void Attack()
	{
		timer = 0f;

		if(playerHealth.currentHealth > 0) //If there is player health remains
		{
			playerHealth.TakeDamage (attackDamage); //Efect the health of the player
		}
	}
}
