using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    [SerializeField] private AudioClip sizzleSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.PlayOneShot(sizzleSound);
        GameManager.EndGame();
    }
}
