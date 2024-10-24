using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour{

    public static TimerManager Instance;
    private double timer = 0;

    private void Awake() {
        
        // Only one instance of TimerManager exist
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Update(){
        timer += Time.deltaTime;
    }

    public double getActualTime() {
        return timer;
    }
}
