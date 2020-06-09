using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Anxiety : MonoBehaviour
{
    //DISPLAY SCORE

    float timer;

    public static int anxiety;

    [SerializeField]
    Text timerText;

    private void Start()
    {
        timer = 0;
        anxiety = 25;
        timerText = GetComponent<Text>();
    }

    private void Update()
    {
        if (anxiety > 50)
        {
            anxiety = 50;
        }
        if (anxiety < 0)
        {
            anxiety = 0;
        }

        if (anxiety >= 40)
        {
            timer += Time.deltaTime;
            timerText.text = (5 - (int)timer).ToString();

            if (timer >= 5)
            {
                Arrow.status = 0;
                SceneManager.LoadScene("GameOverBad");
            }
        }

        if (anxiety < 40)
        {
            timerText.text = "";
            timer = 0;
        }

        AnxietyLevels();
        
        //scoreText.text = "Anxiety: " + anxiety.ToString();
    }
    
    void AnxietyLevels()
    {
        if (Courage.courage >= 4 && Courage.courage < 6)
        {
            if(anxiety < 10)
            {
                anxiety = 10;
            }
        }
        if (Courage.courage >= 2 && Courage.courage < 4)
        {
            if (anxiety < 20)
            {
                anxiety = 20;
            }
        }
    }
}
