using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
   public int playerScore;
   public int highestScore;
   public Text scoreText;
   public Text highestScoreText;
   public GameObject gameOverScreen;
   public AudioSource pointSound;
   

   void Start(){
      highestScoreText.text = "Highest Score: " + PlayerPrefs.GetInt("TopScore").ToString();
   }

    [ContextMenu("Increase Score")]
   public void addScore(int scoreToAdd){
   
   playerScore += scoreToAdd;
   pointSound.Play();
   scoreText.text = playerScore.ToString();
   }

   public void checkTopScore(){

      if (playerScore>PlayerPrefs.GetInt("TopScore")){
         highestScore = playerScore;
         PlayerPrefs.SetInt("TopScore", highestScore);

         highestScoreText.text = "Highest Score: " + PlayerPrefs.GetInt("TopScore").ToString();
      }
      //Debug.Log(PlayerPrefs.GetInt("TopScore"));
   }

  

   public void restartGame(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void gameOver(){
      gameOverScreen.SetActive(true);
   }


}
