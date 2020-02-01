using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Weather : MonoBehaviour
{
    const string apiKey = "3ad661ef210e74f92c76d79e4d7568ea";
    const string url = "http://api.openweathermap.org/data/2.5/weather?q=";
    private string city = "Falmouth";
    
    public enum WeatherStat
    {
        Sun,
        Clouds,
        Rain,
        Storm
    }
    
    private void Start()
    {
        StartCoroutine(GetWeather());
    }

    IEnumerator GetWeather()
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(url + city + "&APPID=" + apiKey))
        {
            yield return uwr.SendWebRequest();

            Debug.Log(uwr.downloadHandler.text);
        }
    }
}
