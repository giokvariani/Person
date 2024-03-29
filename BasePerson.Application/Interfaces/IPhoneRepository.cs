﻿using BasePerson.Model.BusinessObjects;

namespace BasePerson.Application.Interfaces
{
    public interface IPhoneRepository : IRepository<Phone>
    {
        Task<Phone?> ReadAsync(string number);
    }
}
