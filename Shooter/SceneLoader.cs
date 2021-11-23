using UnityEngine;
using SequentedScenes;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private ScenesSequence _sequence;

    private void OnEnable()
    {
        _sequence.Ended += OnSequenceEnded;
    }

    private void OnDisable()
    {
        _sequence.Ended -= OnSequenceEnded;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNext();
        }
    }

    public void LoadNext()
    {
        _sequence.LoadNext();
    }

    private void OnSequenceEnded() { }
}
