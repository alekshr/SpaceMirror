using Mirror;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Services.Instantiate
{
    public class InstantiateObject : IInstantiateObject<GameObject>
    {
        public GameObject CreateObject(Transform parent, IObjectResolver objectResolver, string key)
        {
            var handler = Addressables.LoadAssetAsync<GameObject>(key);
            var objects = handler.WaitForCompletion();
            var instantiateObject = objectResolver.Instantiate(objects, parent);
            return instantiateObject;
        }
        
        public GameObject CreateObject(IObjectResolver objectResolver, string key)
        {
            var handler = Addressables.LoadAssetAsync<GameObject>(key);
            var objects = handler.WaitForCompletion().gameObject;
            var instantiateObject = objectResolver.Instantiate(objects);
            return instantiateObject;
        }
    }
}