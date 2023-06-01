using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Diplom_Proekt.Pages.Returns
{
    public class IndexRModel : PageModel
    {
		public List<Tovar> listTovar = new List<Tovar>();

		public void OnGet()
		{
			try
			{
				String connectionString = "Data Source=DESKTOP-0VAD88R;Initial Catalog=Diplom;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "SELECT * FROM Returns_Tovar";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Tovar Tovar = new Tovar();
								Tovar.id = "" + reader.GetInt32(0);
								Tovar.type_of = reader.GetString(1);
								Tovar.count_of = "" + reader.GetInt32(2);
								Tovar.postavka = reader.GetString(3);

								listTovar.Add(Tovar);
							}
						}
					}

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Исключение: " + ex.ToString());
			}
		}
	}
	public class Tovar
	{
		public String id;
		public String type_of;
		public String count_of;
		public String postavka;
	}
}
