using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    private float jumpingPower = 10;
    public float GravityModifier;
    private bool GroundContact;
    public bool GameOver = false;
    private Animator PlayerAnim;
    public ParticleSystem ObstacleParticle;
    public ParticleSystem RunParticle;
    public AudioClip JumpingSound;
    public AudioClip ImpactSound;
    private AudioSource PlayerSource;
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();
        PlayerSource = GetComponent<AudioSource>();
        // Physics.gravity = Physics.gravity * GravityModifier;
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && GroundContact == true && GameOver == false) {
            PlayerRb.AddForce(Vector3.up * jumpingPower, ForceMode.Impulse);
            GroundContact = false;
            PlayerAnim.SetTrigger("Jump_trig");
            RunParticle.Stop();
            PlayerSource.PlayOneShot(JumpingSound, 0.8f);
         }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GroundContact = true;
            RunParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            Debug.Log("Game Over");
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            ObstacleParticle.Play();
            RunParticle.Stop();
            PlayerSource.PlayOneShot(ImpactSound, 0.8f);
        }
    }
}
