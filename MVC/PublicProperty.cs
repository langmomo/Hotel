using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MVC.Models;
using Newtonsoft.Json;

namespace MVCApp
{
	public class PublicProperty
	{
		static HttpClient client;
		public static HttpClient GetClient()
		{
			if (client == null)
			{
				client = new HttpClient();
				client.BaseAddress = new Uri("http://localhost:57267/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/json"));
			}
			return client;
		}
	
	}
}
