using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Rigidbody2D pinLeft;
    [SerializeField] private Rigidbody2D pinRight;
    [SerializeField] private float startAngle = -0.15f;
    [SerializeField] private float maxAngle = 0.3f;
    [SerializeField] private float upAccel = 10f;
    [SerializeField] private float downAccel = 10f;
    [SerializeField] private AudioClip flipperSound;

    private AudioSource audioSource;

    private float leftAngle = 0;
    private float rightAngle = 0;

    private bool isLeftUp = false;
    private bool isRightUp = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        leftAngle = startAngle;
        rightAngle = startAngle;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            pinLeft.angularVelocity += upAccel * Time.deltaTime;
        }
        else
        {
            pinLeft.angularVelocity -= downAccel * Time.deltaTime;
        }

        if (pinLeft.angularVelocity > 0 && !isLeftUp)
        {
            isLeftUp = true;
            audioSource.PlayOneShot(flipperSound);
        }
        else if (pinLeft.angularVelocity <= 0)
        {
            isLeftUp = false;
        }

        if (pinLeft.angularVelocity > 0 && pinLeft.transform.rotation.z > maxAngle)
        {
            pinLeft.angularVelocity = 0;
        }
        if (pinLeft.angularVelocity < 0 && pinLeft.transform.rotation.z < startAngle)
        {
            pinLeft.angularVelocity = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pinRight.angularVelocity -= upAccel * Time.deltaTime;
        }
        else
        {
            pinRight.angularVelocity += downAccel * Time.deltaTime;
        }

        if (pinRight.angularVelocity < 0 && !isRightUp)
        {
            isRightUp = true;
            audioSource.PlayOneShot(flipperSound);
        }
        else if (pinRight.angularVelocity >= 0)
        {
            isRightUp = false;
        }

        if (pinRight.angularVelocity < 0 && pinRight.transform.rotation.z < -maxAngle)
        {
            pinRight.angularVelocity = 0;
        }
        if (pinRight.angularVelocity > 0 && pinRight.transform.rotation.z > -startAngle)
        {
            pinRight.angularVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
