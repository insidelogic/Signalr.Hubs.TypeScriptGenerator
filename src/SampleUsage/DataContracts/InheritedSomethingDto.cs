﻿using System.Runtime.Serialization;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.SampleUsage.DataContracts
{
    [DataContract]
    public class InheritedSomethingDto : SomethingDto
    {
        [DataMember]
        public int OptionalInteger { get; set; }
    }
}