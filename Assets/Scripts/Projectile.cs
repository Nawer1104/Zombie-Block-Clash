using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 targetPosition;

    public GameObject vfxExposion;

    public float moveSpeed;

    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Projectile"))
        {
            return;
        }
        else
        {
            GameObject vfx = Instantiate(vfxExposion, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            if (collision != null && collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].enemies.Remove(collision.gameObject.GetComponent<Enemy>());
                GameManager.Instance.CheckLevelUp();
            }
        }
    }
}
