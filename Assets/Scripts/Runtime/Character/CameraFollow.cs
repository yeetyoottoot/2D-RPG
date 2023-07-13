using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Runtime.Character
{
    public class CameraFollow : MonoBehaviour
    {
       // Transform for the camera to follow. 
       [SerializeField] private Transform _followTransform;

        void Awake()
        {
            if (_followTransform == null) Debug.LogError("Follow Target Is Null!!!");
        }

        void FixedUpdate()
        {
            this.transform.position = new Vector3(_followTransform.position.x, _followTransform.position.y, this.transform.position.z);
        }
    }
}
