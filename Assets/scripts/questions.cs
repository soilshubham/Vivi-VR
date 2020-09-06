using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class questions : MonoBehaviour
{
    public string[] question;
    public string[] answer;

    int totQuestions;

    public Text QuestionBoard;
    public Text score;
    public Text total_points;
    public GameObject promptCorrect;
    public GameObject promptWrong;

    private static int prevQuestion;
    private static int currentQuestion;
    private static int currentScore = 0;
    private static int totalPoints = 0;


    private void Start()
    {
        promptCorrect.SetActive(false);promptWrong.SetActive(false);
        totQuestions = question.Length;

        prevQuestion = -1;
        totalPoints = PlayerPrefs.GetInt("totalPoints", 0);
        showQuestion();
        showScore();
        currentScore = 0;
        score.text = currentScore.ToString();
        total_points.text = totalPoints.ToString();
    }

    public void showQuestion()
    {
        currentQuestion = Random.Range(0, totQuestions);
        while (currentQuestion == prevQuestion)
        {
            currentQuestion = Random.Range(0, totQuestions);
        }
        prevQuestion = currentQuestion;
        
        QuestionBoard.text = question[currentQuestion];
    }

    public void checkAnswer(string a)
    {
        if(a.ToLower() == answer[currentQuestion].ToLower())
        {

            currentScore++;
            totalPoints++;
            PlayerPrefs.SetInt("totalPoints", totalPoints);

            
            promptCorrect.SetActive(false); promptWrong.SetActive(false);
            promptCorrect.SetActive(true); promptWrong.SetActive(false);
            //promptCorrect.GetComponentInParent<Animator>().Play("prompt messages");
        }
        else
        {
            promptCorrect.SetActive(false); promptWrong.SetActive(false);
            promptCorrect.SetActive(false); promptWrong.SetActive(true);
            //promptWrong.GetComponentInParent<Animator>().Play("prompt messages");
        }
    }

    public void optYes()
    {
        checkAnswer("yes");
        showQuestion();
        showScore();
    }
    public void optNo()
    {
        checkAnswer("no");
        showQuestion();
        showScore();
    }
    public void showScore()
    {
        score.text = currentScore.ToString();
        total_points.text = PlayerPrefs.GetInt("totalPoints", 0).ToString();
    }
}
