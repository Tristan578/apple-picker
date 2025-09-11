using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    private void Update()
    {
        // Get the current screen position of the mouse from the new Input System
        Vector2 mousePos2D = Mouse.current.position.ReadValue();

        // Convert the point from 2D screen space into 3D game world space
        // We use 10.0f for the z-position to place it in front of the camera
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(new Vector3(mousePos2D.x, mousePos2D.y, 10.0f));

        // Move the x position of this Basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}