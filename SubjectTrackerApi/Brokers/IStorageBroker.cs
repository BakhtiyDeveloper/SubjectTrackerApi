//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using SubjectTrackerApi.Models;

namespace SubjectTrackerApi.Brokers
{
    public interface IStorageBroker
    {
        Task<Subject> InsertSubjectAsync(Subject subject);
    }
}
