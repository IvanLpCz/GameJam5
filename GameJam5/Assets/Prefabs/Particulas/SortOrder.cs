using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortOrder : MonoBehaviour
{
    public int sortingOrder = 570;
    public Renderer vfxRenderer;
    void OnValidate()
    {
        vfxRenderer = GetComponent<Renderer>();
        if (vfxRenderer)
            vfxRenderer.sortingOrder = sortingOrder;
    }
}
