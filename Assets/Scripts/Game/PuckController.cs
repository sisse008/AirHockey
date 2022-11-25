using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    public Rigidbody rb;

    public delegate void PuckMoveAction(Vector3 velocity);
    public event PuckMoveAction PuckMoveDirectionChanged;

    public bool isMoving { get; private set; }
    public Vector3 Position => rb.position;

    public float radius { get; private set; } = 0.9292f / 2f;

    AudioSource puckAudioSource;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        puckAudioSource = GetComponent<AudioSource>();
       
    }
    private void Start()
    {
        radius = transform.localScale.x / 2;
    }
    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }

    private void Update()
    {
        isMoving = rb.velocity != Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            SendPuckDirectionChangedEvent();
            PayPadHitPuckSound();
        }
        else if(collision.gameObject.tag == "Boundry")
        {
            SendPuckDirectionChangedEvent();
            PlayPuckHitWallSound();
        }     
    }

    void SendPuckDirectionChangedEvent()
    {
        PuckMoveDirectionChanged?.Invoke(rb.velocity);
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
