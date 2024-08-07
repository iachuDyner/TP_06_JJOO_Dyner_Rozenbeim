using System.Data.SqlClient;
using Dapper;

public static class BD{

 static void AgregarDeportista (Deportista dep){
string sql = "Insert into Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) Values (@Apellido, @Nombre, @FechaNacimiento, @Foto, @IdPais, @IdDeporte)";
using(SqlConnection db = new SqlConnection(_connectionString))
{
    db.Execute(sql, new {pApellido = dep.Apellido ,pNombre = dep.Nombre, pFechaNacimiento = dep.FechaNacimiento, pFoto = dep.Foto, pIdPais= dep.IdPais, pIdDeporte = dep.IdDeporte});
}

}
 static void EliminarDeportista (int idDeportista){

    int RegistrosEliminados = 0;
    string sql = "DELETE FROM Deportistas WHERE IdDeportista = @IdDeportista";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        RegistrosEliminados = db.Execute(sql, new {deportista = idDeportista});
    }
}
 static Deporte VerInfoDeporte (int idDeporte){
    Deporte MiDeporte = null;
    using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Deportes WHERE IdDeporte = @IdDeporte";
        MiDeporte = db.QueryFirstOrDefault<Deporte>(sql, new {pIdDeporte = idDeporte});
    }
    return MiDeporte;
}
 static Pais VerInfoPais (int idPais){
    Pais MiPais = null;
    using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Paises WHERE IdPais = @IdPais";
        MiPais = db.QueryFirstOrDefault<Deporte>(sql, new {pIdPais = idPais});
    }
    return MiPais;
}
 static Deportista VerInfoDeportista (int idDeportista){
    Deportista MiDeportista = null;
    using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Deportistas  WHERE IdDeportista = @IdDeportista";
        MiDeportista = db.QueryFirstOrDefault<Deporte>(sql, new {pIdDeportista = idDeportista});
    }
    return MiDeportista;
}
 static void ListarPaises (){
    List<string> ListadoPaises = new List<string>();
    using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql "SELECT * FROM Paises";
        ListadoPaises = db.Query<Pais>(sql).ToList();
        
    }
}
 static void ListarDeportistasDeporte (int idDeporte){
}
 static void ListarDeportistasPais (int idPais){
}
}