using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject trivia;
    public GameObject latest_updates;
    public GameObject liveData;

    private void Start()
    {
        trivia.SetActive(false);
        latest_updates.SetActive(false);
        liveData.SetActive(false);
    }
    public void startButton()
    {
        StartCoroutine(levelSelcet());
    }
    
    IEnumerator levelSelcet()
    {

        latest_updates.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        trivia.SetActive(true);

    }

    public void updateButton()
    {
        liveData.SetActive(true);
    }

    public void liveUpdateBackButton()
    {
        liveData.SetActive(false);
    }

    public void triviaButton()
    {
        SceneManager.LoadSceneAsync("trivia");
    }
}
