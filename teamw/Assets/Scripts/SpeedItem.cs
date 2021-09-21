using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    void Update() {
        // ワールドのy軸に沿って1秒間に90度回転
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime, Space.World);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}
