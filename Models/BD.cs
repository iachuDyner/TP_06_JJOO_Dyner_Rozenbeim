using System.Data.SqlClient;
using Dapper;

public static class BD
{

    public static void AgregarDeportista(Deportista dep)
    {
        string sql = "Insert into Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) Values (@Apellido, @Nombre, @FechaNacimiento, @Foto, @IdPais, @IdDeporte)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pApellido = dep.Apellido, pNombre = dep.Nombre, pFechaNacimiento = dep.FechaNacimiento, pFoto = dep.Foto, pIdPais = dep.IdPais, pIdDeporte = dep.IdDeporte });
        }

    }
    public static void EliminarDeportista(int idDeportista)
    {

        int RegistrosEliminados = 0;
        string sql = "DELETE FROM Deportistas WHERE IdDeportista = @IdDeportista";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            RegistrosEliminados = db.Execute(sql, new { deportista = idDeportista });
        }
    }
    public static Deporte VerInfoDeporte(int idDeporte)
    {
        Deporte MiDeporte = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportes WHERE IdDeporte = @IdDeporte";
            MiDeporte = db.QueryFirstOrDefault<Deporte>(sql, new { pIdDeporte = idDeporte });
        }
        return MiDeporte;
    }
    public static Pais VerInfoPais(int idPais)
    {
        Pais MiPais = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Paises WHERE IdPais = @IdPais";
            MiPais = db.QueryFirstOrDefault<Pais>(sql, new { pIdPais = idPais });
        }
        return MiPais;
    }
    public static Deportista VerInfoDeportista(int idDeportista)
    {
        Deportista MiDeportista = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportistas  WHERE IdDeportista = @IdDeportista";
            MiDeportista = db.QueryFirstOrDefault<Deportista>(sql, new { pIdDeportista = idDeportista });
        }
        return MiDeportista;
    }
    public static List<Pais> ListarPaises()
    {
        List<Pais> ListadoPaises = new List<Pais>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Paises";
            ListadoPaises = db.Query<Pais>(sql).ToList();
        }
        return ListadoPaises;
    }
    public static List<Deporte> ListarDeporte(){
        List<Deporte> ListadoDeportes = new List<Deporte>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportes";
            ListadoDeportes = db.Query<Deporte>(sql).ToList();
        }
        return ListadoDeportes;
    }
    public static List<Deportista> ListarDeportistasDeporte(int idDeporte)
    {
        List<Deportista> ListadoDeportistasDeporte = new List<Deportista>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportista WHERE idDeporte = @IdDeporte";
            ListadoDeportistasDeporte = db.Query<Deportista>(sql).ToList();
        }
        return ListadoDeportistasDeporte;
    }
    public static List<Deportista> ListarDeportistasPais(int idPais)
    {
        List<Deportista> ListadoDeportistasPais = new List<Deportista>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportista WHERE IdPais = @IdPais";
            ListadoDeportistasPais = db.Query<Deportista>(sql).ToList();
        }
        return ListadoDeportistasPais;
    }
}