using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    Animator animator;
    float timer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("status", Arrow.status);
        timer += Time.deltaTime;
        if (timer >= 2.9f)
        {
            Arrow.status = 0;
            timer = 0;
        }
    }
}
