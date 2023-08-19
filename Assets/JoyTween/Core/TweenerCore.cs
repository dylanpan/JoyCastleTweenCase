using System;
using System.Timers;
using UnityEngine;

namespace Joy.Tweening
{
    public class TweenerCore
    {
        private GameObject _gameObject;
        private float _duration;
        private float _spendTime;
        private Vector3 _startValue;
        private Vector3 _endValue;
        private string _id;
        private JoyEase _joyEase = JoyEase.Linear;

        private Action<Vector3> _onUpdateAction;
        private Action _onEndAction;
        public TweenerCore()
        {
            _id = GetDefaultId();
            TweenerManager.Instance.AddTweener(_id, this);
        }
        private string GetDefaultId()
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
            long timestampMilliseconds = dateTimeOffset.ToUnixTimeMilliseconds();
            return timestampMilliseconds.ToString();
        }
        public void Clear()
        {
            _spendTime = 0f;
            _onUpdateAction = null;
            _onEndAction = null;
        }

        public TweenerCore SetJoyId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                TweenerManager.Instance.ChangeTweenerId(_id, id);
                _id = id;
            }
            return this;
        }
        public TweenerCore SetTarget(GameObject gameObject)
        {
            _gameObject = gameObject;
            return this;
        }
        public TweenerCore SetJoyEase(JoyEase joyEase)
        {
            _joyEase = joyEase;
            return this;
        }
        public TweenerCore SetStartValue(Vector3 value)
        {
            _startValue = value;
            return this;
        }
        public TweenerCore SetEndValue(Vector3 value)
        {
            _endValue = value;
            return this;
        }
        public TweenerCore SetDuration(float duration)
        {
            _duration = duration;
            return this;
        }
        public TweenerCore SetUpdateAction(Action<Vector3> action)
        {
            _onUpdateAction = action;
            return this;
        }
        public TweenerCore SetEndAction(Action action)
        {
            _onEndAction = action;
            return this;
        }
        public void Update(float deltaTime)
        {
            _spendTime += deltaTime;
            if (_onUpdateAction != null && _spendTime <= _duration)
            {
                Vector3 newValue = GetLerpVector();
                _onUpdateAction?.Invoke(newValue);
            }
            else
            {
                _onEndAction?.Invoke();
                Clear();
            }
        }
        private Vector3 GetLerpVector()
        {
            float t = JoyEaseInterpolation.GetInterpolation(_joyEase, _spendTime, _duration);
            if (t >= 0 && t <= 1)
            {
                Vector3 newValue = Vector3.Lerp(_startValue, _endValue, t);
                return newValue;
            }
            else
            {
                Vector3 newValue = Vector3.LerpUnclamped(_startValue, _endValue, t);
                return newValue;
            }
        }
    }
}