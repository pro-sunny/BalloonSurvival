using System.Collections;
using UnityEngine;

public interface IScoreWindowActivator
{
    public void Activate(float delay);
}

public class ScoreWindowActivator : MonoBehaviour, IScoreWindowActivator
{
    [SerializeField] private GameObject _scoreWindow;
    
    public void Activate(float delay)
    {
        StartCoroutine(ActivateWindow(delay));
    }

    private IEnumerator ActivateWindow(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        _scoreWindow.SetActive(true);
    }
}
