using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    [SerializeField] GameObject explode;

    //this will be according to level
    float mSpeed;

    //booleans
    bool inRed;
    bool inYellow;
    bool inGreen;
    public static int status = 0;

    float animationTimer = 0f;

    public static int direction = 4; //0:up, 1:down, 2:right, 3:left

    //Things we need to animate
    Animator mAnimator;

    // Reference to audio sources
    [SerializeField] AudioClip mCoinSound;

    public static List<GameObject> arrows = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        arrows.Add(gameObject);

        //speeds according to level
        mSpeed = Courage.courage+1;

        inRed = false;
        inYellow = false;
        inGreen = false;

        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Remove();
        UpdateList();
        Movement();
        Timer();
    }

    private void Update()
    {
        KeyPress();
    }

    void Timer()
    {
        if (direction != 4)
        {
            animationTimer += Time.deltaTime;
        }

        if (animationTimer >= 0.9f)
        {
            direction = 4;
            animationTimer = 0;
        }
    }

    //need this or else if there are 2 arrows with the same direction will both get destroyed at the same time
    void UpdateList()
    {
        if (arrows[0] == null)
        {
            for (int i = 1; i < arrows.Count; i++)
            {
                arrows[i - 1] = arrows[i];
            }
            arrows.RemoveAt(arrows.Count-1);
        }
    }

    //upwards movement 
    private void Movement()
    {
        mSpeed = Courage.courage+1;

        //transform.right is a vector 3
        Vector2 upwards = new Vector2(transform.up.x, transform.up.y);

        //using Vector2.right is not relative to our rotation (object will just go right no matter what rotation)
        transform.Translate(upwards * Time.fixedDeltaTime * mSpeed / 5);
    }

    //if arrow out of screen, destroy it
    private void Remove()
    {
        if (transform.position.y > -0.445f)
        {
            status = 1;
            Missed();
        }
    }

    //inputs and their conditions
    void KeyPress()
    {
        if (Input.GetButtonDown("Up") && arrows[0] != null)
        {
            if (arrows[0].tag == "Up")
            {
                bool check = CheckIfInColor();
                if (check == true)
                {
                    AudioSource.PlayClipAtPoint(mCoinSound, transform.position);
                    CheckColor();
                    direction = 0;
                }
            }
            else
            {
                status = 1;
                Missed();
            }
        }
        if (Input.GetButtonDown("Down") && arrows[0] != null)
        {
            if (arrows[0].tag == "Down")
            {
                bool check = CheckIfInColor();
                if (check == true)
                {
                    AudioSource.PlayClipAtPoint(mCoinSound, transform.position);
                    CheckColor();
                    direction = 1;
                }
            }
            else
            {
                status = 1;
                Missed();
            }
        }
        if (Input.GetButtonDown("Right") && arrows[0] != null)
        {
            if (arrows[0].tag == "Right")
            {
                bool check = CheckIfInColor();
                if (check == true)
                {
                    AudioSource.PlayClipAtPoint(mCoinSound, transform.position);
                    CheckColor();
                    direction = 2;
                }
            }
            else
            {
                status = 1;
                Missed();
            }
        }
        if (Input.GetButtonDown("Left") && arrows[0] != null)
        {
            if (arrows[0].tag == "Left")
            {
                bool check = CheckIfInColor();
                if (check == true)
                {
                    AudioSource.PlayClipAtPoint(mCoinSound, transform.position);
                    CheckColor();
                    direction = 3;
                }
            }
            else
            {
                status = 1;
                Missed();
            }
        }
    }

    private bool CheckIfInColor()
    {
        if (inRed || inGreen || inYellow)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckColor()
    {
        if (inRed && transform == arrows[0].transform)
        {
            status = 2;
            Points.points += (Courage.courage * 1);
            Anxiety.anxiety -= 1;
            Instantiate(explode, transform.position, transform.rotation);
            arrows[0] = null;
            Destroy(gameObject);
            //goes to UpdateList
        }
        else if (inYellow && transform == arrows[0].transform)
        {
            status = 3;
            Points.points += (Courage.courage * 2);
            Anxiety.anxiety -= 2;
            Instantiate(explode, transform.position, transform.rotation);
            arrows[0] = null;
            Destroy(gameObject);
            //goes to UpdateList
        }
        else if (inGreen && transform == arrows[0].transform)
        {
            status = 4;
            Points.points += (Courage.courage * 3);
            Anxiety.anxiety -= 3;
            Instantiate(explode, transform.position, transform.rotation);
            arrows[0] = null;
            Destroy(gameObject);
            //goes to UpdateList
        }
    }

    //check if arrow missed
    void Missed()
    {
        if (transform == arrows[0].transform)
        {
            Debug.Log("Missed!");
            Anxiety.anxiety += 2;
            arrows[0] = null;
            Destroy(gameObject);
            //else go to UpdateList
        }
    }

    //check in which color bar the arrow aligns with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Red")
        {
            inRed = true;
        }
        if (collision.tag == "Yellow")
        {
            inYellow = true;
        }
        if (collision.tag == "Green")
        {
            inGreen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Red")
        {
            inRed = false;
        }
        if (collision.tag == "Yellow")
        {
            inYellow = false;
        }
        if (collision.tag == "Green")
        {
            inGreen = false;
        }
    }
}
