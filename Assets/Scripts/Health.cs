using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] float health = 100f;

    [Header("Death VFX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfVFX = 1f;

    public void DealDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX() {
        if (!deathVFX) return;
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, durationOfVFX);
    }
}