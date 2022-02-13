using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static InputSystem InputSystem { get; set; }
    public static ScoreSystem ScoreSystem { get; set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        InputSystem = GetComponent<InputSystem>();
        ScoreSystem = GetComponent<ScoreSystem>();
    }

    public static void EndGame() => instance.InstanceEndGame();
    public void InstanceEndGame()
    {
        Debug.Log("End Game");
        ScoreSystem.LockScore();
    }
}
