using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class eventHandlerSc : MonoBehaviour
{
    //feed it god
    public GameObject deicide;
    //pass in the ui elements
    public Canvas eventCan;
    public Button butt1;
    public Button butt2;
    public Button butt3;
    public Button butt4;
    public Button testButton;
    public Text txt;

    //have bools to decide the event for the start function, only place where we can get component of the buttons
    public bool ifChicken = false;
    public bool ifPhilosopher = false;
    public bool ifWolf = false;

    //have an index for which choice was made for multiple choice events
    public int indexChoice;
    // Start is called before the first frame update
    void Start()
    {
        //keep the canvas used for event info disabled at the start
        eventCan.enabled = false;
        //randomly select which event
        eventChoose();
        //if we've encountered a chicken
        if (ifChicken == true && ifPhilosopher == false && ifWolf == false)
        {
            //then use the info from the chicken script
            //set the description
            txt.text = deicide.GetComponent<chickenEvent>().descr();

            //then set the button descriptions
            //we only need two buttons
            //first button - chase the chicken
            //second button - leave the child
            

            //set up the buttons to click
            butt1.onClick.AddListener(() => replaceDescr(0)); 
        }
        //if we encounter the philosphers
        if (ifChicken == false && ifPhilosopher == true && ifWolf == false)
        {
            butt1.onClick.AddListener(() => replaceDescr(1));
            butt2.onClick.AddListener(() => replaceDescr(2));
            butt3.onClick.AddListener(() => replaceDescr(3));
            butt4.onClick.AddListener(() => replaceDescr(4));
        }
        //if we ecounter wolves
        if(ifChicken == false && ifPhilosopher == false && ifWolf == true)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    ///have a function to decide which event is happening
    public void eventChoose()
    {
        //enable the infor canvas for the event
        eventCan.enabled = true;

        //randomly decide which event will happen
        int decide = Random.Range(0, 3);
        Debug.Log(decide);
        switch(decide)
        {
            //chicken event
            case 0:
                //only enable the two buttons you will need
                butt1.enabled = true;
                butt2.enabled = true;
                butt3.gameObject.SetActive(false);
                butt4.gameObject.SetActive(false);
                ifChicken = true;
                ifPhilosopher = false;
                ifWolf = false;
                //set up the ui
                txt.text = deicide.GetComponent<chickenEvent>().descr();
                butt1.GetComponentInChildren<Text>().text = deicide.GetComponent<chickenEvent>().chaseChicken();
                butt2.GetComponentInChildren<Text>().text = deicide.GetComponent<chickenEvent>().leaveChld();
                break;
             
            //philosopher event
            case 1:
                butt1.enabled = true;
                butt2.enabled = true;
                butt3.enabled = true;
                butt4.enabled = true;
                ifPhilosopher = true;
                ifChicken = false;
                ifWolf = false;
                //set up the ui
                txt.text = deicide.GetComponent<philosopherEvent>().descr();
                butt1.GetComponentInChildren<Text>().text = deicide.GetComponent<philosopherEvent>().sideWithMage();
                butt2.GetComponentInChildren<Text>().text = deicide.GetComponent<philosopherEvent>().sideWithKnight();
                butt3.GetComponentInChildren<Text>().text = deicide.GetComponent<philosopherEvent>().sideWithNeither();
                butt4.GetComponentInChildren<Text>().text = deicide.GetComponent<philosopherEvent>().leaveThemBoth();
                break;

               //wolves event
            case 2:
                butt1.enabled = true;
                butt2.enabled = true;
                butt3.enabled = false;
                butt4.enabled = false;
                ifWolf = true;
                ifChicken = false;
                ifPhilosopher = false;
                break;
            default:
                break;
        }

      
    }
    //replace the description with a new one
    public void replaceDescr(int index)
    {
        
        if (ifChicken && !ifPhilosopher && !ifWolf)
        {
            txt.text = deicide.GetComponent<chickenEvent>().check();
            //repurpose the first button
            butt1.GetComponentInChildren<Text>().text = "Close.";

            //disable the other button(s) we wont need them now
            butt2.gameObject.SetActive(false);

            //set button1 to clsoe the canvas and switch to the overworld
            butt1.onClick.AddListener(() => closeCanvas());

        }
        if(ifPhilosopher && !ifChicken && !ifWolf)
        {
             txt.text = "philosopher";
            if(index == 1)
            {
               deicide.GetComponent<philosopherEvent>().choose(index);
               txt.text = deicide.GetComponent<philosopherEvent>().resultText();

                //disable other buttons
                //set the first button to close out the canvas 
                butt1.GetComponentInChildren<Text>().text = "Close.";
                butt2.gameObject.SetActive(false);
                butt3.gameObject.SetActive(false);
                butt4.gameObject.SetActive(false);

                butt1.onClick.AddListener(() => closeCanvas());
            }
            if(index == 2)
            {
                deicide.GetComponent<philosopherEvent>().choose(index);
                txt.text = deicide.GetComponent<philosopherEvent>().resultText();

                //disable other buttons
                //set the first button to close out the canvas 
                butt1.GetComponentInChildren<Text>().text = "Close.";
                butt2.gameObject.SetActive(false);
                butt3.gameObject.SetActive(false);
                butt4.gameObject.SetActive(false);

                butt1.onClick.AddListener(() => closeCanvas());

            }
            if(index == 3)
            {
                deicide.GetComponent<philosopherEvent>().choose(index);
                txt.text = deicide.GetComponent<philosopherEvent>().resultText();

                //disable other buttons
                //set the first button to close out the canvas 
                butt1.GetComponentInChildren<Text>().text = "Close.";
                butt2.gameObject.SetActive(false);
                butt3.gameObject.SetActive(false);
                butt4.gameObject.SetActive(false);

                butt1.onClick.AddListener(() => closeCanvas());
            }
            if(index == 4)
            {
                deicide.GetComponent<philosopherEvent>().choose(index);
                txt.text = deicide.GetComponent<philosopherEvent>().resultText();

                //disable other buttons
                //set the first button to close out the canvas 
                butt1.GetComponentInChildren<Text>().text = "Close.";
                butt2.gameObject.SetActive(false);
                butt3.gameObject.SetActive(false);
                butt4.gameObject.SetActive(false);

                butt1.onClick.AddListener(() => closeCanvas());
            }
        }
        if(ifWolf && !ifChicken && !ifPhilosopher)
        {
            txt.text = "wolves";
        }
       
    }

    //have a function that wil leave wahtever event has been called
    public void leave()
    {
        
    }
    //close the canvas and return to the overworld
    public void closeCanvas()
    {
        eventCan.enabled = false;
        //switch to the overworld
        //deicide.GetComponent<ChangeScene>.changeScene("Map");
    }

    public void startFight()
    {

    }
}
