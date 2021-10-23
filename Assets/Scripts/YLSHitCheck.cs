using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLSHitCheck : MonoBehaviour
{
    public GameObject hit;
    public Simulate simulate;
    public AudioClip hitSound;
    public void OnCollisionEnter(Collision collision)
    {
        simulate.simulateBool = false;
        if(collision.gameObject.tag == "RLS")
        {
            HitEffect();
        }       
    }
    void HitEffect()
    {
        GameObject hitEffect;
        hitEffect = Instantiate(hit, this.gameObject.transform.position, Quaternion.identity);
        hitEffect.transform.parent = gameObject.transform;
        AudioSource.PlayClipAtPoint(hitSound, gameObject.transform.position);
        Destroy(hitEffect, 2);
    }
}

