using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    private static Beat BeatInstance;
    public float bpm;
    private float fullBeatInterval, _8BeatInterval;
    private float fullBeatTimer, _8BeatTimer;
    public static bool isFullBeat, is8Beat;
    public static int fullBeatCount, _8BeatCount;

    // Start is called before the first frame update
    void Start()
    {
        if (BeatInstance != null && BeatInstance != this){
            Destroy(gameObject);
        } else {
            BeatInstance = this;
            DontDestroyOnLoad(gameObject);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
         fullBeatInterval = 60f / bpm;
        _8BeatInterval = fullBeatInterval / 8f;
        fullBeatTimer += Time.deltaTime;
        var fullBeatData = BeatDetection(fullBeatTimer, fullBeatInterval, isFullBeat, fullBeatCount);
        fullBeatCount = fullBeatData.tmpBeatCount;
        fullBeatTimer = fullBeatData.tmpBeatTimer;
        isFullBeat = fullBeatData.tmpOnBeat;
        
        _8BeatTimer += Time.deltaTime;
        var _8BeatData = BeatDetection(_8BeatTimer, _8BeatInterval, is8Beat, _8BeatCount);
        _8BeatCount = _8BeatData.tmpBeatCount;
        is8Beat = _8BeatData.tmpOnBeat;
        _8BeatTimer = _8BeatData.tmpBeatTimer;

      //  Debug.Log(fullBeatCount);
      //  Debug.Log("8 beat " + _8BeatCount);
        //BeatCounter();
    }

    (int tmpBeatCount, bool tmpOnBeat, float tmpBeatTimer) BeatDetection(float targetBeatTimer, float targetBeatInterval, 
                                                            bool isFullTargetBeat, int targetBeatCount) {
        isFullTargetBeat = false;

        if (targetBeatTimer > targetBeatInterval) {
            targetBeatTimer -= targetBeatInterval;
            isFullTargetBeat = true;
            targetBeatCount++;
        }
        return (targetBeatCount, isFullTargetBeat, targetBeatTimer);
    }

    void BeatCounter(){
        isFullBeat = false;
        fullBeatTimer += Time.deltaTime;

        if (fullBeatTimer > fullBeatInterval) {
            fullBeatTimer -=fullBeatInterval;
            isFullBeat = true;
            fullBeatCount++;
        }

        is8Beat = false;
        _8BeatTimer += Time.deltaTime;

        if (_8BeatTimer > _8BeatInterval) {
            _8BeatTimer -=_8BeatInterval;
            is8Beat = true;
            _8BeatCount++;
        }
    }
}
