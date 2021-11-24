using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService" à la fois dans le code et le fichier de configuration.
[ServiceContract]
public interface IService
{



	// TODO: ajoutez vos opérations de service ici

	[OperationContract]
	int AddStudent(string cin, string nom, string prenom, string email, string filiere, string tel);

	[OperationContract]
	int UpdateStudent(int id, string cin, string nom, string prenom, string email, string filiere, string tel);

	[OperationContract]
	int DeleteStudent(int id);

	[OperationContract]
	string GetAllStudents();

	[OperationContract]
	string GetStudentById(int id);

	[OperationContract]
	int AddUser(string username, string HashedPassword);

	[OperationContract]
	int UpdateUser(int id, string username, string HashedPassword);

	[OperationContract]
	int DeleteUser(int id);

	[OperationContract]
	string CheckUser(string username, string HashedPassword);




}

// Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
