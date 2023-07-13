using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Runtime.Character
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [Min(0.0f)] public float Speed = 5.0f;
    }
}
