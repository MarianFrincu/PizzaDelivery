using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objective"))
        {
            ObjectiveRelocator relocator = other.transform.parent.GetComponent<ObjectiveRelocator>();

            PlayerStats stats = GetComponent<PlayerStats>();

            int addedScore = Mathf.RoundToInt(100 * ((Mathf.Exp(2 * stats.GetCurrentHealth() / PlayerStats._maxHealth) - 1) / (Mathf.Exp(2) - 1)));

            stats.UpdateScore(addedScore);
            stats.AddOneDeliveredPizza();

            relocator.NextDelivery();
        }
    }
}
