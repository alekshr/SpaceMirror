using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Services.Instantiate
{
    public class InstantiateObject : IInstantiateObject
    {
        public GameObject CreateObject(string key)
        {
            var handler = Addressables.LoadAssetAsync<GameObject>(key);
            var objects = handler.WaitForCompletion().gameObject;
            var instantiateObject = Object.Instantiate(objects);
            return instantiateObject;
        }
    }
}