using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Student
/// </summary>
public class Student
{

    public int id{
            get;
            set;
    }
    public string cin
    {
        get;
        set;
    }
    public string nom
    {
        get;
        set;
    }
    public string prenom
    {
        get;
        set;
    }
    public string email
    {
        get;
        set;
    }
    public string filiere
    {
        get;
        set;
    }
    public string tel
    {
        get;
        set;
    }


    public Student()
    { }

    public Student(string cin, string nom, string prenom, string email, string filiere, string tel)
    { this.cin = cin; this.nom = nom; this.prenom = prenom; this.email = email; this.filiere = filiere; this.tel = tel; }

    public Student(int id, string cin, string nom, string prenom, string email, string filiere, string tel)
    { this.id = id; this.cin = cin; this.nom = nom; this.prenom = prenom; this.email = email; this.filiere = filiere; this.tel = tel; }


}

