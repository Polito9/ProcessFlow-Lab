using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

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
    private Transform my_transform;
    void generateNextTime(){
        num = rnd.NextDouble();
        waitTime += (-Math.Log(1 - num) / lambda);
    }

    void Start() {
        my_transform = GetComponent<Transform>();

        lambda = 1 / arrival_average;
        generateNextTime();
        Debug.Log("Item appeared at: " + waitTime);
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        if (waitTime < timer){
            Instantiate(item, new Vector3(my_transform.position.x, my_transform.position.y-1, my_transform.position.z), Quaternion.identity);
            itemsArrived.Enqueue(waitTime);
            Debug.Log("Item appeared at: " + waitTime);
            generateNextTime();
        }
    }
}
