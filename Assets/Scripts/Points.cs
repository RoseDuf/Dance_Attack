using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] Text pointsText;

    public static int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        pointsText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points\n\n" + points.ToString();
    }
}
