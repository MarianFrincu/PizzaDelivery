using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public float maxDamage = 100f; // Avariile maxime
    public float damageMultiplier = 10f; // Factorul de multiplicare
    private float currentDamage = 0f; // Avariile curente

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    [System.Obsolete]
    void OnCollisionEnter(Collision collision)
    {
        // Calculează avariile în funcție de viteza impactului
        float impactSpeed = rb.velocity.magnitude;
        float damage = impactSpeed * damageMultiplier;

        currentDamage += damage;
        currentDamage = Mathf.Clamp(currentDamage, 0, maxDamage);

        Debug.Log($"Current Damage: {currentDamage}");

        // Dacă avariile ating limita maximă, marchează comanda ca avariată complet
        if (currentDamage >= maxDamage)
        {
            Debug.Log("Vehiculul este complet avariat!");
        }
    }

    // Funcție care verifică dacă avariile au atins limita maximă
    public bool IsCompletelyDamaged()
    {
        return currentDamage >= maxDamage;
    }
}
