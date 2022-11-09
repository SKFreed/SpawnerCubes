using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSettings : MonoBehaviour
{
    public IEnumerator _MoveCubeCorutine;
    public Transform _transform;
    public Vector3 _target;
    public float _speed;

    private void Awake()
    {
        _MoveCubeCorutine = MoveToTarget();
    }
    IEnumerator MoveToTarget()
    {
        while (_transform.position != _target)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _target, Time.deltaTime * _speed);
            yield return _transform;
        }     
        StopCoroutine(_MoveCubeCorutine);
        Destroy(gameObject);
    }

}
