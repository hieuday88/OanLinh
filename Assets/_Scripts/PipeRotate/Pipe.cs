using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // Thêm dòng này để dùng DOTween

public abstract class Pipe : MonoBehaviour
{
    public int _rate = 0;
    public int mark = 0;
    public bool _active = true;

    public abstract void RotatePipe();
    

    [SerializeField] private Material _mat;

    void Awake()
    {
        var mats = GetComponent<MeshRenderer>().materials;
        foreach (var mat in mats)
        {
            if (mat.name.StartsWith("Pipe")) // tên hiển thị là "Pipe (Instance)"
            {
                _mat = mat;
                break;
            }
        }

        if (_mat == null)
        {
            Debug.LogError("Không tìm thấy material tên 'Pipe' trong MeshRenderer của: " + gameObject.name);
        }
    }

    public void EnableGlow(Color glowColor, float intensity)
    {
        _mat.EnableKeyword("_EMISSION");
        _mat.SetColor("_EmissionColor", glowColor * intensity);
    }

}

