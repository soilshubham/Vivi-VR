using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trivia : MonoBehaviour
{

    public void mainMenuButton()
    {
        SceneManager.LoadSceneAsync("home");
    }
}
