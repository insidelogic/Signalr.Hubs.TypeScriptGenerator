﻿using System;
using System.IO;
using System.Reflection;
using RazorEngine;
using RazorEngine.Templating;
using SignalrTypescriptGenerator.Models;

namespace SignalrTypescriptGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("SignalrTypescriptGenerator.exe [path to assembly or exe]");
				Environment.Exit(1);
			}

			try
			{
				var signalrHelper = new SignalrHubinator(args[0]);

				var model = new TypesModel();
				model.Hubs = signalrHelper.GetHubs();
				model.ServiceContracts = signalrHelper.GetServiceContracts();
				model.Clients = signalrHelper.GetClients();
				model.DataContracts = signalrHelper.GetDataContracts();
				model.Enums = signalrHelper.GetEnums();

				string template = ReadEmbeddedFile("template.cshtml");

				string result = Engine.IsolatedRazor.RunCompile(template, "templateKey", null, model);

				Console.WriteLine(result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				Environment.Exit(1);
			}
		}

		static string ReadEmbeddedFile(string file)
		{
			string resourcePath = string.Format("{0}.{1}", typeof(Program).Namespace, file);

			Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
			if (stream == null)
				throw new InvalidOperationException(string.Format("Unable to find '{0}' as an embedded resource", resourcePath));

			string textContent = "";
			using (StreamReader reader = new StreamReader(stream))
			{
				textContent = reader.ReadToEnd();
			}

			return textContent;
		}
	}
}
