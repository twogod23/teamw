using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour {


    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Player") {
        SceneManager.LoadScene("sub2");
        Debug.Log("OnTrigger");
        }
    }
}