using MVP.Core.View;
using UnityEngine;

namespace MVP.Unity
{
    public abstract class View : MonoBehaviour, IView
    {
        public abstract void Initialize();
        public abstract void Dispose();
    }
}