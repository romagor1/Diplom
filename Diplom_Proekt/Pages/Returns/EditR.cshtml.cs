using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Diplom_Proekt.Pages.Returns
{
    public class EditRModel : PageModel
    {
		public Tovar TovarInfo = new Tovar();
		public String errorMessage = "";
		public String successMessage = "";
		public void OnGet()
		{
			String id = Request.Query["id"];

			try
			{
				String connectionString = "Data Source=DESKTOP-0VAD88R;Initial Catalog=Diplom;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "SELECT * FROM Returns_Tovar WHERE id=@id";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("id", id);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								TovarInfo.id = "" + reader.GetInt32(0);
								TovarInfo.type_of = reader.GetString(1);
								TovarInfo.count_of = "" + reader.GetInt32(2);
								TovarInfo.postavka = reader.GetString(3);
							}
						}
					}

				}
			}
			catch (Exception ex)
			{
				errorMessage = ex.Message;
			}
		}
		public void OnPost()
		{
			TovarInfo.id = Request.Form["id"];
			TovarInfo.type_of = Request.Form["type_of"];
			TovarInfo.count_of = Request.Form["count_of"];
			TovarInfo.postavka = Request.Form["postavka"];

			if (TovarInfo.type_of.Length == 0 || TovarInfo.count_of.Length == 0 ||
				TovarInfo.postavka.Length == 0)
			{
				errorMessage = "Заполнены не все поля";
				return;
			}

			try
			{
				String connectionString = "Data Source=DESKTOP-0VAD88R;Initial Catalog=Diplom;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "UPDATE Returns_Tovar " +
								 "SET type_of=@type_of, count_of=@count_of, postavka=@postavka " +
								 "WHERE id = @id";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@type_of", TovarInfo.type_of);
						command.Parameters.AddWithValue("@count_of", TovarInfo.count_of);
						command.Parameters.AddWithValue("@postavka", TovarInfo.postavka);
						command.Parameters.AddWithValue("@id", TovarInfo.id);

						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				errorMessage = ex.Message;
				return;
			}

			TovarInfo.type_of = ""; TovarInfo.count_of = ""; TovarInfo.postavka = "";
			successMessage = "Добавлен новый товар";

			Response.Redirect("/Returns/IndexR");
		}
	}
}
