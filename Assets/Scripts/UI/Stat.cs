using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{

    // The actual image that we are changing the fill of
    private Image content;

    // A reference to the value text on the bar
    [SerializeField]
    private Text statValue;

    // Hold the current fill value, we use this, so that we know if we need to lerp a value
    private float currentFill;

    private float overflow;

    // The lerp speed
    [SerializeField]
    private float lerpSpeed;

    // The stat's maxValue
    public int MyMaxValue { get; set; }
    public int MyLastMaxValue { get; set; } = 0; //only used for XP

    // The currentValue
    private int currentValue;

    public bool IsFull
    {
        get { return content.fillAmount == 1; }
    }

    public float MyOverflow //only used for XP
    {
        get
        { 
            return overflow;
        }

        set { overflow = value; }
    }

    // Property for setting the current value, this has to be used every time we change the currentValue, so that everything updates correctly
    public int MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > MyMaxValue)//Makes sure that we don't get too much
            {
                overflow += value - MyMaxValue; //changed this so overflow can be added on to if player doesn't level up right away
                currentValue = MyMaxValue;
            }
            else if (value < 0) //Makes sure that we don't get below 0
            {
                currentValue = 0;
            }
            else //Makes sure that we set the current value within the bounds of 0 to max
            {
                currentValue = value;
            }

            //Calculates the currentFill, so that we can lerp
            //currentFill = (float)currentValue / MyMaxValue; //(float) ensures result is a float
            currentFill = (float)(currentValue - MyLastMaxValue) / (MyMaxValue - MyLastMaxValue); //(float) ensures result is a float

            if (statValue != null)
            {
                //Makes sure that we update the value text
                statValue.text = currentValue + " / " + MyMaxValue;
            }

        }
    }
         
    // Use this for initialization
    void Start()
    {
        //Creates a reference to the content
        content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Makes sure that we update the bar
        HandleBar();
    }

    // Initializes the bar
    public void Initialize(int currentValue, int maxValue, int lastmaxValue, float overflowValue)
    {
        if (content == null)
        {
            content = GetComponent<Image>();
        }

        MyMaxValue = maxValue;
        MyLastMaxValue = lastmaxValue;
        MyCurrentValue = currentValue; //this has to be set after the max value
        MyOverflow = overflowValue;

        //content.fillAmount = MyCurrentValue / MyMaxValue;
        currentFill = (float)(currentValue - MyLastMaxValue) / (MyMaxValue - MyLastMaxValue);
    }

    // Makes sure that the bar updates
    private void HandleBar()
    {
        if (currentFill != content.fillAmount) //If we have a new fill amount then we know that we need to update the bar
        {
            //Lerps the fill amount so that we get a smooth movement
            content.fillAmount = Mathf.MoveTowards(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }

    }

    public void Reset()
    {
        content.fillAmount = 0;
    }
}
