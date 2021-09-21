using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtonAppearsScript : MonoBehaviour
{
    private float timeappear = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        TitleButton.SetActive(false);
    }

    public GameObject TitleButton;

    
    // Update is called once per frame
    void Update()
    {
       //フレームによる時間を追加
       timeappear += Time.deltaTime;

       //時間が一定数超えると、ボタンが現れる
       if(timeappear > 5.0f)
       {
           TitleButton.SetActive(true);
       } 
    }
}
