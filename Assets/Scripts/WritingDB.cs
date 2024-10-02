using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.Networking;

public class WritingDB : MonoBehaviour
{
    // Declaración de variables para la conexión a la base de datos
    [SerializeField] int _highScore = 0, _maxScore = 0;

    string rutaDB;
    string strConexion;
    string filePath;
    string DBFileName = "DBinventario.sqlite";
    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader reader;
    // Método llamado al inicio del script
    void Start()
    {
        // Llama al método para abrir la conexión a la base de datos
        //AbrirDB();
    }

    private void Update()
    {
        _highScore = gameObject.GetComponent<SapoDetectorPoints>().MaxValue;
    }

    // Método para abrir la base de datos
    void AbrirDB()
    {
        _highScore = gameObject.GetComponent<SapoDetectorPoints>().MaxValue;
        Debug.Log("highscore:" + _highScore);

        // Establecer la ruta de la base de datos según la plataforma
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            rutaDB = Application.dataPath + "/StreamingAssets/" + DBFileName;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            rutaDB = Application.dataPath + "/Raw/" + DBFileName;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            rutaDB = "jar:file://" + Application.dataPath + "!/assets/" + DBFileName;
            filePath = Application.persistentDataPath + "/" + DBFileName;
        }

        //Aquí comienza la parte posible a eliminar
        // #UNITY_ANDROID
        UnityWebRequest loadDB = new UnityWebRequest(rutaDB);
        //while (!loadDB.isDone) { }
        //Hasta aquí termina la parte posible a eliminar

        // Crear la cadena de conexión utilizando la biblioteca Mono.Data.Sqlite
        strConexion = "URI=file:" + rutaDB;
        // Inicializar y abrir la conexión a la base de datos SQLite
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();

        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "SELECT * FROM HighScore";
        dbCommand.CommandText = sqlQuery;

        reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            int Id = reader.GetInt32(0);
            int Score = reader.GetInt32(1);

            _maxScore = Score;
            Debug.Log("Max Score:" + _maxScore);
        }

        //IDbConnection dbConnection = CreateAndOpenDatabase();

        if(_highScore > _maxScore)
        {
            string sqlQueryEdit = "INSERT OR REPLACE INTO HighScore";
            IDbCommand dbCommandInsertValues = dbConnection.CreateCommand();
            dbCommandInsertValues.CommandText = sqlQueryEdit + " (Id, Score)" + "VALUES (0, " + _highScore + ")";
            dbCommandInsertValues.ExecuteNonQuery();
        }

        // Cerrar las conexiones y liberar recursos
        reader.Close();
        reader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }

    public void AddData()
    {
        AbrirDB();
    }
}
