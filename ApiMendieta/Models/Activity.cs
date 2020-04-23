using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiABMCActivity.Models
{
	public class Activity
	{
		public Activity()
		{
		}
		public string Id { get; set; }
		public string Area { get; set; }
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public string Duracion { get; set; }

	}
}
//public string Institucion { get; set; }
//public string Creador { get; set; }
//public string Materiales { get; set; }
//public string Resumen { get; set; }		
//public string Pautas { get; set; }
//public string Naps { get; set; }