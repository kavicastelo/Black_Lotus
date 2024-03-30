using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace webService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Class1 getInfo = new Class1();
        DataTable tblgetCustomers = new DataTable();
        DataTable tblgetflowers = new DataTable();
        DataTable tblgetPurches = new DataTable();
        DataTable tblgetCat = new DataTable();
        DataTable tblgetlogin = new DataTable();

        private MySqlConnection connection = new MySqlConnection();
        private MySqlCommand command = new MySqlCommand();
        private MySqlDataReader DbReader;
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        public MySqlTransaction DbTran;

        String server = "";
        String database = "";
        String uid = "";
        String password = "";

        String strConnString;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool createConn()
        {
            server = "localhost";
            database = "blacklotus";
            uid = "root";
            password = "2002";

            strConnString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "user id=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(strConnString);

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public bool login(String name, String pass)
        {
            try
            {
                this.createConn();

                if(connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string insertCommand = "INSERT INTO login(user,pass,level) VALUES('" + name + "','" + pass + "','" + 1 + "')";

                MySqlCommand cmd = new MySqlCommand(insertCommand, connection);
                cmd.ExecuteNonQuery();

                return true;

            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool addSalesman(String name, String tp, String age, String addr)
        {
            try
            {
                this.createConn();

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string insertCommand = "INSERT INTO salesman(name,tp,age,addr) VALUES('" + name + "','" + tp + "','" + age + "','"+addr+"')";

                MySqlCommand cmd = new MySqlCommand(insertCommand, connection);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool addFlowers(String cat, String name, String qunt, String ppu)
        {
            try
            {
                this.createConn();

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string insertCommand = "INSERT INTO flowers(category,name,qunt,ppu) VALUES('" + cat + "','" + name + "','" + qunt + "','" + ppu + "')";

                MySqlCommand cmd = new MySqlCommand(insertCommand, connection);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool updateFlowers(String cat, String name, String qunt, String ppu, String id)
        {
            try
            {
                this.createConn();

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string insertCommand = "UPDATE flowers SET category='" + cat + "',name='" + name + "',qunt='" + qunt + "',ppu='" + ppu + "' WHERE FID='"+id+"'";

                MySqlCommand cmd = new MySqlCommand(insertCommand, connection);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool sellFlowers(String cid, String cname, String ctp, String caddr, String fid, String fcat, String fname, String qunt, String tot)
        {
            try
            {
                this.createConn();

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string insertCommand = "INSERT INTO purches(cid,c_name,c_tp,c_addr,FID,f_cat,f_name,qunt,tot) VALUES('" + cid + "','" + cname + "','" + ctp + "','" + caddr + "','" + fid + "','" + fcat + "','" + fname + "','" + qunt + "','" + tot + "')";

                MySqlCommand cmd = new MySqlCommand(insertCommand, connection);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool addcustomer(String name, String tp, String email, String addr)
        {
            try
            {
                this.createConn();

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string insertCommand = "INSERT INTO customer(name,tp,email,addr) VALUES('" + name + "','" + tp + "','" + email + "','" + addr + "')";

                MySqlCommand cmd = new MySqlCommand(insertCommand, connection);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        [WebMethod]
        public string retriveCustomerData(string id)
        {
            string searchSQL = "SELECT * FROM customer WHERE CID ='" + id + "'";
            getInfo.readDatathroughAdapter(searchSQL, tblgetCustomers);

            string result = JsonConvert.SerializeObject(tblgetCustomers);
            return result;
        }

        [WebMethod]
        public string retriveFlowerData(string id)
        {
            string searchSQL = "SELECT * FROM flowers WHERE FID ='" + id + "'";
            getInfo.readDatathroughAdapter(searchSQL, tblgetflowers);

            string result = JsonConvert.SerializeObject(tblgetflowers);
            return result;
        }

        [WebMethod]
        public string retriveFlowerDataToAdd()
        {
            string searchSQL = "SELECT * FROM flowers";
            getInfo.readDatathroughAdapter(searchSQL, tblgetflowers);

            string result = JsonConvert.SerializeObject(tblgetflowers);
            return result;
        }

        [WebMethod]
        public string viewCustomers()
        {
            string searchSQL = "SELECT * FROM customer";
            getInfo.readDatathroughAdapter(searchSQL, tblgetCustomers);

            string result = JsonConvert.SerializeObject(tblgetCustomers);
            return result;
        }

        [WebMethod]
        public string viewSalesmen()
        {
            string searchSQL = "SELECT * FROM salesman";
            getInfo.readDatathroughAdapter(searchSQL, tblgetPurches);

            string result = JsonConvert.SerializeObject(tblgetPurches);
            return result;
        }

        [WebMethod]
        public string viewPurches()
        {
            string searchSQL = "SELECT * FROM purches";
            getInfo.readDatathroughAdapter(searchSQL, tblgetCat);

            string result = JsonConvert.SerializeObject(tblgetCat);
            return result;
        }

        [WebMethod]
        public string viewCat()
        {
            string searchSQL = "SELECT * FROM category";
            getInfo.readDatathroughAdapter(searchSQL, tblgetCat);

            string result = JsonConvert.SerializeObject(tblgetCat);
            return result;
        }

        [WebMethod]
        public string getCategoriesToCombo()
        {
            string searchSQL = "SELECT * FROM category";
            getInfo.readDatathroughAdapter(searchSQL, tblgetCustomers);

            string result = JsonConvert.SerializeObject(tblgetCustomers);
            return result;
        }

        [WebMethod]
        public string retrevwLogin()
        {
            string searchSQL = "SELECT * FROM login";
            getInfo.readDatathroughAdapter(searchSQL, tblgetlogin);

            string result = JsonConvert.SerializeObject(tblgetlogin);
            return result;
        }

        [WebMethod]
        public bool addcategory(String cat)
        {
            try
            {
                this.createConn();

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string insertCommand = "INSERT INTO category(category) VALUES('" + cat + "')";

                MySqlCommand cmd = new MySqlCommand(insertCommand, connection);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool deleteCat(String name)
        {
            try
            {
                this.createConn();

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string deleteCat = "DELETE FROM category WHERE category='"+name+"'";


                MySqlCommand catcmd = new MySqlCommand(deleteCat, connection);
                catcmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool deleteCatfromFlow(String name)
        {
            try
            {
                this.createConn();

                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }

                string deleteFlower = "DELETE FROM flowers WHERE category='" + name + "'";

                MySqlCommand flowercmd = new MySqlCommand(deleteFlower, connection);
                flowercmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}
