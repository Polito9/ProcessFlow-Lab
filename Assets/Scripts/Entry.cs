using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Entry : MonoBehaviour {

    //For the random system
    private System.Random rnd = new System.Random();
    private double num;
    [SerializeField] private double arrival_average;
    private double lambda;

    //Transform of the generator
    private Transform my_transform;

    //For the timer
    private double timer;
    private double waitTime = 0;


    void generateNextTime() {
        num = rnd.NextDouble();
        waitTime += (-Math.Log(1 - num) / lambda);
    }

    void Start() {
        my_transform = GetComponent<Transform>();

        //Generating the first arrival
        lambda = 1 / arrival_average;
        generateNextTime();
        //Debug.Log("Item appeared at: " + waitTime);
    }


    void Update() {
        if (TimerManager.Instance != null) {
            //The instance exists
            timer = TimerManager.Instance.getActualTime();
        }
        if (waitTime < timer) {
            //This means the item can appear
            ItemGenerator.Instance.generateItem(my_transform.position.x, my_transform.position.y - 1, my_transform.position.z);
            //Debug.Log("Item appeared at: " + waitTime);
            generateNextTime();
        }
    }
}
