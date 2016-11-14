using System;
using System.Runtime.Serialization;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.SampleUsage.DataContracts
{
	[DataContract]
	public class OtherSomethingDto
	{
		[DataMember(IsRequired = true)]
		public string RequiredString { get; set; }

		[DataMember]
		public DateTime OptionalDateTime { get; set; }

		[DataMember (IsRequired = false)]
		public InnerSomethingDto OptionalInnerSomething { get; set; }

		[DataMember (IsRequired = true)]
		public InnerSomethingDto RequiredInnerSomething { get; set; }
	}
}