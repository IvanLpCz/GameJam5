using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullSword : MonoBehaviour
{
    public GameObject swordCollider;
    public float attackTime = 0.3f;
    public Animator playerAnimator;
    public ParticleSystem swordParticle;
    public AudioSource audioS;
    public AudioClip swordSound;
    public void start()
    {
        swordParticle.Stop();
    }
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
        swordParticle.Play();
        audioS.PlayOneShot(swordSound, 0.7f);
        playerAnimator.SetTrigger("firstAttack");
        yield return new WaitForSeconds(attackTime);
        swordCollider.SetActive(false);
        swordParticle.Stop();
        playerAnimator.ResetTrigger("firstAttack");
    }
}
