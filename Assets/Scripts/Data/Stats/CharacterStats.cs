using UnityEngine;

/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : ScriptableObject {

	// Health
	public int maxHealth = 100;
	public int currentHealth { get; private set; }
	public int team;
	public Stat damage;
	public Stat armor;

	// Set current health to max health
	// when starting the game.
	void Start ()
	{
		currentHealth = maxHealth;
	}

	// Damage the character
	public void TakeDamage (int damage)
	{
		// Subtract the armor value
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		// Damage the character
		currentHealth -= damage;
	}
}
