using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {

    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 4;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI playerPosText;
    public TextMeshProUGUI playerVelocityText;
    public TextMeshProUGUI distanceText;
    private Vector3 oldPosition;
    private Vector3 currentPosition;
    private Vector3 playerVelocity;

    void Start() {
        count = 0;
        winText.text = "";
        SetCountText();
        oldPosition = transform.position;
    }

    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);

        currentPosition = transform.position;
        playerPosText.text = "Position: " + currentPosition.ToString("0.00");

        playerVelocity = (currentPosition - oldPosition) / Time.deltaTime;

        playerVelocityText.text = "Velocity: " + playerVelocity.magnitude.ToString("0.00");
        oldPosition = transform.position;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText() {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups) {
            winText.text = "You win!";
        }
    }
}
