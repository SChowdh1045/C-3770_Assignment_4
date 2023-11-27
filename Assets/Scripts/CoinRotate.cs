using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 360f * Time.deltaTime, 0f);
    }
}
