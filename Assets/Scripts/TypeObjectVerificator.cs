using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TypeObjectVerificator : MonoBehaviour
{
    //THIS SCRIPT WITH THE DEFECTVERIFICATOR.CS NEEDS TO MERGE IN ONE AND USE A CLASS TO GENERATE DISTRIBUTIONS

    //For the Uniform Distribution and random system
    [SerializeField] private double a;
    [SerializeField] private double b;
    private System.Random rnd = new System.Random();
    private double num;

    //For the timer
    private double timer = 0;
    private double waitTime = 0;

    //The textMeshPro to show the counter
    [SerializeField] private TextMeshPro tmp;

    //The queue in the verificator
    Queue<double> queue = new Queue<double>();
    bool is_ready = true; //Bool to check if the machine is ready to process an object
    int objects_verificating = 0;

    //Probability of the type of defect
    [SerializeField] double probability_defect_A = 0.2;
    [SerializeField] double probability_defect_B = 0.3;
    [SerializeField] double probability_defect_C = 0.5;

    private void Start() {
        CounterManager.Instance.CreateNewCounter(tmp);
    }

    void Update()
    {
        if(TimerManager.Instance != null) {
            timer = TimerManager.Instance.getActualTime();
        }

        //Verifying if the object can be processed and there are objects to be processed
        if (is_ready && queue.Count > 0) {
            is_ready = false;
            waitTime = timer + queue.Dequeue();
            Debug.Log("An item is being verified and it will be ready at time: " + waitTime);
        }

        //Checking if there is an object being verifiend and it has finished
        if (waitTime < timer && !is_ready) {
            //The object has finished from being verified

            is_ready = true;

            //Update the counter
            objects_verificating--;
            CounterManager.Instance.UpdateCounter(tmp, objects_verificating);

            num = rnd.NextDouble();
            if (num <= probability_defect_A) {
                //It has a defect
                Debug.Log("The object has defect A");
            }
            else if (num <= (probability_defect_A + probability_defect_B)) {
                //It does not have a defect
                Debug.Log("The object has a defect B");
            }
            else {
                Debug.Log("The object has a defect C");
            }
        }
    }


    double generateNextUniform(double rand) {
        return (rand * (b - a) + a);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Item") {
            //Generating the time the object will take to process
            num = generateNextUniform(rnd.NextDouble());
            //Added the object time to the queue
            queue.Enqueue(num);

            //Update the counter
            objects_verificating++;
            CounterManager.Instance.UpdateCounter(tmp, objects_verificating);

            //Deleting the object from the scene
            Destroy(collision.gameObject);
        }
    }
}
