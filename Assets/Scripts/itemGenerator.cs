using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemGenerator : MonoBehaviour{

    public static ItemGenerator Instance;
    //Prefab of item
    [SerializeField] private GameObject item;

    private void Awake(){
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void generateItem(float x, float y, float z) {
        Instantiate(item, new Vector3(x, y, z), Quaternion.identity);
    }

}
