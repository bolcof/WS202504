using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [Tooltip("注視点となるターゲット")]
    public Transform target;

    [Header("回転設定")]
    public float xSpeed = 120.0f;
    public float ySpeed = 80.0f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    [Header("ズーム設定")]
    public float zoomSpeed = 5.0f;
    public float minDistance = 1.0f;
    public float maxDistance = 20.0f;

    private float distance;
    private float x;
    private float y;

    void Start() {
        if (target == null) {
            Debug.LogError("OrbitCamera に注視点が設定されていません。");
            enabled = false;
            return;
        }

        // 初期状態から距離と角度を計算
        Vector3 offset = transform.position - target.position;
        distance = offset.magnitude;

        Vector3 dir = offset.normalized;
        Quaternion rot = Quaternion.LookRotation(-dir);
        x = rot.eulerAngles.y;
        y = rot.eulerAngles.x;
    }

    void LateUpdate() {
        // マウスドラッグで回転
        if (Input.GetMouseButton(0)) {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        }

        // マウスホイールでズーム
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f) {
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }

        // カメラ位置と回転を更新
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0f, 0f, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}