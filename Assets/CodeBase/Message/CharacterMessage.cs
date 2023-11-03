using Mirror;
using UnityEngine;

namespace CodeBase.Message
{
    public struct CharacterMessage : NetworkMessage
    {
        private Color32 color;
        public Color32 Color => color;
        
        private string name;
        public string Name => name;

        public CharacterMessage(string name)
        {
            this.name = name;
            color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f);
        }
    }
}
