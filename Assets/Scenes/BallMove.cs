using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private float ballSpeed;
    
    public GameObject baller;

    // Start is called before the first frame update
    void Start()
    {
        ball.transform.position = new Vector2(-2.67f, -0.33f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
