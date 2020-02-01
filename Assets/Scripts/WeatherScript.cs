using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherScript : MonoBehaviour
{
    const string apiKey = "3ad661ef210e74f92c76d79e4d7568ea";
    const string url = "http://api.openweathermap.org/data/2.5/weather?q=";
    private string city = "Penryn";
    [SerializeField] private ParticleSystem rainParticles = null;

    private void Start()
    {
        StartCoroutine(GetWeather());
    }

    IEnumerator GetWeather()
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(url + city + "&APPID=" + apiKey))
        {
            yield return uwr.SendWebRequest();
            string jsonText = uwr.downloadHandler.text;
            RootObject weather = JsonUtility.FromJson<RootObject>(jsonText);
            Debug.LogFormat("Description: {0}, Cloud Coverage: {1}%, Humidity: {2}%", weather.weather[0].description, weather.clouds.all, weather.main.humidity);
            var rainOverTime = rainParticles.emission;
            rainOverTime.rateOverTime = weather.main.humidity / 2;
        }
    }
}

[System.Serializable]
public class Weather
{
    public int id;
    public string main;
    public string description;
    public string icon;
}

[System.Serializable]
public class Main
{
    public double temp;
    public double feels_like;
    public double temp_min;
    public double temp_max;
    public int pressure;
    public int humidity;
}

[System.Serializable]
public class Wind
{
    public double speed;
    public int deg;
}

[System.Serializable]
public class Clouds
{
    public int all;
}

[System.Serializable]
public class RootObject
{
    public List<Weather> weather;
    public Main main;
    public Wind wind;
    public Clouds clouds;
}
