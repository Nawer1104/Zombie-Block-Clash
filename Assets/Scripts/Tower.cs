using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject vfxAttach;

    private DragAndDrop dragAndDrop;

    private Enemy target;

    public Projectile projectilePrefab;

    public Transform shootPoint;
    private void Awake()
    {
        dragAndDrop = GetComponent<DragAndDrop>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Stand"))
        {
            Success();
            transform.position = collision.transform.localPosition;
            collision.gameObject.GetComponent<Stand>().SetUp();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].towers.Add(GetComponent<TargetSystem>());
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].Fight();
        }
    }

    public void Success()
    {
        dragAndDrop._dragging = false;
        GameObject vfx = Instantiate(vfxAttach, transform.position, Quaternion.identity);
        Destroy(vfx, 1f);
    }

    public void SetTarget(Enemy enemy)
    {
        if (enemy == null) return;

        target = enemy;
        Projectile projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity) as Projectile;
        projectile.Setup(target.transform.position);

    }
}
