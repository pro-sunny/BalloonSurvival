using UnityEngine;

public interface IScoreReader
{
    public string GetScore();
}

public interface IScoreUpdater
{
    public void Update();
}

public class ScoreController: IScoreReader, IScoreUpdater
{
    private float _score;

    public string GetScore()
    {
        return FormatSeconds(_score);
    }
    
    public void Update()
    {
        _score += Time.deltaTime;
    }
    
    string FormatSeconds(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        return $"{minutes:00}:{seconds:00}";
    }
}
