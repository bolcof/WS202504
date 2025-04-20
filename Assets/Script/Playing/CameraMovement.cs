using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [Tooltip("注視点となるターゲット")]
    public Transform target;

    [Tooltip("回転感度（横）")]
    public float xSpeed = 960.0f;

    [Tooltip("回転感度（縦）")]
    public float ySpeed = 480.0f;

    [Tooltip("縦回転の最小角度")]
    public float yMinLimit = -20f;

    [Tooltip("縦回転の最大角度")]
    public float yMaxLimit = 80f;

    private float distance; // 注視点からの距離
    private float x;        // 水平角
    private float y;        // 垂直角

    void Start() {
        if (target == null) {
            Debug.LogError("OrbitCamera に注視点が設定されていません。");
            enabled = false;
            return;
        }

        // 初期距離を計算
        Vector3 offset = transform.position - target.position;
        distance = offset.magnitude;

        // 初期角度を計算（注視点から見たカメラの角度）
        Vector3 dir = offset.normalized;
        Quaternion rot = Quaternion.LookRotation(-dir); // 注視点 → カメラの方向
        x = rot.eulerAngles.y;
        y = rot.eulerAngles.x;
    }

    void LateUpdate() {
        if (Input.GetMouseButton(0)) {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        }

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0f, 0f, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}
