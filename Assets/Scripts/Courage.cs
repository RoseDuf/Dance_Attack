using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Courage : MonoBehaviour
{

    //courage DISPLAY

    [SerializeField] Image[] bars;
    
    public static int courage;
    public static bool nextcourage;

    [SerializeField] Text courageText;

    private void Start()
    {
        courageText = GetComponent<Text>();

        //initialise
        nextcourage = false;
        courage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //only increase courage when player chooses to do so
        if ((Input.GetButtonDown("Increase") && courage < 6))
        {
            courage += 1;
        }
        if ((Input.GetButtonDown("Decrease") && courage > 1))
        {
            courage -= 1;
        }

        switch (courage)
        {
            case 1:
                bars[0].gameObject.SetActive(true);
                bars[1].gameObject.SetActive(false);
                bars[2].gameObject.SetActive(false);
                bars[3].gameObject.SetActive(false);
                bars[4].gameObject.SetActive(false);
                bars[5].gameObject.SetActive(false);
                break;
            case 2:
                bars[0].gameObject.SetActive(true);
                bars[1].gameObject.SetActive(true);
                bars[2].gameObject.SetActive(false);
                bars[3].gameObject.SetActive(false);
                bars[4].gameObject.SetActive(false);
                bars[5].gameObject.SetActive(false);
                break;
            case 3:
                bars[0].gameObject.SetActive(true);
                bars[1].gameObject.SetActive(true);
                bars[2].gameObject.SetActive(true);
                bars[3].gameObject.SetActive(false);
                bars[4].gameObject.SetActive(false);
                bars[5].gameObject.SetActive(false);
                break;
            case 4:
                bars[0].gameObject.SetActive(true);
                bars[1].gameObject.SetActive(true);
                bars[2].gameObject.SetActive(true);
                bars[3].gameObject.SetActive(true);
                bars[4].gameObject.SetActive(false);
                bars[5].gameObject.SetActive(false);
                break;
            case 5:
                bars[0].gameObject.SetActive(true);
                bars[1].gameObject.SetActive(true);
                bars[2].gameObject.SetActive(true);
                bars[3].gameObject.SetActive(true);
                bars[4].gameObject.SetActive(true);
                bars[5].gameObject.SetActive(false);
                break;
            case 6:
                bars[0].gameObject.SetActive(true);
                bars[1].gameObject.SetActive(true);
                bars[2].gameObject.SetActive(true);
                bars[3].gameObject.SetActive(true);
                bars[4].gameObject.SetActive(true);
                bars[5].gameObject.SetActive(true);
                break;
            default:
                bars[0].gameObject.SetActive(false);
                bars[1].gameObject.SetActive(false);
                bars[2].gameObject.SetActive(false);
                bars[3].gameObject.SetActive(false);
                bars[4].gameObject.SetActive(false);
                bars[5].gameObject.SetActive(false);
                break;
        }

        //courageText.text = "Courage: " + courage.ToString();
    }
}
