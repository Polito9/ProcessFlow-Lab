using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestCount : MonoBehaviour
{
    [SerializeField] TextMeshPro tmp;
    private int count = 0;

    private void Start() {
        CounterManager.Instance.CreateNewCounter(tmp);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Item") {
            count++;
            CounterManager.Instance.UpdateCounter(tmp, count);
            Destroy(collision.gameObject);
        }
    }
}
