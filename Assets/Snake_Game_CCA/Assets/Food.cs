/* Personal Notes: 

        * 
        

        * 


 */



using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea; //Creates a variaable to store the location of the games boundaries

    private void Start()
    {
        RandomizePosition(); //Calls the function that sets the foods position (at the start of game for this instance)
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x); //Chooses a random X coordinate within our grid
        float y = Random.Range(bounds.min.y, bounds.max.y); //Chooses a random Y coordinate within our grid

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f); //Sets the location of the food to this random position (rounded to nearest block)
    }

    private void OnTriggerEnter2D(Collider2D other) //Function that detects collision with different objects
    {
        if (other.tag == "Player"){ //If the player (snake) collides with the food, it will generate a new random position
        RandomizePosition();
        }
    }

}
