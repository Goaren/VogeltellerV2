using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        private int vogelId;
        private int soortId;
        private int zoogdierId;

        public int Id { get { return id; } set { id = value; } }
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public int GebiedId { get { return gebiedId; } set { gebiedId = value; } }
        public int AccountId { get { return accountId; } set { accountId = value; } }
       
        public int VogelId { get { return vogelId; } set { vogelId = value; } }
        public int SoortId { get { return soortId; } set { soortId = value; } }
        public int ZoogdierId { get { return zoogdierId; } set { zoogdierId = value; } }
        public Waarneming(int id, double x, double y, DateTime date, int gebiedId,int accountId , int vogelId, int soortId, int zoogdierId)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            this.id = id;
            this.x = x;
            this.y = y;
            this.date = date;
            this.gebiedId = gebiedId;
            this.accountId = accountId;
            this.vogelId = vogelId;
            this.soortId = soortId;
            this.zoogdierId = zoogdierId;
        }
        public Waarneming(int id, double x, double y, DateTime date, int gebiedId, int accountId, int soortId, int zoogdierId)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            this.id = id;
            this.x = x;
            this.y = y;
            this.date = date;
            this.gebiedId = gebiedId;
            this.accountId = accountId;
            this.soortId = soortId;
            this.zoogdierId = zoogdierId;
        }

        public Waarneming(DateTime date, int id, double x, double y, int gebiedId, int accountId, int vogelId, int soortId)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            this.id = id;
            this.x = x;
            this.y = y;
            this.date = date;
            this.gebiedId = gebiedId;
            this.accountId = accountId;
            this.vogelId = vogelId;
            this.soortId = soortId;
        }
        public Waarneming()
        {

        }
    }
}
