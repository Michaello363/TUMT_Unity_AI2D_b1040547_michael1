using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class CamerController : MonoBehaviour
    {
        
        [Header("速度"), Range(0, 10)]
        public float speed = 3;
        public Transform target;

        private void Start()
        {
            target = GameObject.Find("肉球").transform;
        }

        private void LateUpdate()
        {
            Vector3 cam = transform.position;
            Vector3 tar = target.position;
            tar.z = -10;
            transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
        }
    }
}

