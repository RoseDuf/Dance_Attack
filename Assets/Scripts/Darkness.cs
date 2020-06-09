using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Anxiety.anxiety < 10)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
        if (Anxiety.anxiety < 20 && Anxiety.anxiety >= 10)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
        }
        if (Anxiety.anxiety < 30 && Anxiety.anxiety >= 20)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        }
        if (Anxiety.anxiety < 40 && Anxiety.anxiety >= 30)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
        }
        if (Anxiety.anxiety >= 40) // should be confidence
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
        }
    }
}
