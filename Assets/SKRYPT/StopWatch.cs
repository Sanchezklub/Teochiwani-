using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{   
    public float timer;
    public float seconds;
    public float minutes;
    public float hours;
    public Text Stopwatcher;
    bool start;



    // Update is called once per frame
    void Update()
    {
        StopWatchUpdate();
    }
    void StopWatchUpdate()
    {
        if ( start)
        {
            timer+= Time.deltaTime;
            seconds = ( int) ( timer %60);
            minutes = ( int) (( timer / 60)%60);
            hours = ( int) ( timer /3600) ;
            Stopwatcher.text = hours.ToString("00" ) + ":" + minutes.ToString("00" ) + ":" + seconds.ToString("00" ) ;
            GameController.instance.DataStorage.PlayerInfo.TimeInGame = timer;
            
        }
    }
    public void Starttimer()
    {
        start=true;
        timer =GameController.instance.DataStorage.PlayerInfo.TimeInGame;
    }
    public void Stotimer()
    {   
        start=false;

    }
}
