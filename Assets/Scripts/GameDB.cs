using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;
public class GameDB : MonoBehaviour
{

    SqlConnection connection;
    SqlCommand command;

    private void Start()
    {
        Open();
        LevelInfoInsert(2, 2, 3, 4);
        Close();
    }

    public void Open()
    {
        connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameDB;Integrated Security=True");
        connection.Open();

    }
    public void Close()
    {
        connection.Close();
    }
    public void LevelInfoInsert(int id_level, int coin = 0, int passage = 0, int death = 0)
    {
        command = new SqlCommand("LevelInfoInsert", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@id", id_level);
        command.Parameters.AddWithValue("@coin", coin);
        command.Parameters.AddWithValue("@passage", passage);
        command.Parameters.AddWithValue("@death", death);
        command.ExecuteScalar();
    }

}

