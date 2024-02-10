using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    public float currentHealth;

    public bool hasTakenDamage { get; set; }

    private CinemachineImpulseSource cinImpluseSource;


    public void Start()
    {
        currentHealth = maxHealth;

        cinImpluseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        Die();
    }


    void Damage(float damageAmount)
    {
        // Enables screen shake if enemy is damaged
        CameraShakeManager.instance.CameraShake(cinImpluseSource);

        hasTakenDamage = true;

        currentHealth -= damageAmount;

        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
