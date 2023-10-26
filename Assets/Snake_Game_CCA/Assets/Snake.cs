/* Personal Notes: 

        * The fixed timestep in project settings basically adjusts the speed of the snake. You can change it there manually or you can write 
          code for it to change if a user selects a button


 */



using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{

    private Vector2 _direction = Vector2.right; //Creates a variable to store the direction (set to right by default)

    private List<Transform> _segments; //Creates a list that store info about the snakes body

    public Transform segmentPrefab;

    public Text scoreText; //Represents the ScoreText object in the game
    public Text topScoreText; //Represents the TopScoreText object in the game
    
    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        scoreText.text = "Score: " + Scoring.totalScore;
        topScoreText.text = "Top Score: " + Scoring.topScore;
        Time.fixedDeltaTime = 0.07f;
    }

    private void Update() //Gets called during every frame of the game to update variables
    {

        if (Input.GetKeyDown(KeyCode.W)) //Basically stating that when the "w" key is pressed, the following will happen
        {
            _direction = Vector2.up; //Changes the direction of the snake to travel upwards
        }
        else if (Input.GetKeyDown(KeyCode.S)) //If the "s" key is pressed
        {
            _direction = Vector2.down; //Changes the direction of the snake to travel upwards
        }
        else if (Input.GetKeyDown(KeyCode.A)) //If the "a" key is pressed
        {
            _direction = Vector2.left; //Changes the direction of the snake to travel left
        }
        else if (Input.GetKeyDown(KeyCode.D)) //If the "d" key is pressed
        {
            _direction = Vector2.right; //Changes the direction of the snake to travel right
        }

    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--) //Ensures that each segment of the snake moves to the position of the last as each one moves forward
        {
            _segments[i].position = _segments[i-1].position;
        }
        
        // This chunk of code actaully updates the position (on screen) of the snake whereas the Update function has statements that update the variables
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab); //Generates a new part of the snake to be added to the body
        segment.position = _segments[_segments.Count - 1].position; //Adds it to the position right behind the last part of the body

        _segments.Add(segment);
    }

    private void ResetState(){
        for (int i = 1; i < _segments.Count; i++) { //Remove the current segments from the snake
            Destroy(_segments[i].gameObject);
        }

        Scoring.totalScore = 0;
        scoreText.text = "Score: " + Scoring.totalScore;

        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero; //Puts the snake head back in the start position
        Time.fixedDeltaTime = 0.07f;
    }

    private void OnTriggerEnter2D(Collider2D other) //Function that detects collision with different objects
    {
        if (other.tag == "Food"){ //If the player (snake) collides with the food, the snake grows
            Grow();
            Scoring.totalScore += 1;
            scoreText.text = "Score: " + Scoring.totalScore;

            if (Scoring.totalScore > Scoring.topScore){
            Scoring.topScore = Scoring.totalScore;
            }

        topScoreText.text = "Top Score: " + Scoring.topScore;

        } else if (other.tag == "Obstacle") { //If the player runs into a wall or themselves the game resets (walls and body tagged as "Obstacle")
            ResetState();
        }
    }

    void OnDestroy()
    {
        Time.fixedDeltaTime = 0.02f;
    }
}
