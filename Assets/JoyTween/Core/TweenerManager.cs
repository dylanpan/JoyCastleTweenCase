using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joy.Tweening
{
    public class TweenerManager
    {
        private static TweenerManager instance;

        public static TweenerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TweenerManager();
                }
                return instance;
            }
        }

        private TweenerManager()
        {
            
        }
        private Dictionary<string, TweenerCore> _dictionary = new Dictionary<string, TweenerCore>();
        public void AddTweener(string id, TweenerCore tweenerCore)
        {
            if (!_dictionary.ContainsKey(id))
            {
                _dictionary.Add(id, tweenerCore);
            }
        }
        public void RemoveTweener(string id)
        {
            if (_dictionary.ContainsKey(id))
            {
                TweenerCore tweenerCore = _dictionary[id];
                tweenerCore.Clear();
                _dictionary.Remove(id);
            }
        }
        public void ChangeTweenerId(string oldId, string newId)
        {
            TweenerCore tweenerCore = null;
            if (_dictionary.ContainsKey(oldId))
            {
                tweenerCore = _dictionary[oldId];
                _dictionary.Remove(oldId);
            }
            if (tweenerCore != null)
            {
                if (!_dictionary.ContainsKey(newId))
                {
                    _dictionary.Add(newId, tweenerCore);
                }
            }
        }
        public void UpdateTweener(float deltaTime)
        {
            foreach (KeyValuePair<string, TweenerCore> item in _dictionary)
            {
                item.Value?.Update(deltaTime);
            }
        }
    }
}