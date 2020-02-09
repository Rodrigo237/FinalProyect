using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
 //   private Vector3 cameraPositionstart = new Vector3(0.4f, 15.1f, -83.3f);
     private Transform[] players;
  //  private GameObject fightCamera;

    //private  float cameraValueXAxis;
    //private float cameraValueZAxis;

    //private int cameraValueZAxisModifier = -8;

    //public   static GameObject player;
    //public static GameObject enemy;

    //private Vector3 playerPosition;
    //private Vector3 enemyPosition;
    private void Start()
    {
      //  fightCamera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

       // fightCamera.transform.position = cameraPositionstart;

        players = new Transform[allPlayers.Length];
        for (int i = 0; i < allPlayers.Length; i++)
        {
            players[i] = allPlayers[i].transform;
        }
    }

    public float yOffset = 2.0f;
    public float minDistance = 7f;

    private float xMin, xMax, yMin, yMax;

    private void LateUpdate()
    {
        if (players.Length == 0)
        {
            Debug.Log("No hay players");
            return;
        }

        xMin = xMax = players[0].position.x;
        yMin = yMax = players[0].position.y;

        for (int i = 1; i < players.Length; i++)
        {
            if (players[i].position.x < xMin)
                xMin = players[i].position.x;

            if (players[i].position.x > xMax)
                xMax = players[i].position.x;

            if (players[i].position.y < yMin)
                yMin = players[i].position.y;

            if (players[i].position.y > yMax)
                yMax = players[i].position.y;
        }

        float xMiddle = (xMin + xMax) / 2;
        float yMiddle = (yMin + yMax) / 2;

        float distance = xMax - xMin;
        if (distance < minDistance)
            distance = minDistance;

        transform.position = new Vector3(xMiddle, yMiddle + yOffset, -distance);

    }


    //private void Update()
    //{
    //    UpdatePlayerPosition();
    //    UpdateEnemyPosition();
    //    UpdateCameraPosition();
    //}
    //void UpdatePlayerPosition()
    //{
    //    playerPosition = new Vector3( player.transform.position.x,
    //        player.transform.position.y,
    //        player.transform.position.z);
    //}

    //void UpdateEnemyPosition()
    //{
    //    enemyPosition = new Vector3(enemy.transform.position.x,
    //        enemy.transform.position.y,
    //        enemy.transform.position.z);
    //}

    //void UpdateCameraPosition()
    //{
    //    cameraValueXAxis = (player.transform.position.x + enemy.transform.position.x) / 2;

    //    if (player.transform.position.x < enemy.transform.position.x)
    //        cameraValueXAxis = player.transform.position.x -
    //            enemy.transform.position.x;

    //    if (player.transform.position.x > enemy.transform.position.x)
    //        cameraValueXAxis = enemy.transform.position.x -
    //            player.transform.position.x;

    //    if (cameraValueZAxis > -7)
    //        cameraValueZAxis = -7;

    //    fightCamera.transform.position = new Vector3(cameraValueXAxis, 1,
    //        cameraValueZAxis + cameraValueZAxisModifier);
    //}
}
