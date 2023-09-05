using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float T�m;
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
        if (0<T�m)
        {
            T�m -= Time.deltaTime;
            float number = Mathf.FloorToInt(T�m);
            TimerText.text = number.ToString();
          
            if (number < PlayerPrefs.GetFloat("HighScore", 10))
            {
                PlayerPrefs.SetFloat("HighScore", number);
                HighScoreText.text = number.ToString();
            }
                


        }
        if(T�m <=0.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
    }
  

}
