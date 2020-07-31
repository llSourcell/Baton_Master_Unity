
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Timers;

public class spawner : MonoBehaviour
{


    //crescendo indicator
    [SerializeField] private GameObject crescendo_indicator;


    //timer vars
    private static System.Timers.Timer aTimer;

 
    public GameObject cube1;
    public GameObject cube2;
    public Transform point;
    public float beat = (60/130) *2;
    private float timer;
    private double num_seconds_elapsed = 0;
    private bool onetime = false;
    private bool onetime1 = false;
    private bool onetime2 = false;
    private bool onetime3 = false;
    private bool onetime4 = false;
    private bool onetime5 = false;
    private bool onetime6 = false;
    private bool onetime7 = false;



    private float y_val = -0.1f;
    // Start is called before the first frame update
    void Start()
    {
        crescendo_indicator.SetActive(false);
        Timer timer = new Timer(1000);
        timer.Elapsed += OnTick; // Which can also be written as += new ElapsedEventHandler(OnTick);
        timer.Start();
        
    }

    private void OnTick(object source, ElapsedEventArgs e)
    {
      
        num_seconds_elapsed++;
        Debug.Log("tick " + num_seconds_elapsed);
      
         //   moveCube();
            
        
    }
    

    // Update is called once per frame
    void Update()
    {

       




        //Cue 1
        if (num_seconds_elapsed == 4)
        {



            //y_val += 0.0007f;
           // Debug.Log(y_val);
           // createCrescendo(y_val);
            // y_val += 0.01f;
            //  createCrescendo(y_val);
            if (!onetime1)
           {
               Debug.Log("Cue 1!");
               createCube();
              onetime1 = true;
           }

        }


  

        //cue 2
        if (num_seconds_elapsed == 31)
        {
            if (!onetime2)
            {
                createCube();
                onetime2 = true;
            }

        }

        //cue 3
        if (num_seconds_elapsed == 53)
        {
            if (!onetime3)
            {
                createCube();
                onetime3 = true;
            }

        }
       


        //Crescendo 1
        if (
           num_seconds_elapsed == 59 || num_seconds_elapsed == 60 || num_seconds_elapsed == 61 ||  num_seconds_elapsed == 62 || 
            num_seconds_elapsed == 63 || num_seconds_elapsed == 64 || num_seconds_elapsed == 65 || 
            num_seconds_elapsed == 66 || num_seconds_elapsed == 67 || num_seconds_elapsed == 68
            || num_seconds_elapsed == 69 || num_seconds_elapsed == 70|| num_seconds_elapsed == 71 || num_seconds_elapsed == 72 || num_seconds_elapsed == 73)
        {
           
            crescendo_indicator.SetActive(true);
        }

        if(num_seconds_elapsed == 74)
        {
            crescendo_indicator.SetActive(false);
        }

     

      //86 double hands starts

        //crescendo 3
        if (num_seconds_elapsed == 118)
        {
            if (!onetime4)
            {
                createCube();
                onetime4 = true;
            }

        }

        //crescendo 3
        if (num_seconds_elapsed == 124)
        {
            if (!onetime5)
            {
                createCube();
                onetime5 = true;
            }

        }

        if(num_seconds_elapsed == 140 || num_seconds_elapsed == 141 || num_seconds_elapsed == 142 || num_seconds_elapsed == 143)
        {
            crescendo_indicator.SetActive(true);
        }

        if(num_seconds_elapsed == 144)
        {
            crescendo_indicator.SetActive(false);
        }


        //crescendo 3
        if (num_seconds_elapsed == 145)
        {
            if (!onetime6)
            {
                createCube();
                onetime6 = true;
            }

        }


     


        timer += Time.deltaTime;




    }

  

    void createCube()
    {
        GameObject cube = Instantiate(cube1, point);
        cube.transform.localPosition = Vector3.zero;
       // num_seconds_elapsed = 0;
        // cube.transform.Rotate(transform.forward, 90 );
        //  timer -= beat;
    }
 
    void createCrescendo(float y_val)
    {
       
       
        GameObject cube = Instantiate(cube2, point);
     
        cube.transform.localPosition = new Vector3(0f, y_val, 0f);
        
        //num_seconds_elapsed = 0;
        //   cube.transform.Rotate(transform.forward, 90 );
        //  timer -= beat;

    }
}
