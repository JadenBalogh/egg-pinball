using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float breakVelocity;
    [SerializeField] private GameObject breakEffectPrefab;
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private AudioClip[] boks;

    private AudioSource audioSource;
    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        bool isTooFast = rigidbody2D.velocity.sqrMagnitude > breakVelocity * breakVelocity;
        if (isTooFast && !col.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(breakSound);
            Instantiate(breakEffectPrefab, transform.position, Quaternion.identity);
            GameManager.EndGame();
            Destroy(gameObject);
        }
        else
        {
            GameManager.ScoreSystem.RegisterHit();
            int idx = Random.Range(0, boks.Length);
            audioSource.PlayOneShot(boks[idx]);
        }
    }
}
