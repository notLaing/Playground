using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject puzzlePiece;
    public float[] destinations = {-18f, 2f, 12f};//-34, 2, 12. Why is the result (desination[x] * 2) + 2?
    float currentX = 0f;
    float y = 0.5f;
    public float z = 0f;
    float time = 0f;
    int posCheck = 0;
    int nextPosCheck = 1;
    bool move = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //if(player.transform.position)
            if(!move) move = true;
        }
    }

    // Update is called once per physics update
    void FixedUpdate()
    {
        if (move)
        {
            time += Time.fixedDeltaTime;
            movePiece();
            if(time > 3f)
            {
                move = false;
                time = 0f;
                ++posCheck;
                ++nextPosCheck;
                if (posCheck > destinations.Length -1) posCheck = 0;
                if (nextPosCheck > destinations.Length - 1) nextPosCheck = 0;
            }
        }
    }

    void movePiece()
    {
        currentX = Mathf.Lerp(destinations[posCheck], destinations[nextPosCheck], time / 2.5f);
        puzzlePiece.transform.localPosition = new Vector3(currentX, y, z);
    }

    float calcDistance()
    {
        return 0f;
    }
}
