using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    public Rigidbody rb;

    AudioSource puckAudioSource;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        puckAudioSource = GetComponent<AudioSource>();
       
    }
    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PayPadHitPuckSound();
        }
        else if(collision.gameObject.tag == "Boundry")
        {
            PlayPuckHitWallSound();
        }     
    }
    void PlayPuckHitWallSound()
    {
        puckAudioSource.pitch = 1.5f;
        puckAudioSource.Play();
    }

    void PayPadHitPuckSound()
    {
        puckAudioSource.pitch = 1f;
        puckAudioSource.Play();
    }

}
