using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static OVRInput;
using UnityEngine.SceneManagement;
using System.Timers;



public delegate void MetronomeEvent(metronome metronome);


public class metronome : MonoBehaviour
{

    //Spheres

    [SerializeField] private GameObject sphere1;
    [SerializeField] private GameObject sphere2;
    [SerializeField] private GameObject sphere3;
    [SerializeField] private GameObject sphere4;


    // counters
    [SerializeField] private GameObject counter1;
    [SerializeField] private GameObject counter2;
    [SerializeField] private GameObject counter3;
    [SerializeField] private GameObject counter4;



    //lines
    [SerializeField] private GameObject line1;
    [SerializeField] private GameObject line2;
    [SerializeField] private GameObject line3;
    [SerializeField] private GameObject line4;

    //score
    [SerializeField] public GameObject scoreText;
    [SerializeField] public GameObject multiplierText;
    [SerializeField] public GameObject failLight;


    //gameover
    [SerializeField] public GameObject daytime;
    [SerializeField] public GameObject dashboard;
    [SerializeField] private GameObject song;
    [SerializeField] private GameObject spawner;



    public int Base;
    public int Step;
    public float BPM;
    public int CurrentStep = 1;
    public int CurrentMeasure;

    private int sequence = 0;

    private bool right = false;

    private float interval;
    private float nextTime;

    public event MetronomeEvent OnTick;
    public event MetronomeEvent OnNewMeasure;
    private double num_seconds_elapsed = 0;

    [SerializeField] public Controller controller;

    [SerializeField] public GameObject score;

    public int internal_score;
    int number_of_misses;
    int multiplier;

    // Start is called before the first frame update
    void Start()
    {


     //   song = AudioSource.Find("song");
        sphere1 = GameObject.Find("Sphere");
        sphere2 = GameObject.Find("Sphere1");
        sphere3 = GameObject.Find("Sphere2");
        sphere4 = GameObject.Find("Sphere3");


        counter1 = GameObject.Find("counter1");
        counter2 = GameObject.Find("counter2");
        counter3 = GameObject.Find("counter3");
        counter4 = GameObject.Find("counter4");
        counter1.SetActive(false);
        counter2.SetActive(false);
        counter3.SetActive(false);
        counter4.SetActive(false);
        line1 = GameObject.Find("SingleLine-LightSaber");
        line2 = GameObject.Find("SingleLine-LightSaber2");
        line3 = GameObject.Find("SingleLine-LightSaber3");
        line4 = GameObject.Find("SingleLine-LightSaber4");

        scoreText = GameObject.Find("Score");

        multiplierText = GameObject.Find("multiplier");

        daytime = GameObject.Find("Light");
        dashboard = GameObject.Find("dashboard");
        spawner = GameObject.Find("spawner");

        dashboard.SetActive(false);
        internal_score = 0;
        number_of_misses = 0;
        multiplier = 1;

        setScoreText(internal_score);
        song.SetActive(false);


        gameStart();
       //Invoke("StartMetronome", 5);
        //timer to update tempo halfway through
       // Timer timer = new Timer(1000);
       // timer.Elapsed += OnTick2; // Which can also be written as += new ElapsedEventHandler(OnTick);
       // timer.Start();
    }


    private void gameStart()
    {
        dashboard.SetActive(true);
        daytime.SetActive(false);
        sphere1.SetActive(false);
        sphere2.SetActive(false);
        sphere3.SetActive(false);
        sphere4.SetActive(false);
        line1.SetActive(false);
        line2.SetActive(false);
        line3.SetActive(false);
        line4.SetActive(false);
        song.SetActive(false);
        spawner.SetActive(false);
    }


    private void OnTick2(object source, ElapsedEventArgs e)
    {

        num_seconds_elapsed++;

        //   moveCube();


    }


    public void StartMetronome()
    {
        StopCoroutine("DoTick");
        song.SetActive(true);
        CurrentStep = 1;
        var multiplier = Base / 4f;
        var tmpInterval = 60f / BPM;
        interval = tmpInterval / multiplier;
        nextTime = Time.time;
        StartCoroutine("DoTick");

    }


    public void setScoreText(int score)
    {
        String myScore = score.ToString();
        scoreText.GetComponent<TextMesh>().text = myScore;

    }


    public void setMultiplierText(int multiple)
    {
        String multiple1 = multiple.ToString();
        string newMultiple = multiple1.Insert(0, "x");
        multiplierText.GetComponent<TextMesh>().text = newMultiple;
    }




    //if conducting stops, stop music, keep game going, it's expected! TODO 
    public void gameOver()
    {
        dashboard.SetActive(true);
        Destroy(daytime);
        Destroy(sphere1);
        Destroy(sphere2);
        Destroy(sphere3);
        Destroy(sphere4);
        Destroy(line1);
        Destroy(line2);
        Destroy(line3);
        Destroy(line4);
        Destroy(song);
        Destroy(spawner);
        //restart game
        
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    bool once = false;


    void changeTempo()
    {
        StopCoroutine("DoTick");
        Invoke("changeTempoRoutine", 0.004f);

    }


    public void changeTempoRoutine()
    {
        StopCoroutine("DoTick");
        CurrentStep = 1;
        var multiplier = Base / 4f;
        var tmpInterval = 60f / 126;
        interval = tmpInterval / multiplier;
        nextTime = Time.time;
        StartCoroutine("DoTick");

    }

    IEnumerator DoTick()
    {


      

        int x = 1;

      
        for (; ; )
        {

            if(num_seconds_elapsed == 74)
            {
                changeTempo();
            }

            if (num_seconds_elapsed == 140)
            {
               // gameOver();
            }
            // Debug.Log("The score is: " + tempScore);

            //   float upper_threshold = 1.3000f;
            //    float left_threshold = -0.1000f;
            //   float right_threshold = 0.3000f;

            // returns a float of the Hand Trigger’s current state on the Oculus Touch controller
            // specified by the controller variable.
            OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);


            Vector3 position = OVRInput.GetLocalControllerPosition(controller);

        
           String direction = GetDirection(position);
            if(direction == "Up")
            {
                OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
                yield return new WaitForSeconds(0.1f);
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            }
            if(direction == "Down")
            {
                OVRInput.SetControllerVibration(0.25f, 0.25f, OVRInput.Controller.RTouch);
                yield return new WaitForSeconds(0.1f);
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

            }
            if (direction == "Left")
            {
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
                yield return new WaitForSeconds(0.1f);
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            }
            if (direction == "Right")
            {
                OVRInput.SetControllerVibration(0.75f, 0.75f, OVRInput.Controller.RTouch);
                yield return new WaitForSeconds(0.1f);
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            }



            // starts vibration on the right Touch controller
            //   OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch)

            Debug.Log("beat: " + CurrentStep);
          
            yield return CurrentStep;
            if(CurrentStep == 1)
            {
                counter1.SetActive(true);
                counter2.SetActive(false);
                counter3.SetActive(false);
                counter4.SetActive(false);

            }
            if (CurrentStep == 2)
            {
                counter1.SetActive(false);
                counter2.SetActive(true);
                counter3.SetActive(false);
                counter4.SetActive(false);

            }
            if(CurrentStep == 3)
            {
                counter1.SetActive(false);
                counter2.SetActive(false);
                counter3.SetActive(true);
                counter4.SetActive(false);
            }
            if(CurrentStep == 4)
            {
                counter1.SetActive(false);
                counter2.SetActive(false);
                counter3.SetActive(false);
                counter4.SetActive(true);
            }

            if (CurrentStep == 1 || CurrentStep == 2 || CurrentStep == 3 || CurrentStep == 4)
            {
              //  OVRInput.SetControllerVibration(0.25f, 0.25f, OVRInput.Controller.RTouch);
              //  yield return new WaitForSeconds(0.1f);
               // OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
                //  line2.GetComponent<Renderer>().material.color = Color.yellow;
                //  sphere2.GetComponent<Renderer>().material.color = Color.yellow;
            }

            if (CurrentStep == 3 || CurrentStep == 4)
            {
              //  line3.GetComponent<Renderer>().material.color = Color.yellow;
              //  sphere3.GetComponent<Renderer>().material.color = Color.yellow;
            }

          

            if (CurrentStep == 4 && sphere2.GetComponent<Renderer>().material.color == Color.red && sphere3.GetComponent<Renderer>().material.color == Color.red )
            {
                number_of_misses++;
                multiplier = 1;

                setMultiplierText(1);
                Debug.Log("it's over");
                //   failLight.GetComponent<Light>().intensity = number_of_misses; 
            }
            //  line4.GetComponent<Renderer>().material.color = Color.yellow;
            //  sphere4.GetComponent<Renderer>().material.color = Color.yellow;


           if(number_of_misses == 2)
            {
                Debug.Log("it's really over");
              //  gameOver();
            }



            if (direction == "Down" && (CurrentStep == 1 || CurrentStep == 2 || CurrentStep == 3))
            {
                Debug.Log("Down, Sequence is " + sequence);
                line1.GetComponent<Renderer>().material.color = Color.green;
                sphere1.GetComponent<Renderer>().material.color = Color.green;
                sequence++;
                internal_score = internal_score + (10 * multiplier);
                setScoreText(internal_score);

            }
            if (direction == "Left" && sequence == 1)
            {
                Debug.Log("Left, Sequence is " + sequence);
                line2.GetComponent<Renderer>().material.color = Color.green;
                sphere2.GetComponent<Renderer>().material.color = Color.green;
                sequence++;
                internal_score = internal_score + (10 * multiplier);
                setScoreText(internal_score);
            }
            if (direction == "Right" && sequence == 2)
            {
                Debug.Log("Right, Sequence is " + sequence);
                line3.GetComponent<Renderer>().material.color = Color.green;
                sphere3.GetComponent<Renderer>().material.color = Color.green;
                right = true;
                sequence++;
                if(multiplier <8)
                {
                    multiplier *= 2;
                    setMultiplierText(multiplier);
                }
                internal_score = internal_score + (10 * multiplier);

                setScoreText(internal_score);
            }
            if (direction == "Up")
            {
                Debug.Log("Up, Sequence is " + sequence);
                line4.GetComponent<Renderer>().material.color = Color.green;
                sphere4.GetComponent<Renderer>().material.color = Color.green;
                sequence = 0;
                right = false;
                internal_score = internal_score + (10 * multiplier);
                setScoreText(internal_score);
            }


            if (CurrentStep == 1 && OnNewMeasure != null)
                OnNewMeasure(this);

            if (direction == "Up")
            {
                Debug.Log("Up, Sequence is " + sequence);
                line4.GetComponent<Renderer>().material.color = Color.green;
                sphere4.GetComponent<Renderer>().material.color = Color.green;
                sequence = 0;
                right = false;
            }
            if (OnTick != null)
                OnTick(this);

            if (direction == "Up")
            {
                Debug.Log("Up, Sequence is " + sequence);
                line4.GetComponent<Renderer>().material.color = Color.green;
                sphere4.GetComponent<Renderer>().material.color = Color.green;
                sequence = 0;
                right = false;
            }
            nextTime += interval;

            yield return new WaitForSeconds(nextTime - Time.time);

            if (direction == "Up")
            {
                Debug.Log("Up, Sequence is " + sequence);
                line4.GetComponent<Renderer>().material.color = Color.green;
                sphere4.GetComponent<Renderer>().material.color = Color.green;
                sequence = 0;
                right = false;
            }
            CurrentStep++;
            
            if (CurrentStep > Step)
            {
                line1.GetComponent<Renderer>().material.color = Color.red;
                line2.GetComponent<Renderer>().material.color = Color.red;
                line3.GetComponent<Renderer>().material.color = Color.red;
                line4.GetComponent<Renderer>().material.color = Color.red;
                sphere1.GetComponent<Renderer>().material.color = Color.red;
                sphere2.GetComponent<Renderer>().material.color = Color.red;
                sphere3.GetComponent<Renderer>().material.color = Color.red;
                sphere4.GetComponent<Renderer>().material.color = Color.red;
                CurrentStep = 1;
                CurrentMeasure++;
                sequence = 0;
            }


         
        }
    }


    public string GetDirection(Vector3 input)
    {


       
  
     //if you stop, it keeps going, continues where you left off TODO

        Vector3 leftPoint = new Vector3((float)-0.056, (float)1.086, (float)0.493);
        Vector3 rightPoint = new Vector3((float)0.292, (float)1.086, (float)0.422);
        Vector3 upPoint = new Vector3((float)0.131, (float)1.25, (float)0.493);
        Vector3 downPoint = new Vector3((float)0.128, (float)0.887, (float)0.493);
     //   Vector3 centerPoint = new Vector3((float)0.2, (float)1.0, (float).3);

        float distanceToLeft = Vector3.Distance(leftPoint, input);
        float distanceToRight = Vector3.Distance(rightPoint, input);
        float distanceToUp = Vector3.Distance(upPoint, input);
        float distanceToDown = Vector3.Distance(downPoint, input);
        //  float distanceToCenter = Vector3.Distance(centerPoint, input);



        //&& distanceToLeft < distanceToCenter
        if (distanceToLeft < distanceToRight && distanceToLeft < distanceToUp && distanceToLeft < distanceToDown )
        {
            Debug.Log("Left");
            return "Left";
        }
        else if(distanceToRight < distanceToLeft && distanceToRight < distanceToUp && distanceToRight < distanceToDown )
        {
            Debug.Log("Right");
            return "Right";
        }
        else if(distanceToUp < distanceToRight && distanceToUp < distanceToLeft && distanceToUp < distanceToDown)
        {
            Debug.Log("Up");
            return "Up";
        }
        else if(distanceToDown < distanceToRight && distanceToDown < distanceToLeft && distanceToDown < distanceToUp)
        {
            Debug.Log("Down");
            return "Down";
        }
        //   else if(distanceToCenter < distanceToRight && distanceToCenter < distanceToUp && distanceToCenter < distanceToDown && distanceToCenter < distanceToLeft)
        //  {
        //      Debug.Log("Center");
        //  }


        return "Center"; 

    }


}
