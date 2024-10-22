using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemGenerator : MonoBehaviour{
    // Start is called before the first frame update    
    private System.Random rnd = new System.Random();
    private double num;
    [SerializeField] private double arrival_average;
    private double lambda;
    private double waitTime = 0;

    private double timer = 0;

    //The queue to save the data generated each interaction
    private Queue<double> queue = new Queue<double>();

    void generateNextTime(){
        num = rnd.NextDouble();
        waitTime += (-Math.Log(1 - num) / lambda);
    }

    void Start() {
        lambda = 1 / arrival_average;
        generateNextTime();
        Debug.Log("First time at: " + waitTime);
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        if (waitTime < timer){
            queue.Enqueue(waitTime);
            Debug.Log("Item arrived at: " + waitTime);
            generateNextTime();
        }
    }
}
