using CsvHelper;
using Model.Business;
using ModelLayer.model.data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    class DAOclients
    {
        private Dbal _dbal;

        public DAOclients(Dbal dbal)
        {
            _dbal = dbal;
        }
        public void Insert(Clients unClient)
        {
            string query = " Client VALUES " + "(" + unClient.getIdClient() + ",'" + unClient.getNomClient().Replace("'", "''") + unClient.getPrenomClient().Replace("'", "''") + unClient.getPhotoClient().Replace("'", "''") + unClient.getAdresseClient().Replace("'", "''") + unClient.getDateNaissanceClient() + unClient.getEmailClient().Replace("'", "''") + unClient.getTelPortableCLient().Replace("'", "''")+"');";
            this._dbal.Insert(query);
        }
        public void Update(Clients unClient)
        {
            string query = "Client SET id = " + unClient.getIdClient() 
                + ", nom = '" + unClient.getNomClient().Replace("'", "''")
                + "prenom = '" + unClient.getPrenomClient().Replace("'", "''")
                + "photo = '" + unClient.getPhotoClient().Replace("'", "''"
                + "adresse ='" + unClient.getAdresseClient().Replace("'", "''") 
                + "DateNaissance ='" + unClient.getDateNaissanceClient() 
                + "Email = '" + unClient.getEmailClient().Replace("'", "''") 
                + "TelephonePortable = '" + unClient.getTelPortableCLient().Replace("'", "''") 
                + "' WHERE id = " + unClient.getIdClient() + " ;");
            this._dbal.Update(query);
        }

        public void Delete(Clients unClient)
        {
            string query = "Client WHERE ID = " + unClient.getIdClient() + ";";
            this._dbal.Delete(query);
        }
        public void InsertByFile(string Chemin)
        {
            using (var reader = new StreamReader(Chemin))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                var record = new Clients();
                var records = csv.EnumerateRecords(record);
                foreach (Clients pays in records)
                {
                    Insert(pays);
                }
            }
        }
        //public List<Pays> SelectAll()
        //{
        //    List<Pays> listeAll = new List<Pays>();
        //    foreach (DataRow r in _dbal.SelectAll("Pays").Rows)
        //    {
        //        listeAll.Add(new Pays((int)r["id"], (string)r["nom"]));
        //    }
        //    return listeAll;
        //}
        //public Pays SelectByName(string nom)
        //{
        //    DataRow r = _dbal.SelectByField("Pays", "nomPays like '" + nom + "'").Rows[0];
        //    return new Pays((int)r["ID"], (string)r["nomPays"]);
        //}
        //public Pays SelectById(int id)
        //{
        //    DataRow r = _dbal.SelectById("Pays", id);
        //    return new Pays((int)r["ID"], (string)r["nomPays"]);
        //}
    }
}
