using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTween : MonoBehaviour
{
    public Vector3 startValue;
    public Vector3 endValue;
    public float _duration = 10f;
    public float _spendTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startValue = transform.localPosition;
        endValue = new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        // 初始思路
        // 创建一个 core 对象，拿到对应的属性值，目标值，时间，根据对应的对应的曲线进行变换过程
        // 补充挂载组件在场景节点上进行 Update 的操作，创建，停止，销毁
        // _spendTime += Time.deltaTime;
        // if (_spendTime <= _duration)
        // {
        //     float t = _spendTime/_duration; // 这里变化其他曲线
        //     Vector3 newValue = Vector3.Lerp(startValue, endValue, t);
        //     Debug.Log("time t " + t + ", newValue: " + newValue + ", startValue: " + startValue + ", endValue: " + endValue);
        //     transform.localPosition = newValue;
        // }
    }
}
