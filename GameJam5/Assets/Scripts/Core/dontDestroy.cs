using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    private static bool objectExisit;
    private bool realObject;

    private void Awake()
    {
        if (!objectExisit)
        {
            objectExisit = true;
            realObject = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (objectExisit && !realObject)
        {
            Destroy(this);
        }
    }

}
