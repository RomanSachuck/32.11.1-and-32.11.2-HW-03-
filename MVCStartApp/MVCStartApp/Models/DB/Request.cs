using System;

namespace MVCStartApp.Models.DB
{
    public class Request
    {
        public Guid Id { get; set; }
        public  DateTime Date { get; set; }
        public  string  Url { get; set; }
    }
}