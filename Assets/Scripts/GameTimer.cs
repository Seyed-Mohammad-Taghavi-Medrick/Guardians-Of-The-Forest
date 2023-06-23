using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("our level timer in seconds")] [SerializeField]
    private float levelTime = 10f;

    private bool TriggerLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (TriggerLevelFinished) return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timeFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timeFinished)

        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            TriggerLevelFinished = true;
        }
    }
}