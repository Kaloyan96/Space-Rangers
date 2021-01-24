using UnityEngine;

/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : ScriptableObject {

	// Health
	public float maxHealth = 100;
	public float currentHealth { get; private set; }
	public float team;
	public Stat damage;
	public Stat armor;
	public float damageDummy = 60f;

	// Set current health to max health
	// when starting the game.
	void Awake ()
	{
		currentHealth = maxHealth;
	}

	public float calculateDamage(){
		return damageDummy;
	}

	// Damage the character
	public void TakeDamage (float damage)
	{
		// Subtract the armor value
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, float.MaxValue);

		// Damage the character
		currentHealth -= damage;
	}
}
