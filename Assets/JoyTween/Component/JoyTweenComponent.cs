using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Joy.Tweening;

namespace Joy.Tweening
{
    public class JoyTweenComponent : MonoBehaviour
    {
        private static JoyTweenComponent m_Instance;
        public static JoyTweenComponent Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    GameObject gameObject = new GameObject("JoyTweenComponent");
                    m_Instance = gameObject.AddComponent<JoyTweenComponent>();
                    GameObject.DontDestroyOnLoad(gameObject);
                }
                return m_Instance;
            }
        }

        void OnDestroy()
        {
            m_Instance = null;
        }
        public void Init()
        {

        }

        void Update()
        {
            // 对目前已有的全部进行 Update 操作
            TweenerManager.Instance.UpdateTweener(Time.deltaTime);
        }
    }
}
