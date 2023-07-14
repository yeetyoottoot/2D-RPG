using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Runtime.Character
{
    public class CameraFollow : MonoBehaviour
    {
       // Transform for the camera to follow. 
       [SerializeField] private Transform _followTransform;
       [SerializeField] private BoxCollider2D _mapBounds;

        private float _cameraX;
        private float _cameraY;
        private float _cameraOrthographicSize;
        private float _cameraRatio;

        void Awake()
        {
            if (_followTransform == null) Debug.LogError("Follow Target Is Null!!!");
            _cameraOrthographicSize = GetComponent<Camera>().orthographicSize;
            // Camera ratio is used to taken into account the aspect ratio offset in the x-axis
            _cameraRatio = (_mapBounds.bounds.max.x + _cameraOrthographicSize) / 2.0f;

        }

        void FixedUpdate()
        {
            _cameraX = Mathf.Clamp(
                _followTransform.position.x, 
                _mapBounds.bounds.min.x + _cameraRatio, 
                _mapBounds.bounds.max.x - _cameraRatio
                );

            _cameraY = Mathf.Clamp(
                _followTransform.position.y,
                _mapBounds.bounds.min.y + _cameraOrthographicSize,
                _mapBounds.bounds.max.y - _cameraOrthographicSize
                );

            transform.position = new Vector3(_cameraX , _cameraY, transform.position.z);
        }
    }
}
