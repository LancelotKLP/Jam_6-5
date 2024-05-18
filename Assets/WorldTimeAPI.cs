using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.Networking;

public class WorldTimeAPI : MonoBehaviour
{
    #region Singleton class: WorldTimeAPI

    public static WorldTimeAPI Instance;

    void Awake () {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad (this.gameObject);
        } else {
            Destroy (this.gameObject);
        }
    }
    #endregion

    struct TimeData {
        public string datetime;
    }

    const string API_URL = "http://worldtimeapi.org/api/timezone/Europe/Paris";
    [HideInInspector] public bool isTimeLoaded = false;
    private DateTime _currentDateTime = DateTime.Now;

    void Start () {
        StartCoroutine (GetRealDateTimeForAPI());
    }

    public DateTime GetCurrentDateTime () {
        return _currentDateTime.AddSeconds (Time.realtimeSinceStartup);
    }

    IEnumerator GetRealDateTimeForAPI () {
        UnityWebRequest webRequest = UnityWebRequest.Get (API_URL);
        Debug.Log("getting real datetime...");
        yield return webRequest.SendWebRequest();
        if (webRequest.error != null) {
            Debug.Log ("Error:" + webRequest.error);
        } else {
            TimeData timeData = JsonUtility.FromJson<TimeData> ( webRequest.downloadHandler.text );

            _currentDateTime = ParseDateTime ( timeData.datetime );
            isTimeLoaded = true;

            Debug.Log("Success.");
        }
    }

    DateTime ParseDateTime(string datetime) {
        string date = Regex.Match(datetime, @"^\d{4}-\d{2}-\d{2}").Value;
        string time = Regex.Match(datetime, @"\d{2}:\d{2}:\d{2}").Value;

        return DateTime.Parse (string.Format ("{0} {1}", date, time));
    }

    /* API (Json)
    {
        "abbreviation": "CEST",
        "client_ip": "163.5.2.51",
        "datetime": "2024-05-18T11:17:40.390820+02:00",
        "day_of_week": 6,
        "day_of_year": 139,
        "dst": true,
        "dst_from": "2024-03-31T01:00:00+00:00",
        "dst_offset": 3600,
        "dst_until": "2024-10-27T01:00:00+00:00",
        "raw_offset": 3600,
        "timezone": "Europe/Paris",
        "unixtime": 1716023860,
        "utc_datetime": "2024-05-18T09:17:40.390820+00:00",
        "utc_offset": "+02:00",
        "week_number": 20
    }
    */
}
