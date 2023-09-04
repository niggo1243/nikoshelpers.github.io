using NikosAssets.Helpers;
using UnityEngine;

namespace NikosAssets.Helpers
{
    //TODO put this into helper tools!
    public abstract class BaseSingletonMono<T> : BaseNotesMono
        where T : BaseSingletonMono<T>
    {
        public static T Instance { get; protected set; }
        
        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Instance of " + typeof(T).Name + " already assigned for: " + Instance.name + " !!");
                return;
            }
            
            Instance = (T)this;
        }
    }
}