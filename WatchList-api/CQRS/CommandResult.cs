using System;

namespace WatchList_api.CQRS
{
    public struct CommandResult
    {
        public CommandResult(bool success, Guid? id)
        {
            Success = success;
            Id = id;
        }
        public bool Success { get; set; }
        public Guid? Id { get; set; }
    }
}
