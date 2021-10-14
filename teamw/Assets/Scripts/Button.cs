using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
/// <summary>
/// ボタン共通クラス
/// </summary>
public class Button : MonoBehaviour
{
    //ボタンタップで呼ばれるメソッド
    public void TappedButton()
    {
        SeManager seManager = SeManager.Instance;
        seManager.SettingPlaySE();
        SceneManager.LoadScene("Mainmenu");
    }
}