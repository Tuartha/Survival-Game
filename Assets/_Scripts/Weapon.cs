using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    public int _rotationSpeed = 200;
    [SerializeField]
    private Vector3 rotationPoint = Vector3.zero;
    void Start() {
        Update();
    }

    void Update() {
        float rotationAmount = CalculateRotationAmount(Time.deltaTime);
        transform.RotateAround(rotationPoint, Vector3.forward, rotationAmount);
        return;
    }

    private float CalculateRotationAmount(float delta) {
        return _rotationSpeed * delta;
    }

    public void UpRotationSpeed(int newSpeed) {
        _rotationSpeed += newSpeed;
        Debug.Log("New rotation speed: " + _rotationSpeed);
    }
}
