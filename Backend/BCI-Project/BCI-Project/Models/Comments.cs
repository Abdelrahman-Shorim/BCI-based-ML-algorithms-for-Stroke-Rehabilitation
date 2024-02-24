﻿namespace BCI_Project.Models
{
    public class Comments : BaseModel
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }

        public DateTime Date { get; set; }



        public User Patient { get; set; }
        public User Doctor { get; set; }
    }
}
