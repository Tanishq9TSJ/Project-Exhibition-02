using UnityEngine;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;
    public float currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float amount)
    {
        // Decrease the current health by the amount of damage taken
        currentHealth -= amount;

        // If the health has reached zero, call the Die function
      /*  if (currentHealth <= 0)
        {
            Die();
        }*/
    }

   /* void Die()
    {
        // Call the Die function on the parent object
        SendMessageUpwards("Die", SendMessageOptions.DontRequireReceiver);
    }*/
}
