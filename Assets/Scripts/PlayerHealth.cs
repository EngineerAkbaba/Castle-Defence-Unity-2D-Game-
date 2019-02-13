using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth = 100;
	public Slider healthSlider; //Slider can be moved between minimum and maximum health

	Run run; //Object of the "Run" class

	//Initialize the health
	void Awake ()
    {
		currentHealth = startingHealth;
		run = GetComponent<Run>(); //Get the components and features of "Run" class
	}

    //Update the health
	public void TakeDamage (int amount)
	{
        currentHealth = currentHealth - amount; //Increase the health
		healthSlider.value = currentHealth; //Update health
		
		if(currentHealth <= 0) //If no healt remains
		{
			Death (); //Call death function
		}
	}

    //Deactive the player
	void Death ()
	{
		run.enabled = false; //Make "run" animation deactive
		GetComponent<Animator>().SetTrigger("playerDie"); //Make "playerDie" animation active
	}
}
