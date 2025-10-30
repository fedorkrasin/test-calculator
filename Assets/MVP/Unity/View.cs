using MVP.Core.Interfaces;
using UnityEngine;

namespace MVP.Unity
{
    public abstract class View : MonoBehaviour, IView
    {
        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
            Destroy(gameObject);
        }
    }
}