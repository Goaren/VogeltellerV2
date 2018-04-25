using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Waarneming
    {
        private int id;
        private double x;
        private double y;
        private DateTime date;
        private int accountId;
        private int gebiedId;
        private int dierId;
        private int soortWaarnemingId;

        public int Id { get { return id; } set { id = value; } }
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public int AccountId { get { return accountId; } set { accountId = value; } }
        public int GebiedId { get { return gebiedId; } set { gebiedId = value; } }
        public int DierId { get { return dierId; } set { dierId = value; } }
        public int SoortWaarnemingId { get { return soortWaarnemingId; } set { soortWaarnemingId = value; } }

        public Waarneming(int id, double x, double y, DateTime date, int accountId, int gebiedId, int dierId, int soortWaarnemingId)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.date = date;
            this.accountId = accountId;
            this.gebiedId = gebiedId;
            this.dierId = dierId;
            this.soortWaarnemingId = soortWaarnemingId;
        }
    }
}
