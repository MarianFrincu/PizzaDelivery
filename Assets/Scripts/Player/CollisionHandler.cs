using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public float maxHealth = 100f; // Sănătatea maximă
    public float damageMultiplier = 10f; // Factorul de multiplicare pentru avarii
    public float currentHealth; // Sănătatea curentă

    private void Start()
    {
        currentHealth = maxHealth; // Inițializează sănătatea la valoarea maximă
    }

    // Funcție pentru a aplica daune pe baza vitezei impactului
    public void ApplyDamage(Rigidbody rb)
    {
        float impactSpeed = rb.linearVelocity.magnitude; // Calculăm viteza impactului
        float damage = impactSpeed * damageMultiplier;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asigurăm limitele sănătății

        Debug.Log($"Health after collision: {currentHealth}");

        // Verificăm dacă vehiculul este complet avariat
        if (IsCompletelyDamaged())
        {
            Debug.Log("Vehiculul este complet avariat!");
        }
    }

    // Funcție care verifică dacă sănătatea a ajuns la 0
    public bool IsCompletelyDamaged()
    {
        return currentHealth <= 0;
    }
}
