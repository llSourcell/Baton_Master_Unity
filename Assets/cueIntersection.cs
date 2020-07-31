using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cueIntersection : MonoBehaviour
{
    [SerializeField] public GameObject scoreText;

    public LayerMask layer;
    private Vector3 previousPos;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            Debug.Log("Onestep!!!!");
            // if (Vector3.Angle(transform.position-previousPos, hit.transform.up)>130)
            //  {
            String score = scoreText.GetComponent<TextMesh>().text;
            setScoreText(score);

     
            Destroy(hit.transform.gameObject);
            //  }
        }

        previousPos = transform.position;

    }


    public void setScoreText(String score)
    {
        
        int score_num = Int32.Parse(score);
        score_num += 10;
        String final_score = score_num.ToString();
        scoreText.GetComponent<TextMesh>().text = final_score;

    }


}