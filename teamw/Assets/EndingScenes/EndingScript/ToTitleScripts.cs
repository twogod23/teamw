using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleScripts : MonoBehaviour
{
    //ボタンが押されたときに呼び出される関数
    public void Select()
    {
        //行われる操作 メインメニュー画面へ移動
        SceneManager.LoadScene("Mainmenu");
    }
}
