using System;
using HeldNodig.Entities.Common;
using HeldNodig.Enums;

namespace HeldNodig.Entities.HelpRequest
{
    public class HelpRequest: IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }
    }
}