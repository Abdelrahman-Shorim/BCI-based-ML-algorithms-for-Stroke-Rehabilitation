﻿using Microsoft.AspNetCore.Identity;

namespace BCI_Project.Models
{
    public class User :IdentityUser
    {
        public bool IsDeleted { get; set; }
        public ICollection<Comments> CommentsPatients { get; set; }
        public ICollection<Comments> CommentsDoctors { get; set; }

        public ICollection<DrPatients> DrPatientsPatients { get; set; }
        public ICollection<DrPatients> DrPatientsDoctors { get; set; }

        public ICollection<Game> GamePatients { get; set; }

        public ICollection<SignalsAdaptation> SignalsAdaptationPatients { get; set; }

        
        public ICollection<RoleAttributeValue> RoleAttributeValues { get; set; }


    }
}
