using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject bowler;
    public float speed;


  
    public GameObject ball;
    public float ballSpeed;


    private int Runs;
    private Vector2 direction;
    private Vector2 fielderPosition;

    public static float Score;
    public Text scoreText;

    void Start()
    {
        //bowler and ball initial position
        //-2.67f ball initial and bowler final position
        //2.24 finall ball position
        bowler.transform.position = new Vector2(-5f, -0.33f);
        ball.transform.position = new Vector2(-2.67f, -0.33f);
    }


    void Update()
    {
        //movement
        if (bowler.transform.position.x <= -2.67f)
        {
            bowler.transform.position = new Vector2(bowler.transform.position.x + speed * Time.deltaTime, -0.33f);
        }
        else
        {
            ball.SetActive(true);
        }

        //ball movement
        if (ball.activeInHierarchy && ball.transform.position.x <= 2.24f&& ball.CompareTag("Ball"))
        {
            ball.transform.position = new Vector2(ball.transform.position.x + ballSpeed * Time.deltaTime, ball.transform.position.y + 0.4f * Time.deltaTime);
        }
        else if (ball.CompareTag("Ball")&&ball.transform.position.x>2.24f) 
        {
            //runs
            int temp = Random.Range(1, 6);
            switch(temp)
            {
                case 1:
                    {
                        Runs = 0;
                        break;
                    }
                case 2:
                    {
                        Runs = 1;
                        break;
                    }
                case 3:
                    {
                        Runs = 2;
                        break;
                    }
                case 4:
                    {
                        Runs = 4;
                        break;
                    }
                case 5:
                    {
                        Runs = 6;
                        break;
                    }
            }
            Debug.Log(Runs);

            Score += Runs;
            scoreText.text = "Score: " + Score.ToString();
            

              fielderPosition = ballDecision(Runs);
           direction = new Vector2(fielderPosition.x- 2.24f,fielderPosition.y-0);
            ball.tag = "ballHit";
        }
        if(ball.CompareTag("ballHit"))
        {
            if(ball.transform.position.x>=fielderPosition.x&& ball.transform.position.y!=fielderPosition.y)
            {
                ball.transform.position = new Vector2(ball.transform.position.x + direction.x*Time.deltaTime, ball.transform.position.y + direction.y*Time.deltaTime);
            }
          
        }

    }

    public Vector2 ballDecision(int scenario)
    {
        Vector2 temp = new Vector2(0, 0);
        switch(scenario)
        {
            case 0:
                {
                    temp = new Vector2(-2, -1);
                    break;
                }
            case 1:
                {
                    temp = new Vector2(-0.18f, 3);
                    break;
                }
            case 2:
                {
                    temp = new Vector2(-0.36f, -3);
                    break;
                }
            case 4:
                {
                    temp = new Vector2(-10, -2.32f);
                    break;
                }
            case 6:
                {
                    temp = new Vector2(-12, 1.34f);
                    break;
                }
        }
        return temp;
    }



}
