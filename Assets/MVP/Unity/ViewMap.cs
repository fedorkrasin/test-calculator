using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MVP.Unity
{
    [CreateAssetMenu(fileName = "ViewMap", menuName = "MVP/ViewMap")]
    public class ViewMap : ScriptableObject
    {
        [SerializeField] private List<View> _views;

        public Dictionary<Type, View> ToDictionary()
        {
            return _views.ToDictionary(view => view.GetType(), view => view);
        }
    }
}