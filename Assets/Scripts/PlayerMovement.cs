using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private int coinsCollected;
    private int enemiesKilled;
    private int coinsCollectedBeginningOfLevel;
    private int enemiesKilledBeginningOfLevel;

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI enemiesKilledText;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if(SceneManager.GetActiveScene().name == "L1")
        {
            coinsCollected = enemiesKilled = 0;

            PlayerPrefs.SetInt("coins", 0);
            PlayerPrefs.SetInt("enemiesKilled", 0);
        }
        else if(SceneManager.GetActiveScene().name == "L2")
        {
            coinsCollected = coinsCollectedBeginningOfLevel = PlayerPrefs.GetInt("coins");
            enemiesKilled = enemiesKilledBeginningOfLevel = PlayerPrefs.GetInt("enemiesKilled");

            coinsText.text = "Coins: " + coinsCollected.ToString();
            enemiesKilledText.text = "Enemies Killed: " + enemiesKilled.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray moveToPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(moveToPosition, out var hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            coinsCollected++;
            PlayerPrefs.SetInt("coins", coinsCollected);
            coinsText.text = "Coins: " + coinsCollected.ToString();

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            enemiesKilled++;
            PlayerPrefs.SetInt("enemiesKilled", enemiesKilled);
            enemiesKilledText.text = "Enemies Killed: " + enemiesKilled.ToString();

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("enemyRestart"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            Invoke(nameof(ReloadLevel), 1.5f);
        }

        if (other.gameObject.CompareTag("finishLine"))
        {
            if(SceneManager.GetActiveScene().name == "L1")
            {
                SceneManager.LoadScene("L2");
            }

            else if (SceneManager.GetActiveScene().name == "L2")
            {
                SceneManager.LoadScene("EndScreen");
            }
        }
    }

    private void ReloadLevel()
    {
        if(SceneManager.GetActiveScene().name == "L2")
        {
            PlayerPrefs.SetInt("coins", coinsCollectedBeginningOfLevel);
            PlayerPrefs.SetInt("enemiesKilled", enemiesKilledBeginningOfLevel);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
