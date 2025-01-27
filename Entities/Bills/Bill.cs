

using EntitiesInterface.Bills;
using EntitiesInterface.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Bills
{
    [Serializable]
    public class Bill : IBill, ISerializable
    {
        public int IdBill { get; set; }
        public IUser Client { get; set; }
        public /*ICollaborator*/object Collaborator { get; set; }
        public DateTime DateBill { get; set; }
        public DateTime WarrantyDate { get; set; }
        public int Iva { get; set; }
        public int TotalAmount { get; set; }
        public bool IsEnabled { get; set; }

        public Bill() { }

        public Bill(IBill bill)
        {
            IdBill = bill.IdBill;
            Client = bill.Client;
            Collaborator = bill.Collaborator;
            DateBill = bill.DateBill;
            WarrantyDate = bill.WarrantyDate;
            Iva = bill.Iva;
            TotalAmount = bill.TotalAmount;
            IsEnabled = bill.IsEnabled;
        }

        public Bill(SerializationInfo info, StreamingContext context)
        {
            IdBill = info.GetInt32("IdBill");
            Client = (IUser)info.GetValue("Client", typeof(IUser));
            Collaborator = (/*ICollaborator*/ object)info.GetValue("Collaborator", typeof(/*ICollaborator*/object));
            DateBill = (DateTime)info.GetValue("DateBill", typeof(DateTime));
            WarrantyDate = (DateTime)info.GetValue("WarrantyDate", typeof(DateTime));
            Iva = info.GetInt32("Iva");
            TotalAmount = info.GetInt32("TotalAmount");
            IsEnabled = info.GetBoolean("IsEnabled");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IdBill", IdBill);
            info.AddValue("Client", Client);
            info.AddValue("Collaborator", Collaborator);
            info.AddValue("DateBill", DateBill);
            info.AddValue("WarrantyDate", WarrantyDate);
            info.AddValue("Iva", Iva);
            info.AddValue("TotalAmount", TotalAmount);
            info.AddValue("IsEnabled", IsEnabled);
        }
    }
}
