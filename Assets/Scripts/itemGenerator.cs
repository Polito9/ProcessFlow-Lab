using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemGenerator : MonoBehaviour{
      
    private System.Random rnd = new System.Random();
    private double num;
    [SerializeField] private double arrival_average;
    private double lambda;
    private double waitTime = 0;

    private double timer = 0;

    //The queue to save the data generated each interaction
    private Queue<double> itemsArrived = new Queue<double>();

    //Prefab of item
    [SerializeField] private GameObject item;
    [SerializeField] private float xAppear;
    [SerializeField] private float yAppear;
    [SerializeField] private float zAppear;

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
            Instantiate(item, new Vector3(xAppear, yAppear, zAppear), Quaternion.identity);
            itemsArrived.Enqueue(waitTime);
            Debug.Log("Item arrived at: " + waitTime);
            generateNextTime();
        }
    }
}
