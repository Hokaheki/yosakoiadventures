using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagement : MonoBehaviour {
    
    //  Schemat nazywania pokoi - "Mapa_" + 'Pierwsza litera polskiej nazwy kierunku wyjścia' + 'Pierwsza litera polskiej nazwy kierunku wejścia' + 'numer pokoju tego typu'

    public enum RoomType    
    {
        PL, PG, PX, DL, DG, DX
    };

    private Object[] maps;  // Tablica do której są zczytywane wszystkie Objekty z folderu "Mapy" 

    //private List<Object> PL, PG, DL, DG;     // Próba optymalizacji kosztem pamięci - po 1 wykonaniu F() dla konkretnego pokoju, tu zostaną zapisane rezultaty, i następnym razem zostanie odesłana lista stąd

    private void Start()
    {
        //PL = new List<Object>();
        //PG = new List<Object>();
        //DL = new List<Object>();
        //DG = new List<Object>();

        maps = Resources.LoadAll("Mapy", typeof(Object));   // Patrz opis tablicy "maps" - to właśnia ta funkcja zczytuje
        SpawnFirstRoom();
    }


    void SpawnFirstRoom()
    {
        List<Object> temp = new List<Object>();
        foreach(var o in maps)
        {
            if (o.name.Contains("PX") || o.name.Contains("DX"))
                temp.Add(o);
        }
        int rand = Random.Range(0, temp.Count);
        Instantiate(temp[rand]);
    }





    public List<Object> GetCompatibleRoomsTo(RoomType x)
    {
        List<Object> list = new List<Object>();     // tymczasowa lista, jest uzupełniana odpowiednimi obiektami i zwracana jako zakończenie działania metody
        switch(x)
        {
            case RoomType.PL:   // PL

                //if (PL.Count != 0)
                //    return PL;

                foreach(var o in maps)
                    if (o.name.Contains("DL") || o.name.Contains("XL")) //  szukanie kompatybilnych pokoi wśród tych z tablicy "maps" (Dobrane na logikę)   analogicznie casy w dół
                        list.Add(o);    // kompatybilny? to dodaj do listy

                //PL = list;
                return list;

                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 

            case RoomType.PG:   // PG

                //if (PG.Count != 0)
                //    return PG;

                foreach (var o in maps)
                    if (o.name.Contains("DL") || o.name.Contains("XL"))
                        list.Add(o);

                //PG = list;
                return list;

                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            case RoomType.PX:   // PX
                foreach (var o in maps)
                    if (o.name.Contains("DL") || o.name.Contains("XL"))
                        list.Add(o);

                return list;

                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            case RoomType.DL:   // DL

                //if (DL.Count != 0)
                //    return DL;

                foreach (var o in maps)
                    if (o.name.Contains("PG") || o.name.Contains("DG") || o.name.Contains("XG"))
                        list.Add(o);

                //DL = list;
                return list;

                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            case RoomType.DG:   // DG

                //if (DG.Count != 0)
                //    return DG;

                foreach (var o in maps)
                    if (o.name.Contains("PG") || o.name.Contains("DG") || o.name.Contains("XG"))
                        list.Add(o);

                //DG = list;
                return list;

                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            case RoomType.DX:   // DX

                foreach (var o in maps)
                    if (o.name.Contains("PG") || o.name.Contains("DG") || o.name.Contains("XG"))
                        list.Add(o);

                return list;

                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            default:    // Gdyby coś poszło nie tak, wyrzucenie wyjątku
                throw new System.Exception("GetCompatibleRoom() błędne przypisanie pokoju !");
        }
    }


}
