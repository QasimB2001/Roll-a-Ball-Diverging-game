using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {

    public TextMeshProUGUI distanceText;
    public Vector3 currentPosition;
    private LineRenderer lineRenderer;
    private GameObject[] Pickups;
    private float distance;
    private GameObject closestPickup;

    // Start is called before the first frame update
    void Start() {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        currentPosition = transform.position;

        Pickups = GameObject.FindGameObjectsWithTag("PickUp");

        float closestDistance = 1000000;

        foreach (GameObject pickup in Pickups) {
            distance = (pickup.transform.position - currentPosition).magnitude;

            if (distance < closestDistance) {
                closestDistance = distance;
                closestPickup = pickup;
            }
        }

        foreach (GameObject pickup in Pickups) {
            if (pickup == closestPickup)
            {
                pickup.GetComponent<Renderer>().material.color = Color.blue;
                distance = (pickup.transform.position - currentPosition).magnitude;
                distanceText.text = "Distance: " + distance.ToString("0.00");

                // 0 for the start point , position vector ’ startPosition ’
                lineRenderer.SetPosition(0, currentPosition);
                // 1 for the end point , position vector ’endPosition’
                lineRenderer.SetPosition(1, pickup.transform.position);
                // Width of 0.1 f both at origin and end of the line
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;
            }
            else {
                pickup.GetComponent<Renderer>().material.color = Color.white;
            }
        }



    }
}
