using Assets.Scripts.Match3;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Match3Skin match3;

    private void Awake() => match3.StartNewGame();

    private void Update()
    {
        if (match3.IsPlaying)
        {
            if (!match3.IsBusy)
            {
                HandleInput();
                match3.DoWork();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
            match3.StartNewGame();

    }

    Vector3 dragStart;
    bool isDragging;

    private void HandleInput()
    {
        if (!isDragging && Input.GetMouseButtonDown(0))
        {
            dragStart = Input.mousePosition;
            isDragging = true;
        }
        else if (isDragging && Input.GetMouseButton(0))
        {
            isDragging = Match3Game.EvaluateDrag(dragStart, Input.mousePosition);
        }
        else 
            isDragging = false;
    }

    public bool EvaluateDrag(Vector3 start, Vector3 end) { return false; }
}
