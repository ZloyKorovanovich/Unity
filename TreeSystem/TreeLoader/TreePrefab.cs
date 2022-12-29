using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePrefab : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _skins;
    private GameObject _activeSkin;

    private void OnEnable()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            _skins[i].SetActive(false);
        }
        _activeSkin = _skins[Random.Range(0, _skins.Length)];
        _activeSkin.SetActive(true);
    }
}
