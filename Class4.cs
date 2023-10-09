using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Satbayev.DAL
{
    public class RepositoryClient
    {
        public string Path;
        public RepositoryClient(string Path) { 
            this.Path = Path;
        }
        public bool CreateClient(Client client)
        {
            try { 
                using (var db = new LiteDatabase(Path))
                {
                    var clients = db.GetCollection<Client>("Client");
                    clients.Insert(client);
                }
            }
            catch(Exception) 
            { 
                return false;
            }
            return true;
        }
        public Client GetClient(string Email, string Password)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    return db.GetCollection<Client>("Client").FindAll().First(f => f.Email == Email & f.Password == Password);
                }
            }
            catch (Exception) { 
                return null;
            }
        }
        public Client GetClient(int clientid)
        {
            using (var db = new LiteDatabase(Path))
            {
                return db.GetCollection<Client>("Client").FindAll().First(f => f.Id == clientid);
            }
        }
    }


}
