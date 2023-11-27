using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class endScreenResults : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsResultsText;
    [SerializeField] private TextMeshProUGUI enemiesKilledResultsText;

    // Start is called before the first frame update
    void Start()
    {
        coinsResultsText.text = "Coins Collected: " + PlayerPrefs.GetInt("coins");
        enemiesKilledResultsText.text = "Enemies Killed: " + PlayerPrefs.GetInt("enemiesKilled");
    }
}
