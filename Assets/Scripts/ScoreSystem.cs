using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private float spawnY;
    [SerializeField] private float spawnXMin;
    [SerializeField] private float spawnXMax;
    [SerializeField] private int scorePerHit;
    [SerializeField] private int scorePerButton;
    [SerializeField] private int scorePerToken;
    [SerializeField] private int scorePerSecond;

    [SerializeField] private TextMeshProUGUI hitText;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private TextMeshProUGUI tokenText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private int numHits = 0;
    private int buttonHits = 0;
    private int tokensCollected = 0;
    private float timeAlive = 0;
    private int totalScore = 0;

    private bool isLocked = false;

    private void Start()
    {
        Vector2 randPos = new Vector2(Random.Range(spawnXMin, spawnXMax), spawnY);
        Instantiate(eggPrefab, randPos, Quaternion.identity);
    }

    private void Update()
    {
        if (isLocked) return;
        timeAlive += Time.deltaTime;
        timeText.text = "Time: " + timeAlive.ToString("0.##");
        UpdateScore();
    }

    public void RegisterHit()
    {
        if (isLocked) return;
        numHits++;
        hitText.text = "Hits: " + numHits;
        UpdateScore();
    }

    public void RegisterButton()
    {
        if (isLocked) return;
        buttonHits++;
        buttonText.text = "Buttons: " + buttonHits;
        UpdateScore();
    }

    public void RegisterToken()
    {
        if (isLocked) return;
        tokensCollected++;
        tokenText.text = "Tokens: " + tokensCollected;
        UpdateScore();
    }

    public void LockScore()
    {
        isLocked = true;
    }

    private void UpdateScore()
    {
        if (isLocked) return;
        int score = scorePerHit * numHits + scorePerButton * buttonHits + scorePerToken * tokensCollected + (int)timeAlive * scorePerSecond;
        totalScoreText.text = "Score: " + score;
    }
}
