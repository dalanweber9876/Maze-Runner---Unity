using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public int deathCounter = 0;

    // Get the game over screen element from Unity.
    public GameObject gameOverScreen;

    // Get the slime code. 
    public SlimeScript slime;

    // Get the three text elements from Unity. 
    public Text numOfDeaths;
    public Text endNumOfDeaths;
    public Text endTime;

    // Initialize the game time
    public float gameTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the game timer every frame
        gameTime += Time.deltaTime;
    }

    public void Dead()
    {
        deathCounter += 1;

        // Reset the character at the start everytime it dies. 
        slime.transform.position = new Vector2(-1, 1);

        // Update death display.
        numOfDeaths.text = "Deaths: " + deathCounter.ToString();
    }
    public void YouWin()
    {
        // Upon completion, the game over screen is turned on
        gameOverScreen.SetActive(true);

        // Make it so that you can't control the slime once the game over screen is displayed
        slime.StopRunning();

        // Show the final number of deaths on the end game screen
        endNumOfDeaths.text = "Deaths: " + deathCounter.ToString();

        // Show the final time on the end game screen
        float minutes = Mathf.FloorToInt(gameTime / 60);
        float seconds = Mathf.FloorToInt(gameTime % 60);
        endTime.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RestartGame()
    {
        // When the restart button is pressed, it resets the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathCounter = 0;
    }
   
}
