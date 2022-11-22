using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_Components : MonoBehaviour {
    public Transform playerTransform;
    // (초기값 -> 카메라 위치 - 대상 위치)
    public Vector3 Offset;

    void LateUpdate() {
        transform.position = playerTransform.position + Offset;
    }
}
