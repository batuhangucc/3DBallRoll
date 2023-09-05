using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Tým;
    public Text TimerText;
    public float HighScore;
    public Text HighScoreText;
    public void Start()
    {
        HighScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString(); 
    }
    public void Update()
    {
        CrateTimer();
    }
    public void CrateTimer()
    {
        if (0<Tým)
        {
            Tým -= Time.deltaTime;
            float number = Mathf.FloorToInt(Tým);
            TimerText.text = number.ToString();
          
            if (number < PlayerPrefs.GetFloat("HighScore", 10))
            {
                PlayerPrefs.SetFloat("HighScore", number);
                HighScoreText.text = number.ToString();
            }
                


        }
        if(Tým <=0.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
    }
  

}
