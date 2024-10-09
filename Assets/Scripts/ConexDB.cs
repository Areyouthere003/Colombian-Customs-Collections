/*using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine.Networking;

public class ConexDB : MonoBehaviour
{
    // Declaración de variables para la conexión a la base de datos
    [SerializeField] HighScore highScore;
    [SerializeField] TextMeshProUGUI _textScore;
    [SerializeField] int _highScore = 0, _highValue = 0;

    string rutaDB;
    string strConexion;
    string DBFileName = "DBinventario.sqlite";
    string filePath;
    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader reader;
    // Método llamado al inicio del script
    void Start()
    {
        _highValue = highScore.HighValue;
        // Llama al método para abrir la conexión a la base de datos
        AbrirDB();
    }

    private void Update()
    {
    }
    // Método para abrir la base de datos
    void AbrirDB()
    {
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
        // Crear el comando de la base de datos y establecer la consulta SQL
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "SELECT * FROM HighScore";
        dbCommand.CommandText = sqlQuery;
        // Ejecutar la consulta y obtener un lector para leer los resultados
        reader = dbCommand.ExecuteReader();
        while (reader.Read())
        {
            // Obtener los valores de la fila
            int Id = reader.GetInt32(0);
            int Score = reader.GetInt32(1);

            _highScore = Score;
            // Mostrar la información en la consola de Unity
            //Debug.Log(Id + " - " + Score);
        }

        if (_highValue > _highScore)
        {
            _highScore = _highValue;
            _textScore.text = _highScore.ToString();
        }
        else
        {
            _highValue = _highScore;
            _textScore.text = _highValue.ToString();
        }
        // Cerrar las conexiones y liberar recursos
        reader.Close();
        reader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
}
*/