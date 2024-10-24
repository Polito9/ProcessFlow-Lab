using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//using MathNet.Numerics.Distributions;

public class DefectVerificator : MonoBehaviour
{
    private System.Random rnd = new System.Random();

  //  private InverseGaussian inverse = new InverseGaussian(5, 1);    

    private double randNum;
    void Start()
    {
    //    randNum = inverse.Sample();
        //Debug.Log(randNum);
    }

    private void OnCollisionEnter(Collision collision) {
      //  randNum = inverse.Sample();
        Debug.Log(randNum);
        if (collision.gameObject.tag == "Item") {
            Debug.Log("An item arrived to verification");
        }
    }

}
