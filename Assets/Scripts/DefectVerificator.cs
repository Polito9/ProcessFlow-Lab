using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using MathNet.Numerics.Distributions;

public class DefectVerificator : MonoBehaviour
{
    //To generate the random values in using the normal distribution
    private System.Random rnd = new System.Random();
    private InverseGaussian inverse = new InverseGaussian(5, 1);    
    private double randNum;

    //Probability that the item has a defect
    [SerializeField] double probability_defect = 0.5;

    //For the timer
    private double timer;
    private double waitTime = 0;

    int objects_verificating = 0;

    private void Update() {
        if(TimerManager.Instance != null) {
            timer = TimerManager.Instance.getActualTime();
        }
    }

    private void OnCollisionEnter(Collision collision) {

        Debug.Log("My rand is: "+randNum);
        if (collision.gameObject.tag == "Item") {
            Debug.Log("An item arrived to verification");
            Destroy(collision.gameObject);
            objects_verificating++;

        }
    }

}
