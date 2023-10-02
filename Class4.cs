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
        public void CreateClient(client client)
        {
            using (var db = new LiteDatabase(Path))
            {
                var clients = db.GetCollection<client>("Client");
                clients.Insert(client);
            }
        }
        public client GetClient(string Email, string Password)
        {
            using (var db = new LiteDatabase(Path))
            {
                return db.GetCollection<client>("Client").FindAll().First(f => f.Email == Email & f.Password == Password);
            }
        }
        public client GetClient(int clientid)
        {
            using (var db = new LiteDatabase(Path))
            {
                return db.GetCollection<client>("Client").FindAll().First(f => f.Id == clientid);
            }
        }
    }


}
