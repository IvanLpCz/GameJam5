using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolBullets : MonoBehaviour
{
    public Transform aimPos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject bullet = poolling.SharedInstance.GetPooledObject("bulletTest");

            if (bullet != null)
            {
                bullet.transform.position = aimPos.position;
                bullet.transform.rotation = aimPos.rotation;
                bullet.SetActive(true);
            }
        }
    }
}
