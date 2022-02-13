using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.PlayOneShot(clickSound);
        GameManager.ScoreSystem.RegisterButton();
    }
}
