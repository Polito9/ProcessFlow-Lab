using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    private Rigidbody rb;
    [SerializeField] private float forceX;
    void Start(){
           rb = GetComponent<Rigidbody>();
    }
    void Update(){

        rb.AddForce(new Vector3(forceX,0,0));
    }
}
