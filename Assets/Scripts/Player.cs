using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Animator animator;

    bool superconfident;
    bool confident;
    bool neutral;
    bool stressed;
    bool anxious;

    float levelTimer;

    void Start()
    {
        Points.points = 0;
        levelTimer = 0;

        superconfident = false;
        confident = false;
        neutral = false;
        stressed = true;
        anxious = false; //start anxious

        // Get references to other components and game objects
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckAnxiety();
        Animate();
        Timer();
    }

    void CheckAnxiety()
    {
        
        if (Anxiety.anxiety < 10 && Courage.courage == 6)
        {
            superconfident = true;
            confident = false;
            neutral = false;
            stressed = false;
            anxious = false;
        }
        else if (Courage.courage < 6)
        {
            superconfident = false;
            confident = true;
        }
        if (Anxiety.anxiety < 20 && Anxiety.anxiety >= 10 && Courage.courage >= 4)
        {
            confident = true;
            superconfident = false;
            neutral = false;
            stressed = false;
            anxious = false;
        }
        else if (Courage.courage < 4)
        {
            confident = false;
            neutral = true;
        }
        if (Anxiety.anxiety < 30 && Anxiety.anxiety >= 20 && Courage.courage >= 2)
        {
            neutral = true;
            superconfident = false;
            confident = false;
            stressed = false;
            anxious = false;
        }
        else if (Courage.courage < 2)
        {
            neutral = false;
            stressed = true;
        }
        if (Anxiety.anxiety < 40 && Anxiety.anxiety >= 30)
        {
            stressed = true;
            neutral = false;
            superconfident = false;
            confident = false;
            anxious = false;
        }
        if (Anxiety.anxiety >= 40) // should be confidence
        {
            anxious = true;
            superconfident = false;
            confident = false;
            neutral = false;
            stressed = false;
        }
    }

    void Animate()
    {
        print(neutral);
        animator.SetBool("superconfident", superconfident);
        animator.SetBool("confident", confident);
        animator.SetBool("neutral", neutral);
        animator.SetBool("stressed", stressed);
        animator.SetBool("anxious", anxious);

        animator.SetInteger("direction", Arrow.direction);
    }

    void Timer()
    {
        levelTimer += Time.deltaTime;

        if (levelTimer >= 60f)
        {
            Arrow.status = 0;
            SceneManager.LoadScene("GameOverGood");
        }
    }
}
