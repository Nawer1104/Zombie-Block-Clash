using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Enemy> enemies;

    public List<Stand> stands;

    public List<TargetSystem> towers;

    public bool CheckSetUpFinished()
    {
        foreach (Stand stand in stands)
        {
            if (!stand.GetStatus())
            {
                return false;
            }
        }
        return true;
    }

    public void Fight()
    {
        if (CheckSetUpFinished())
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.canMove = true;
            }

            foreach (TargetSystem tower in towers)
            {
                tower.canShoot = true;
            }
        }
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
