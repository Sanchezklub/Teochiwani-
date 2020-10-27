using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeleteSavefile : MonoBehaviour
{
    public void DeleteSave()
    {
        string path = Application.persistentDataPath + "/player.fun";
        File.Delete(path);
    }
}
