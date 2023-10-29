using System;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreVisualizer : MonoBehaviour
{
    [SerializeField] private bool _isStatic;
    [SerializeField] private TMP_Text _scoreValueTMP;
    
    private IScoreReader _scoreReader;

    [Inject]
    private void Construct(IScoreReader scoreReader)
    {
        _scoreReader = scoreReader;
    }

    private void Start()
    {
        _scoreValueTMP.text = _scoreReader.GetScore();
    }

    private void Update()
    {
        if (!_isStatic)
        {
            _scoreValueTMP.text = _scoreReader.GetScore();
        }
    }
}
