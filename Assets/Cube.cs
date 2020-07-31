using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public float period = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position -= Time.deltaTime * transform.forward * 2;
        //Debug.Log("The time is " + Time.deltaTime);

      //   if (period > 1)
      //    {
        //Do Stuff
        //change to up. 
          transform.position -= Time.deltaTime * transform.forward * 2;
           
        //     Debug.Log("sec");
      //       period = 0;
      //    }
       //   period += UnityEngine.Time.deltaTime;
    }
}
