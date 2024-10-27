using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterManager : MonoBehaviour{

    public static CounterManager Instance;

    private Dictionary<TextMeshPro, int> counters = new Dictionary<TextMeshPro, int>();
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void CreateNewCounter(TextMeshPro tmp) {
        if (!counters.ContainsKey(tmp)) {
            Debug.Log("A new counter has been generated");
            counters[tmp] = 0;
        }
    }

    public void UpdateCounter(TextMeshPro tmp, int new_val) {
        
        counters[tmp] = new_val;
        
        if(tmp != null) {
            Debug.Log("The text has been updated");
            tmp.text = counters[tmp].ToString();
        }

    }

}
