//
// using UnityEngine;
// using System.IO;
// using System.Runtime.Serialization.Formatters.Binary;
//
// public static class BuildingSaver
// {
//     public static void SaveBuilding(Building building,string name)
//     {
//         BinaryFormatter formatter = new BinaryFormatter();
//         string path =  Application.persistentDataPath + "/Buildings/" + name + ".p" ;
//         FileStream stream = new FileStream(path, FileMode.Create);
//
//         BuildingData data = new BuildingData(building);
//         formatter.Serialize(stream,data);
//         stream.Close();
//     }
//
//     public static BuildingData LoadBuilding(string name)
//     {
//         string path =  Application.persistentDataPath + "/Buildings/" + name + ".p" ;
//         if (File.Exists(path))
//         {
//             BinaryFormatter formatter = new BinaryFormatter();
//             FileStream stream = new FileStream(path, FileMode.Open);
//             BuildingData data = (BuildingData) formatter.Deserialize(stream);
//             stream.Close();
//             return data;
//         } 
//         else
//         {
//             Debug.LogError("File not found in " + path);
//             return null;
//         }
//     }
//     
// }
