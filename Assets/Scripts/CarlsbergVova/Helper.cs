using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public static class Helper {

    public static string ToJson(object obj) {
        return JsonUtility.ToJson(obj);
    }

    public static T FromJson<T>(string json) {
        return JsonUtility.FromJson<T>(json);
    }

   
    public static Texture2D LoadPNG(string filePath) {
        Texture2D tex2d = null;
        byte[] fileData;
        if (File.Exists(filePath)) {
            fileData = File.ReadAllBytes(filePath);
            tex2d = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            tex2d.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex2d;
    }

   

    //public static byte[] X(string filePath) {
    //    byte[] bytes = new byte[3];
    //     if (filePath.Contains("://")) {
    //        UnityWebRequest www = UnityWebRequest.Get(filePath);
    //        yield return www.SendWebRequest();
    //        bytes = www.downloadHandler.data;
    //    } else if (File.Exists(filePath)) {
    //        bytes = File.ReadAllBytes(filePath);
    //    }
    //    return bytes;
    //}

    //public static byte[] GetData(string filePath) {
    //    byte[] fileData = new byte[1];
    //    if (filePath.Contains("://")) {
    //        UnityWebRequest www = UnityWebRequest.Get(filePath);
    //        yield return www.SendWebRequest();
    //        fileData = www.downloadHandler.data;
    //    } else if (File.Exists(filePath)) {
    //        fileData = File.ReadAllBytes(filePath);
    //    }
    //    return fileData;
    //}

   


   

}
