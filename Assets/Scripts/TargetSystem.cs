using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    [SerializeField] private float range;

    private Tower tower;

    public float shootTimerMax;

    float shootTimer;

    public bool canShoot = false;

    private void Awake()
    {
        tower = GetComponent<Tower>();
    }

    private void Update()
    {
        if (!canShoot) return;

        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            shootTimer = shootTimerMax;

            Enemy closest = null;

            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, range);
            foreach (Collider2D collider2D in colliderArray)
            {
                if (collider2D.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) <= range)
                    {
                        if (closest == null)
                        {
                            closest = enemy;
                        }
                        else
                        {
                            if (Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, closest.transform.position))
                            {
                                closest = enemy;
                            }
                        }
                    }
                }
            }
            tower.SetTarget(closest);
        }
    }
}
