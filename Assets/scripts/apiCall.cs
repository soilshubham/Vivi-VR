using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class apiCall : MonoBehaviour
{

    public Text totalCasesText;
    public Text dailyCasesText;
    public Text totalDiedText;
    public Text dailyDiedText;
    public Text totalRecoveredText;
    public Text dailyRecoveredText;
    public Text dateText;


    const string ENDPOINT = "https://api.covid19india.org/data.json";
    private string totatlCases;
    private string dailyCases;
    private string totalDied;
    private string dailyDied;
    private string totalRecovered;
    private string dailyRecovered;
    private string date;
    public void GetTimeData()
    {
        StartCoroutine(GetTimeDataRoutine());
    }

    IEnumerator GetTimeDataRoutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(ENDPOINT);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log("Network Error");
        }
        else
        {
            JSONNode data = JSON.Parse(request.downloadHandler.text);
            

            date = data["cases_time_series"][data["cases_time_series"].Count-1]["date"];

            totatlCases = data["cases_time_series"][data["cases_time_series"].Count - 1]["totalconfirmed"];
            dailyCases = data["cases_time_series"][data["cases_time_series"].Count - 1]["dailyconfirmed"];

            totalRecovered = data["cases_time_series"][data["cases_time_series"].Count - 1]["totalrecovered"];
            dailyRecovered = data["cases_time_series"][data["cases_time_series"].Count - 1]["dailyrecovered"];

            totalDied = data["cases_time_series"][data["cases_time_series"].Count - 1]["totaldeceased"];
            dailyDied = data["cases_time_series"][data["cases_time_series"].Count - 1]["dailydeceased"];

            displayData();

            Debug.Log("No error");
        }
    }

    public void displayData()
    {
        totalCasesText.text = totatlCases;
        dailyCasesText.text = "+" + dailyCases;

        totalDiedText.text = totalDied;
        dailyDiedText.text = "+" + dailyDied;

        totalRecoveredText.text = totalRecovered;
        dailyRecoveredText.text = "+" + dailyRecovered;

        dateText.text = date.ToUpper();
        
    }

    void Start()
    {
        GetTimeData();
        
    }

}

