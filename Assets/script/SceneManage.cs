using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // Method to load Scene 2 (named "lari" in your project)
    public void toScene2(){
        SceneManager.LoadScene("lari");
    }

    // Method to load the Main Menu scene (named "mainmenu" in your project)
    public void toMainMenu(){
        SceneManager.LoadScene("mainmenu");
    }

    // Method to quit the game
    public void QuitGame(){
        // Log a message when the quit function is called
        Debug.Log("QuitGame called - the application will quit.");

        #if UNITY_EDITOR
            // Log that we're stopping play mode in the editor
            Debug.Log("Stopping play mode in the Unity editor.");
            // Stop play mode in the Unity editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Log that we're quitting the application in a build
            Debug.Log("Quitting the application.");
            // Quit the application
            Application.Quit();
        #endif
    }
}