using UnityEngine;

namespace Joy.Tweening
{
    public static class JoyTween
    {
        public delegate Vector3 Getter();
        public delegate void Setter<Vector3>(Vector3 value);
        public static TweenerCore To(Getter getter, Setter<Vector3> setter, Vector3 endValue, float duration, string id = "")
        {
            Vector3 startValue = getter.Invoke();
            TweenerCore tweenerCore = new TweenerCore()
                .SetJoyId(id)
                .SetStartValue(startValue)
                .SetEndValue(endValue)
                .SetDuration(duration)
                .SetUpdateAction((v) => {
                    setter.Invoke(v);
                });
            return tweenerCore;
        }

        public static void Kill(string id)
        {
            TweenerManager.Instance.RemoveTweener(id);
        }
    }
}