using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Joy.Tweening;

namespace Joy.Tweening
{
    public enum JoyEase
    {
        Linear,
        InSine,
        OutSine,
        InOutSine,
        InBack,
        OutBack,
        InOutBack,
    }
    public static class JoyEaseInterpolation
    {
        public const float c1 = 1.70158f;
        public const float c2 = 1.70158f * 1.525f;
        public const float c3 = 1.70158f + 1f;
        public const float c4 = (2f * Mathf.PI) / 3f;
        public const float c5 = (2f * Mathf.PI) / 4.5f;
        public static float GetInterpolation(JoyEase joyEase, float current, float finish)
        {
            float interpolation = 0f;
            switch (joyEase)
            {
                case JoyEase.Linear:
                {
                    interpolation = JoyEaseInterpolation.GetLinear(current, finish);
                    break;
                }
                case JoyEase.InSine:
                {
                    interpolation = JoyEaseInterpolation.GetInSine(current, finish);
                    break;
                }
                case JoyEase.OutSine:
                {
                    interpolation = JoyEaseInterpolation.GetOutSine(current, finish);
                    break;
                }
                case JoyEase.InOutSine:
                {
                    interpolation = JoyEaseInterpolation.GetInOutSine(current, finish);
                    break;
                }
                case JoyEase.InBack:
                {
                    interpolation = JoyEaseInterpolation.GetInBack(current, finish);
                    break;
                }
                case JoyEase.OutBack:
                {
                    interpolation = JoyEaseInterpolation.GetOutBack(current, finish);
                    break;
                }
                case JoyEase.InOutBack:
                {
                    interpolation = JoyEaseInterpolation.GetInOutBack(current, finish);
                    break;
                }
                default:
                {
                    interpolation = JoyEaseInterpolation.GetLinear(current, finish);
                    break;
                }
            }
            return interpolation;
        }

        private static float GetLinear(float current, float finish)
        {
            // Mathf.Clamp01 是一个用来将值限制在 0 到 1 之间的函数
            float t = Mathf.Clamp01(current / finish);
            
            // 这样的写法需要修正啦
            // float t = current/finish;
            return t;
        }
        private static float GetInSine(float current, float finish)
        {
            float t = Mathf.Clamp01(current / finish);
            t = 1f - Mathf.Cos((t * Mathf.PI) / 2f);
            return t;
        }
        private static float GetOutSine(float current, float finish)
        {
            float t = Mathf.Clamp01(current / finish);
            t = Mathf.Sin((t * Mathf.PI) / 2f);;
            return t;
        }
        private static float GetInOutSine(float current, float finish)
        {
            float t = Mathf.Clamp01(current / finish);
            t = -(Mathf.Cos(Mathf.PI * t) - 1f) / 2f;
            return t;
        }
        private static float GetInBack(float current, float finish)
        {
            float t = Mathf.Clamp01(current / finish);
            t = c3 * t * t * t - c1 * t * t;
            return t;
        }
        private static float GetOutBack(float current, float finish)
        {
            float t = Mathf.Clamp01(current / finish);
            t = 1f + c3 * Mathf.Pow(t - 1f, 3f) + c1 * Mathf.Pow(t - 1f, 2f);;
            return t;
        }
        private static float GetInOutBack(float current, float finish)
        {
            float t = Mathf.Clamp01(current / finish);
            if (t < 0.5)
            {
			    t = (Mathf.Pow(2f * t, 2f) * ((c2 + 1f) * 2f * t - c2)) / 2f;
            }
            else
            {
			    t = (Mathf.Pow(2f * t - 2f, 2f) * ((c2 + 1f) * (t * 2f - 2f) + c2) + 2f) / 2f;
            }
            return t;
        }
    }
}