using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    private float xInput;
    private float yInput;

    int score = 0;

    public GameObject winDisplay;
    [SerializeField] private Text scoreDisplay;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject restartButton;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        restartButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Game");
            });
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
        {
            gameOver.SetActive(true);
            restartButton.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput * speed, 0, yInput * speed);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;
            scoreDisplay.text = "Score - " + (score * 10);
            if (score >= 5)
            {
                winDisplay.SetActive(true);
                restartButton.SetActive(true);
            }
        }
    }
}
