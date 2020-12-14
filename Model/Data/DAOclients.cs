using CsvHelper;
using Model.Business;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class DAOclients
    {
        private Dbal _dbal;

        public DAOclients(Dbal dbal)
        {
            _dbal = dbal;
        }
        public void Insert(Clients unClient)
        {
            string query = " Client (id,nom,prenom,photo,adresse,DateNaissance,Email,TelephonePortable,Credit) VALUES (" + unClient.getIdClient()
                + ",'" + unClient.getNomClient().Replace("'", "''") + "'"
                + ",'" + unClient.getPrenomClient().Replace("'", "''") + "'"
                + ",'" + unClient.getPhotoClient().Replace("'", "''") + "'"
                + ",'" + unClient.getAdresseClient().Replace("'", "''") + "'"
                + ",'" + unClient.getDateNaissanceClient().ToString("yyyy-MM-dd") + "'"
                + ",'" + unClient.getEmailClient().Replace("'", "''") + "'"
                + ",'" + unClient.getTelPortableCLient().Replace("'", "''") + "'"
                + ",'" + unClient.getCreditClient()+"');";
            
            this._dbal.Insert(query);
        }
        public void Update(Clients unClient)
        {
            string query = "Client SET id = " + unClient.getIdClient()
                + ", nom = '" + unClient.getNomClient().Replace("'", "''") + "'"
                + ", prenom = '" + unClient.getPrenomClient().Replace("'", "''") + "'"
                + ", photo = '" + unClient.getPhotoClient().Replace("'", "''") + "'"
                + ", adresse ='" + unClient.getAdresseClient().Replace("'", "''") + "'"
                + ", DateNaissance ='" + unClient.getDateNaissanceClient().ToString("yyyy-MM-dd") + "'"
                + ", Email = '" + unClient.getEmailClient().Replace("'", "''") + "'"
                + ", TelephonePortable = '" + unClient.getTelPortableCLient().Replace("'", "''") + "'"
                + ", Credit = " + unClient.getCreditClient()
                + "' WHERE id = " + unClient.getIdClient() + " ;";
            this._dbal.Update(query);
        }

        public void Delete(Clients unClient)
        {
            string query = "Client WHERE ID = " + unClient.getIdClient() + ";";
            this._dbal.Delete(query);
        }

        public List<Clients> SelectAll()
        {
            List<Clients> listeAll = new List<Clients>();
            foreach (DataRow r in _dbal.SelectAll("Client").Rows)
            {
                listeAll.Add(new Clients
                    ((int)r["id"],
                    (string)r["nom"],
                    (string)r["prenom"],
                    (string)r["photo"],
                    (string)r["adresse"],
                    (DateTime)r["DateNaissance"],
                    (string)r["Email"],
                    (string)r["TelephonePortable"],
                    (double)r["Credit"]));
            }
            return listeAll;
        }
        public Clients SelectByName(string nom)
        {
            DataRow r = _dbal.SelectByField("Client", "nom like '" + nom + "'").Rows[0];
            return new Clients
                ((int)r["id"],
                (string)r["nom"],
                (string)r["prenom"],
                (string)r["photo"],
                (string)r["adresse"],
                (DateTime)r["DateNaissance"],
                (string)r["Email"],
                (string)r["TelephonePortable"],
                (double)r["Credit"]);
        }
        public Clients SelectById(int id)
        {
            DataRow r = _dbal.SelectById("Client", id);
            return new Clients((int)r["id"],
                (string)r["nom"],
                (string)r["prenom"],
                (string)r["photo"],
                (string)r["adresse"],
                (DateTime)r["DateNaissance"],
                (string)r["Email"],
                (string)r["TelephonePortable"],
                (double)r["Credit"]);
        }
    }
}
