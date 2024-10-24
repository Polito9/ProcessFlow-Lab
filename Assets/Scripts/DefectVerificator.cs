using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    [SerializeField] double probability_defect = 0.5;

    //For the timer
    private double timer;
    private double waitTime = 0;

    
    Queue<double> queue = new Queue<double>();
    int objects_verificating = 0;

    private void Update() {
        if(TimerManager.Instance != null) {
            timer = TimerManager.Instance.getActualTime();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Item") {
            randNum = rnd.NextDouble();
            time_to_process = normal_dist.InverseCumulativeDistribution(randNum);
            Debug.Log("An item arrived to verification: "+randNum);
            queue.Enqueue(time_to_process);
            Destroy(collision.gameObject);
            objects_verificating++;
            Debug.Log(time_to_process);
        }
    }
}
