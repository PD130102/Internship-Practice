using System.Data.SqlClient;
using Internship.Services;
using Internship.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        string? connetionString = null;
        SqlConnection connection;
        SqlCommand command1, command2,command3,command4;
        string? sql1, sql2, sql3, sql4 =null;
        SqlDataReader dataReader1, dataReader2, dataReader3, dataReader4;

        connetionString = "Server = localhost; Database = Internship; Trusted_Connection = True;";
        sql1 = "SELECT company_code,company_name,completed_latitudes,completed_longitudes FROM MapData_cmpl WHERE company_code = 1";
        sql2 = "SELECT company_code,company_name,inprogress_latitudes,inprogress_longitudes FROM MapData_inpr WHERE company_code = 1";
        sql3 = "SELECT company_code,company_name,completed_latitudes,completed_longitudes FROM MapData_cmpl WHERE company_code = 2";
        sql4 = "SELECT company_code,company_name,inprogress_latitudes,inprogress_longitudes FROM MapData_inpr WHERE company_code = 2";
        connection = new SqlConnection(connetionString);
        connection.Open();
        try
        {
            MapData mapData = new MapData();
            MapData mapData2 = new MapData();

            command1 = new SqlCommand(sql1, connection);
            command1.ExecuteNonQuery();
            dataReader1 = command1.ExecuteReader();
            List<Single> cmpl_lat_1 = new List<Single>();
            List<Single> cmpl_long_1 = new List<Single>();
            while (dataReader1.Read())
            {
                mapData.company_code = dataReader1.GetInt32(0);
                mapData.company_name = dataReader1.GetString(1);
                cmpl_lat_1.Add(dataReader1.GetFloat(2));
                cmpl_long_1.Add(dataReader1.GetFloat(3));
                /* mapData.company_code = dataReader.GetInt32(0);
                mapData.company_name = dataReader.GetString(1);
                mapData.inprogress_longitudes= dataReader.GetString(2).Split(',').Select(double.Parse).ToList();
                mapData.inprogress_latitudes = dataReader.GetString(3).Split(',').Select(double.Parse).ToList();
                mapData.completed_longitudes = dataReader.GetString(4).Split(',').Select(double.Parse).ToList();
                mapData.completed_latitudes = dataReader.GetString(5).Split(',').Select(double.Parse).ToList();
                Console.WriteLine(dataReader.GetValue(0) + " - " + dataReader.GetValue(1)+ " - " + dataReader.GetValue(2)+ " - " + dataReader.GetValue(3)+ " - " + dataReader.GetValue(4)+ " - " + dataReader.GetValue(5)); */
            }
            mapData.completed_latitudes = cmpl_lat_1;
            mapData.completed_longitudes = cmpl_long_1;
            dataReader1.Close();
            command1.Dispose();
        
            command2 = new SqlCommand(sql2, connection);
            command2.ExecuteNonQuery();
            dataReader2 = command2.ExecuteReader();
            List<Single> inpr_lat_1 = new List<Single>();
            List<Single> inpr_long_1 = new List<Single>();
            while (dataReader2.Read())
            {
                inpr_lat_1.Add(dataReader2.GetFloat(2));
                inpr_long_1.Add(dataReader2.GetFloat(3));
            }
            mapData.inprogress_latitudes = inpr_lat_1;
            mapData.inprogress_longitudes = inpr_long_1;
            dataReader2.Close();
            command2.Dispose();

            MapDataService.Add(mapData);
            Console.WriteLine(MapDataService.Get(1));



            
            command3 = new SqlCommand(sql3, connection);
            command3.ExecuteNonQuery();
            dataReader3 = command3.ExecuteReader();
            List<Single> cmpl_lat_2 = new List<Single>();
            List<Single> cmpl_long_2 = new List<Single>();
            while (dataReader3.Read())
            {
                mapData2.company_code = dataReader3.GetInt32(0);
                mapData2.company_name = dataReader3.GetString(1);
                cmpl_lat_2.Add(dataReader3.GetFloat(2));
                cmpl_long_2.Add(dataReader3.GetFloat(3));
                
            }
            mapData2.completed_latitudes = cmpl_lat_2;
            mapData2.completed_longitudes = cmpl_long_2;
            dataReader3.Close();
            command3.Dispose();

            command4 = new SqlCommand(sql4, connection);
            command4.ExecuteNonQuery();
            dataReader4 = command4.ExecuteReader();
            List<Single> inpr_lat_2 = new List<Single>();
            List<Single> inpr_long_2 = new List<Single>();
            while (dataReader4.Read())
            {
                inpr_lat_2.Add(dataReader4.GetFloat(2));
                inpr_long_2.Add(dataReader4.GetFloat(3));
            }
            mapData2.inprogress_latitudes = inpr_lat_2;
            mapData2.inprogress_longitudes = inpr_long_2;
            dataReader4.Close();
            command4.Dispose();

            MapDataService.Add(mapData2);
            Console.WriteLine(MapDataService.Get(2));
            

            //Connection Close here
            connection.Close();
            Console.WriteLine("Connection Open ! ");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Can not open connection ! " + ex);
        }

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
        }
        else
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}