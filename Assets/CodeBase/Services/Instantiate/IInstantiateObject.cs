using UnityEngine;
using VContainer;

namespace CodeBase.Services.Instantiate
{
    public interface IInstantiateObject
    {
        GameObject CreateObject(string key);

    }
}