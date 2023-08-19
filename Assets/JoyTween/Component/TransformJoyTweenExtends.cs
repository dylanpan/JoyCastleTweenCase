using UnityEngine;
using UnityEngine.UI;
using Joy.Tweening;

namespace Joy.Tweening
{
    public static partial class TransformJoyTweenExtends
    {
        public static TweenerCore JoyMove(this Transform trans, Vector3 position, float duration)
        {
            TweenerCore tweenerCore = JoyTween.To(() => trans.localPosition, x => trans.localPosition = x, position, duration);
            tweenerCore.SetTarget(trans.gameObject);
            return tweenerCore;
        }
        public static TweenerCore JoyScale(this Transform trans, Vector3 scale, float duration)
        {
            TweenerCore tweenerCore = JoyTween.To(() => trans.localScale, x => trans.localScale = x, scale, duration);
            tweenerCore.SetTarget(trans.gameObject);
            return tweenerCore;
        }

    }
}