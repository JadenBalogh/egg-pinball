using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private AudioClip[] boks;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.ScoreSystem.RegisterHit();
        int idx = Random.Range(0, boks.Length);
        audioSource.PlayOneShot(boks[idx]);
    }
}
