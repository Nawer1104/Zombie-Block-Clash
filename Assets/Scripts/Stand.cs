using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    private bool isSetup;

    private void Awake()
    {
        isSetup = false;
    }

    public void SetUp()
    {
        isSetup = true;
    }

    public bool GetStatus()
    {
        return isSetup;
    }
}
