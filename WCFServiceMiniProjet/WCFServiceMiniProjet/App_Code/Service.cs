using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service" dans le code, le fichier svc et le fichier de configuration.
public class Service : IService
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString);


    public int DeleteStudent(int id)
    {
        SqlCommand cmd = new SqlCommand("delete from Student where id = @id ;", con);
        con.Open();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();

        return 1;
    }

    public string GetAllStudents()
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("select * from Student ", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        List<Student> rows = new List<Student>();
        
        foreach (DataRow dr in dt.Rows)
        {
            Student row = new Student();
            
            foreach (DataColumn col in dt.Columns)
            {
                if(col.ColumnName == "Id") row.id = (int)dr[col];
                if (col.ColumnName == "cin") row.cin = (string)dr[col];
                if (col.ColumnName == "nom") row.nom = (string)dr[col];
                if (col.ColumnName == "prenom") row.prenom = (string)dr[col];
                if (col.ColumnName == "email") row.email = (string)dr[col];
                if (col.ColumnName == "filiere") row.filiere = (string)dr[col];
                if (col.ColumnName == "tel") row.tel = (string)dr[col];
            }
            rows.Add(row);
        }

        string jsonString = JsonSerializer.Serialize(rows);  // type list<Student>

        con.Close();
        return jsonString;
    }

    public string GetStudentById(int id)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("select * from Student where id = "+id+" ;", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        List<Student> rows = new List<Student>();

        foreach (DataRow dr in dt.Rows)
        {
            Student row = new Student();

            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "Id") row.id = (int)dr[col];
                if (col.ColumnName == "cin") row.cin = (string)dr[col];
                if (col.ColumnName == "nom") row.nom = (string)dr[col];
                if (col.ColumnName == "prenom") row.prenom = (string)dr[col];
                if (col.ColumnName == "email") row.email = (string)dr[col];
                if (col.ColumnName == "filiere") row.filiere = (string)dr[col];
                if (col.ColumnName == "tel") row.tel = (string)dr[col];
            }
            rows.Add(row);
        }

        if (dt == null)
        {
            return "null";
        }else if (dt != null)
        {
            if (dt.Rows.Count == 0)
            {
                return "null";
            }
        }

        string jsonString = JsonSerializer.Serialize(rows[0]); // type Student

        con.Close();
        return jsonString;
    }

    public int UpdateStudent(int id, string cin, string nom, string prenom, string email, string filiere, string tel)
    {
        SqlCommand cmd = new SqlCommand("update Student set cin = @cin , nom = @nom , prenom = @prenom , email = @email , filiere = @filiere , tel = @tel where id = @id ;", con);
        con.Open();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@cin", cin);
        cmd.Parameters.AddWithValue("@nom", nom);
        cmd.Parameters.AddWithValue("@prenom", prenom);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@filiere", filiere);
        cmd.Parameters.AddWithValue("@tel", tel);
        cmd.ExecuteNonQuery();
        con.Close();

        return 1;
    }


    public int AddStudent(string cin, string nom, string prenom, string email, string filiere, string tel)
    {
        
          SqlCommand  cmd = new SqlCommand("insert into Student(cin,nom,prenom,email,filiere,tel) values(@cin,@nom,@prenom,@email,@filiere,@tel)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@cin", cin);
        cmd.Parameters.AddWithValue("@nom", nom);
        cmd.Parameters.AddWithValue("@prenom", prenom);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@filiere", filiere);
        cmd.Parameters.AddWithValue("@tel", tel);
        cmd.ExecuteNonQuery();
            con.Close();

        return 1;
    }

    public int AddUser(string username, string HashedPassword)
    {
        SqlCommand cmd = new SqlCommand("insert into dbo.[User](username,password) values(@username,@password)", con);
        con.Open();
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", HashedPassword);
        cmd.ExecuteNonQuery();
        con.Close();

        return 1;
    }

    public int UpdateUser(int id, string username, string HashedPassword)
    {
        SqlCommand cmd = new SqlCommand("update dbo.[User] set username = @username , password = @HashedPassword where id = @id ;", con);

        con.Open();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@HashedPassword", HashedPassword);
        cmd.ExecuteNonQuery();
        con.Close();

        return 1;
    }

    public int DeleteUser(int id)
    {
        SqlCommand cmd = new SqlCommand("delete from dbo.[User] where id = @id ;", con);
        con.Open();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();

        return 1;
    }

    public string CheckUser(string username, string HashedPassword)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("select * from dbo.[User] where username = %username and password = %password ;", con);
        sda.SelectCommand.Parameters.AddWithValue("username", username);
        sda.SelectCommand.Parameters.AddWithValue("password", HashedPassword);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        List<User> rows = new List<User>();
        
        foreach (DataRow dr in dt.Rows)
        {
            User row = new User();

            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "Id") row.id = (int)dr[col];
                if (col.ColumnName == "username") row.Username = (string)dr[col];
                if (col.ColumnName == "password") row.password = (string)dr[col];
                
            }
            rows.Add(row);
        }

        if (dt == null)
        {
            return "null";
        }
        else if (dt != null)
        {
            if (dt.Rows.Count == 0)
            {
                return "null";
            }
        }
        
        string jsonString = JsonSerializer.Serialize(rows[0]); // type User

        con.Close();
        return jsonString;
    }
}
