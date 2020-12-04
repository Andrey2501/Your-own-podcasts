﻿using Contracts;
using Entities;
using Entities.Models;
using Entities.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Subscription> FindByUser(SubscriptionParameters parameters)
        {
            var subscription = FindByCondition(s => s.UserId == parameters.UserId);

            return PagedList<Subscription>.ToPagedList(subscription.OrderBy(s => s.SubcriptionDate),
                parameters.PageNumber,
                parameters.PageSize);
        }
        public PagedList<Subscription> FindByAuthor(SubscriptionParameters parameters)
        {
            var subscription = FindByCondition(s => s.AuthorId == parameters.UserId);

            return PagedList<Subscription>.ToPagedList(subscription.OrderBy(s => s.SubcriptionDate),
                parameters.PageNumber,
                parameters.PageSize);
        }

    }
}
