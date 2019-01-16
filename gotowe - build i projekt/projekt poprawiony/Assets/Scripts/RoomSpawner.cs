using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    GameObject roomManager;
    RoomManagement rM;

    private void Start()
    {
        roomManager = GameObject.Find("RoomManager");
        rM = roomManager.GetComponent<RoomManagement>();

        SpawnRoom();
    }

    RoomManagement.RoomType ThisRoom()
    {
        var parents = gameObject.GetComponentsInParent<Transform>();
        string name = parents[1].name;
        if (name.Contains("PL"))
            return RoomManagement.RoomType.PL;
        else if (name.Contains("PG"))
            return RoomManagement.RoomType.PG;
        else if (name.Contains("PX"))
            return RoomManagement.RoomType.PX;
        else if (name.Contains("DL"))
            return RoomManagement.RoomType.DL;
        else if (name.Contains("DG"))
            return RoomManagement.RoomType.DG;
        else if (name.Contains("DX"))
            return RoomManagement.RoomType.DX;
        else
            throw new System.Exception(" ThisRoom() Błąd przypisania pokoju na podstawie nazwy !" + " string = " + name);
    }

    void SpawnRoom()
    {
        var temp = rM.GetCompatibleRoomsTo(ThisRoom());
        int rand = Random.Range(0, temp.Count );
        Instantiate(temp[rand],transform.position,Quaternion.identity);
    }




}
