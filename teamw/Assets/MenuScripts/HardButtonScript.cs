using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardButtonScript : MonoBehaviour
{
    //ボタンが押されたときに呼び出される関数
    public void Select()
    {
        Debug.Log("hard");
        //行われる操作 ゲームシーン(hard)へ移動
        SceneManager.LoadScene("Game Scene hard");
    }
}
