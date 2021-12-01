using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public GameObject wayPoint;

    private float refresTime = 0.5f;

    void Update()
    {
        if (refresTime > 0)
        {
            refresTime -= Time.deltaTime;
        }
        if (refresTime <= 0)
        {
            UpdatePosition();
            refresTime = 0.5f;
        }
    }

    void UpdatePosition()
    {
        wayPoint.transform.position = transform.position;
    }
}
