using UnityEngine;
using VContainer;

namespace CodeBase.Services.Instantiate
{
    public interface IInstantiateObject<T>
    {
        T CreateObject(Transform parent, IObjectResolver objectResolver, string key);
        
        T CreateObject(IObjectResolver objectResolver, string key);

    }
}