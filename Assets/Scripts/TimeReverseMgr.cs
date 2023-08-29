using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReverseMgr : MonoBehaviour
{
    public float recordTime = 10f;
    private bool isRecording;

    public class TimeInfo
    {
        public Vector3 _pos;
        public Quaternion _rot;
        public TimeInfo(Vector3 pos, Quaternion quaternion)
        {
            _pos = pos;
            _rot = quaternion;
        }
    }

    private List<TimeInfo> timeInfos = new List<TimeInfo>();
    private Rigidbody rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("start record");
            StartReverse();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("stop record");
            StopReverse();
        }
    }

    private void FixedUpdate()
    {
        if(isRecording)
        {
            RecordInfo();
        }
        else
        {
            PopRecordInfo();
        }
    }

    void RecordInfo()
    {
        if (timeInfos.Count > Mathf.Round(recordTime / Time.deltaTime)) // exceeded
        {
            timeInfos.RemoveAt(timeInfos.Count - 1);
        }

        timeInfos.Insert(0, new TimeInfo(transform.position, transform.rotation));
    }

    void PopRecordInfo()
    {
        if(timeInfos.Count > 0)
        {
            TimeInfo timeInfo = timeInfos[0];
            transform.position = timeInfo._pos;
            transform.rotation = timeInfo._rot;
            timeInfos.RemoveAt(0);
        }
    }

    void StartReverse()
    {
        isRecording = true;
    }

    void StopReverse()
    {
        isRecording = false;
    }

}
