using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objective"))
        {
            ObjectiveRelocator relocator = other.transform.parent.GetComponent<ObjectiveRelocator>();

            PlayerStats stats = GetComponent<PlayerStats>();

            float addedScore = Mathf.Clamp(relocator.GetRemainingTime() * 1.5f + stats.GetCurrentHealth() * 3f, 0, 50);

            stats.UpdateScore(addedScore);
            stats.AddOneDeliveredPizza();

            relocator.NextDelivery();
        }
    }
}
