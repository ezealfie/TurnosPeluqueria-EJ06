namespace TurnosPeluqueria_EJ06.Models;

using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using TurnosPeluqueria_EJ06.Models;


public static class BD
{
    private static string _connectionString =
         @"Server=localhost; DataBase=TurnosDB; Integrated Security=True; TrustServerCertificate=True;";

    public static List<Turno> ObtenerTurnos()
    {
        List<Turno> turnos = new List<Turno>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT FechaHora, NombreCliente, Servicio, Estado FROM Turnos ORDER BY FechaHora ASC";
            turnos = connection.Query<Turno>(query).ToList();
        }
        return turnos;
    }

    public static void AgregarTurno(Turno t)
    {
        
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Turnos (NombreCliente, Servicio, Estado, FechaHora) VALUES (@pt)";

          connection.Execute(query, new {pt = t});

        }



    }


    
    public static void CambiarEstado(int id, string nuevoEstado)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Turnos SET estado = '@pestado' WHERE id = @pid";
             connection.Execute(query, new{pestado = nuevoEstado, pid = id});
        }
     


    }
    
}