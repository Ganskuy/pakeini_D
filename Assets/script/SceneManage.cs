using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void toScene2(){
        SceneManager.LoadScene("lari");
    }
    public void toMainMenu(){
        SceneManager.LoadScene("mainmenu");
    }
}
