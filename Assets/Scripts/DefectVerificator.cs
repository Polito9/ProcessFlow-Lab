using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using MathNet.Numerics.Distributions;


public class DefectVerificator : MonoBehaviour
{
    //To generate the random values in using the normal distribution
    private System.Random rnd = new System.Random();
    private Normal normal_dist = new Normal(5, 1);
    private double randNum;
    private double time_to_process;


    //Probability that the item has a defect
    [SerializeField] double probability_defect = 0.4;

    //For the timer
    private double timer;
    private double waitTime = 0;


    //To manage the objects in queue
    bool is_ready = true; //Bool to check if the machine is ready to process an object
    Queue<double> queue = new Queue<double>();
    int objects_verificating = 0;
    double actual_process_time; //Axiliar to save the time the objet will take to verify

    private void Update() {
        if(TimerManager.Instance != null) {
            timer = TimerManager.Instance.getActualTime();
            //Debug.Log("The timer from verificator is: "+timer);
        }

        //Verifying if the object can be processed and there are objects to be processed
        if (is_ready && queue.Count > 0) {
            is_ready = false;
            actual_process_time = queue.Dequeue();
            waitTime = timer + actual_process_time;
            Debug.Log("An item is being verified and it will take: " + actual_process_time);
        }

        if (waitTime < timer && !is_ready) {
            //The object has finished from being verified
            Debug.Log("The item has been verified in: "+timer);
            objects_verificating--;
            is_ready = true;
              
            randNum = rnd.NextDouble();
            if(randNum <= probability_defect) {
                //It has a defect

            }
            else {
                //It does not have a defect

            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Item") {
            //Generating the time the object will take to process
            randNum = rnd.NextDouble();
            time_to_process = normal_dist.InverseCumulativeDistribution(randNum);
            Debug.Log("An item arrived to verification");
            
            //Added the object time to the queue
            queue.Enqueue(time_to_process);
            objects_verificating++;

            //Deleting the object from the scene
            Destroy(collision.gameObject);
        }
    }
}
