using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Runtime.Character
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [Min(0.0f)] public float WalkSpeed = 5.0f;
        [Min(0.0f)] public float SprintSpeed = 10f;
    }
}
