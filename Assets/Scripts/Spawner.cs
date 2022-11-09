using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    #region distance
    [SerializeField] private int _distance;
    [SerializeField] private TMP_Text _distanceText;
    public string distance { get { return _distance.ToString(); } set { int.TryParse(value, out int val);_distance = val; _distanceText.text = val.ToString(); SetTarget(); } }
    #endregion
    #region timeDuration
    [SerializeField] private int _timeDuration;
    [SerializeField] private TMP_Text _timeDurationText;
    public string timeDuration { get { return _timeDuration.ToString(); } set { int.TryParse(value, out int val); _timeDuration = val; _timeDurationText.text = val.ToString(); } }
    #endregion
    #region speed
    [SerializeField] private float _speed;
    [SerializeField] private TMP_Text _speedText;
    public string speed { get { return _speed.ToString(); } set { float.TryParse(value, out float val); _speed = val; _speedText.text = val.ToString();} }
    #endregion
    [SerializeField] private GameObject Cube;
    IEnumerator spawnCubeCoroutine;
    private Vector3 target;
    private bool _start;
    public bool start
    {
        get { return _start; }
        set
        {
            _start = value;
            if (value) StartCoroutine(spawnCubeCoroutine);
            else if(spawnCubeCoroutine != null)StopCoroutine(spawnCubeCoroutine);
        }
    }
    private void Start() => spawnCubeCoroutine = SpawnCube();    
    public void SetTarget() => target = new Vector3(_distance, 0,0);
    IEnumerator SpawnCube()
    {
        while (true)
        {
            if (_timeDuration > 0)
            {
                GameObject cube = Instantiate(Cube, transform);
                CubeSettings cubeSet = cube.GetComponent<CubeSettings>();
                if (cubeSet == null) cubeSet.AddComponent<CubeSettings>();
                cubeSet._transform = cube.transform;
                cubeSet._speed = _speed;
                cubeSet._target = target;
                StartCoroutine(cubeSet._MoveCubeCorutine);
                yield return new WaitForSeconds(_timeDuration);
            }
        }
    }
}
