using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MethodButtonScript : MonoBehaviour
{
    //ボタンが押されたときに呼び出される関数
    public void Select()
    {
        //行われる操作 操作方法へ移動
        SceneManager.LoadScene("Method");
    }
}
