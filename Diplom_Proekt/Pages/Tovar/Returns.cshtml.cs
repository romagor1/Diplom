using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Diplom_Proekt.Pages.Tovar
{
    public class ReturnsModel : PageModel
    {
		public Tovar TovarInfo = new Tovar();
		public String errorMessage = "";
		public String successMessage = "";
		public void OnGet()
		{
		}

		//public void OnPost()
		//{
		//	TovarInfo.type_of = Request.Form["type_of"];
		//	TovarInfo.count_of = Request.Form["count_of"];
		//	TovarInfo.postavka = Request.Form["postavka"];

		//	if (TovarInfo.type_of.Length == 0 || TovarInfo.count_of.Length == 0 ||
		//		TovarInfo.postavka.Length == 0)
		//	{
		//		errorMessage = "Заполнены не все поля";
		//		return;
		//	}
		//	//Сохраняет новый товар в базу данных
		//	try
		//	{
		//		String connectionString = "Data Source=DESKTOP-0VAD88R;Initial Catalog=Diplom;Integrated Security=True";
		//		using (SqlConnection connection = new SqlConnection(connectionString))
		//		{
		//			connection.Open();
		//			String sql = "INSERT INTO Returns_Tovar " +
		//						 "(type_of, count_of, postavka) VALUES" +
		//						 "(@type_of, @count_of, @postavka);";
		//			using (SqlCommand command = new SqlCommand(sql, connection))
		//			{
		//				command.Parameters.AddWithValue("@type_of", TovarInfo.type_of);
		//				command.Parameters.AddWithValue("@count_of", TovarInfo.count_of);
		//				command.Parameters.AddWithValue("@postavka", TovarInfo.postavka);

		//				command.ExecuteNonQuery();
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		errorMessage = ex.Message;
		//		return;
		//	}

		//	TovarInfo.type_of = ""; TovarInfo.count_of = ""; TovarInfo.postavka = "";
		//	successMessage = "Добавлен новый товар";

		//	Response.Redirect("/Tovar/Index");
		//}
	}
}
