using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straw : MonoBehaviour
{
    [SerializeField] private AudioClip strawSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.PlayOneShot(strawSound);
    }
}
