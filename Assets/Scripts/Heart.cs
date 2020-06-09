using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Anxiety.anxiety < 10)
        {
            anim.speed = 0.33333333f;
        }
        if (Anxiety.anxiety < 20 && Anxiety.anxiety >= 10)
        {
            anim.speed = 0.5f;
        }
        if (Anxiety.anxiety < 30 && Anxiety.anxiety >= 20)
        {
            anim.speed = 1f;
        }
        if (Anxiety.anxiety < 40 && Anxiety.anxiety >= 30)
        {
            anim.speed = 2f;
        }
        if (Anxiety.anxiety >= 40) // should be confidence
        {
            anim.speed = 3f;
        }
    }
}
