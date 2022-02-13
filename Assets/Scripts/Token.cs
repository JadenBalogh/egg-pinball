using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    [SerializeField] private AudioClip wowSound;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private bool isHit = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isHit) return;
        isHit = true;
        GameManager.ScoreSystem.RegisterToken();
        audioSource.PlayOneShot(wowSound);
        spriteRenderer.enabled = false;
        Destroy(gameObject, 1.5f);
    }
}
