﻿using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class ContactDao : IdParseEntityDao<Contact> , IContactDao
    {
        public ContactDao(SegguDataModelContext context)
            : base(context)
        {

        }
    }
}
