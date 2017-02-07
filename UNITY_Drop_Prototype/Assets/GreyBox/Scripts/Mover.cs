using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public Rail_Movement rail;

    private int currentSeg;
    private float transition;
    private bool isCompleted;

    private void Update()
    {
        if (!rail)
            return;

        if (!isCompleted)
            Play();
    }

    private void Play()
    {
        transition += Time.deltaTime * 1 / 2.5f;

        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
        }
        else if (transition < 0)
        {
            transition = 1;
            currentSeg--;
        }

        transform.position = rail.CatmullPosition(currentSeg, transition);
        transform.rotation = rail.Orientation(currentSeg, transition);

    }
}
