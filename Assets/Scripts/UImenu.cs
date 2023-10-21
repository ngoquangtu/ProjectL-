using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImenu : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit(); 
    }
}
