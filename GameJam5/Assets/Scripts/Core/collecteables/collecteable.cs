using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collecteable : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sound;
    private int totalOfCollecteables;
    private collecteableOnUI collUI;

    private void Start()
    {
        collUI = GameObject.Find("collecteableManager").GetComponent<collecteableOnUI>();
        totalOfCollecteables = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collUI.pickedCollecteables = collUI.pickedCollecteables + 1;
            source.PlayOneShot(sound, 0.7f);
            StartCoroutine(setFalse());
        }
    }
    IEnumerator setFalse()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
