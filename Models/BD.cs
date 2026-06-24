namespace TurnosPeluqueria_EJ06.Models;

using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using TurnosPeluqueria_EJ06.Models;


public class BD
{
    private string _connectionString =
         @"Server=localhost; DataBase=TurnosDB; Integrated Security=True; TrustServerCertificate=True;";

    public  List<Turno> ObtenerTurnos()
    {
        List<Turno> turnos = new List<Turno>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Turnos ORDER BY FechaHora ASC";
            turnos = connection.Query<Turno>(query).ToList();
        }
        return turnos;
    }

    public void AgregarTurno(Turno t)
    {
        
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Turnos (NombreCliente, Servicio, Estado, FechaHora) VALUES (@NombreCliente, @Servicio, @Estado, @FechaHora )";

          connection.Execute(query, t);

        }



    }


    
    public void CambiarEstado(int id, string nuevoEstado)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Turnos SET estado = @pestado WHERE id = @pid";
             connection.Execute(query, new{pestado = nuevoEstado, pid = id});
        }
     


    }
    public void CambiarFecha(int id, DateTime nuevaFecha)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Turnos SET FechaHora = @pfecha WHERE id = @pid";
             connection.Execute(query, new{pfecha = nuevaFecha, pid = id});
        }
     


    }
    
}