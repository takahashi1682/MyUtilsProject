using System;
using Samples;
using UnityEngine;
using R3;

public class InputTest : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _inputReader;

    public Vector2 Move;
    public Vector2 Look;
    public bool Fire;

    private void Start()
    {
        // 値が更新された時だけ取得する 
        _inputReader.Move.Subscribe(value => Move = value).AddTo(this);
        _inputReader.Look.Subscribe(value => Look = value).AddTo(this);
        _inputReader.Fire.Subscribe(value =>
        {
            Fire = value;

            if (value)
            {
                Debug.Log("Fire!");
            }
        }).AddTo(this);
    }
}