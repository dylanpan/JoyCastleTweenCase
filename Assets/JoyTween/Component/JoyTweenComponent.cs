using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Joy.Tweening;

namespace Joy.Tweening
{
    public class JoyTweenComponent : MonoBehaviour
    {
        /*
            1. 将组件挂载在不可销毁中的某个 GameObject 上
            2. 执行 Update，对目前已有的全部进行 Update 操作
        */
        void Start()
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            TweenerManager.Instance.UpdateTweener(Time.deltaTime);
        }
    }
}
