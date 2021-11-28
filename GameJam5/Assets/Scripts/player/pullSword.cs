using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullSword : MonoBehaviour
{
    public GameObject swordCollider;
    public float attackTime = 0.3f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(pullTheSword());
        }
    }

    IEnumerator pullTheSword()
    {
        swordCollider.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        swordCollider.SetActive(false);
    }
}
